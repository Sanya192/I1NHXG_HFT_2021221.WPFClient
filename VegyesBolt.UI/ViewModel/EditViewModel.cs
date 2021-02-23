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

    /// <summary>
    /// The ViewModel for the edit Vindow.
    /// </summary>
    public class EditViewModel
    {
        /// <summary>
        /// Gets or sets the Title of the Vindow.
        /// </summary>
        public string Title { get; set; }

        private object Entity { get; set; }

        public int MyProperty { get; set; }
    }
}
