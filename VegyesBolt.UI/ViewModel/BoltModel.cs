// <copyright file="BoltModel.cs" company="MSanyi">
// Copyright (c) MSanyi.All rights reserved.
// </copyright>

namespace VegyesBolt.UI.ViewModel
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using VegyesBolt.Data;
    using VegyesBolt.Logic;

    /// <summary>
    /// The ViewModel For the APP.
    /// </summary>
    internal class BoltModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BoltModel"/> class.
        /// </summary>
        public BoltModel()
        {
            this.Worker = new Worker();
            this.SelectedTable = Tables.Megyek;
        }

        /// <summary>
        /// Gets or sets the currently selected table.
        /// </summary>
        public Tables SelectedTable { get; set; }

        private Worker Worker { get; }

        private List<Megyek> Megyek { get => this.Worker.GetMegyek(); }

        private List<Vasarlok> Vasarlok { get => this.Worker.GetVasarlok(); }

        private List<Termekek> Termekek { get => this.Worker.GetTermekek(); }

        private List<Vasarlasok> Vasarlasok { get => this.Worker.GetVasarlasok(); }

        /// <summary>
        /// Shows all members of the currently selected table.
        /// </summary>
        /// <returns>all members of the currently table.</returns>
        public IEnumerable<object> ShowAll()
        {
            return this.SelectedTable switch
            {
                Tables.Megyek => this.Megyek,
                Tables.Vasarlok => this.Vasarlok,
                Tables.Termekek => this.Termekek,
                Tables.Vasarlasok => this.Vasarlasok,
                _ => throw new NotSupportedException(),
            };
        }
    }
}
