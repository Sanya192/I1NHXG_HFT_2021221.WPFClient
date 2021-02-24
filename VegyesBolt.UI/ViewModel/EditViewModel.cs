// <copyright file="EditModel.cs" company="MSanyi">
// Copyright (c) MSanyi.All rights reserved.
// </copyright>

namespace VegyesBolt.UI.ViewModel
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using VegyesBolt.Logic;
    using VegyesBolt.UI.Logic;

    /// <summary>
    /// The ViewModel for the edit Vindow.
    /// </summary>
    public class EditViewModel
    {

        /// <summary>
        /// Gets or sets the Title of the Vindow.
        /// </summary>
        public string Title { get => Edit?.Title; }

        //private object Entity { get; set; }
        private Edit Edit { get; }
        private Worker Worker { get; }

        public EditViewModel()
        {

        }

        public EditViewModel(object entity) : this()
        {
            //this.Entity = entity;
            this.Edit = new Edit(entity);
        }

        public List<string> PropNames { get => Edit?.PropNames; }

        public List<object> PropValues { get => Edit?.Values; }
    }
}
