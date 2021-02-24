// <copyright file="Edit.cs" company="MSanyi">
// Copyright (c) MSanyi.All rights reserved.
// </copyright>

namespace VegyesBolt.UI.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using VegyesBolt.Data;

    /// <summary>
    ///     The class which handles the Edit logic.
    /// </summary>
    internal class Edit : IEdit
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="Edit" /> class.
        /// </summary>
        /// <param name="editableItem">The item that needs to be edited.</param>
        public Edit(object editableItem)
        {
            this.EditableItem = editableItem;
            this.Mode = EditMode.Update;
        }

        /// <inheritdoc />
        public List<string> PropNames
        {
            get
            {
                // return EditableItem.ToString().Split('\t').ToList();
                return this.EditableItem switch
                {
                    Megyek => Megyek.Header().Split('\t').ToList(),
                    Termekek => Termekek.Header().Split('\t').ToList(),
                    Vasarlok => Vasarlok.Header().Split('\t').ToList(),
                    Vasarlasok => Vasarlasok.Header().Split('\t').ToList(),
                    _ => throw new NotImplementedException()
                };
            }
        }

        /// <summary>
        ///     Gets or sets a list that returns the property values according to the object.
        /// </summary>
        public List<object> Values
        {
            get
            {
                return this.EditableItem switch
                {
                    Megyek m => EditValues.MegyeValues(input: m),
                    Termekek t => EditValues.TermekValues(input: t),
                    Vasarlok v => EditValues.VasarlokValues(input: v),
                    Vasarlasok v => EditValues.VasarlasokValues(input: v),
                    _ => throw new NotImplementedException()
                };
            }

            set => this.EditedItem = value;
        }

        /// <summary>
        ///     Gets the Title of the String.
        /// </summary>
        public string Title
        {
            get
            {
                return this.EditableItem switch
                {
                    Megyek => "Megye",
                    Termekek => "Termek",
                    Vasarlok => "Vasarlo",
                    Vasarlasok => "Vasarlasok",
                    _ => throw new NotSupportedException()
                };
            }
        }

        /// <inheritdoc />
        public EditMode Mode { get; }

        private object EditableItem { get; }

        private object EditedItem { get; set; }

        /// <inheritdoc />
        public bool Save()
        {
            switch (this.EditedItem)
            {
                case Megyek m:

                    break;
            }

            return false;
        }
    }
}