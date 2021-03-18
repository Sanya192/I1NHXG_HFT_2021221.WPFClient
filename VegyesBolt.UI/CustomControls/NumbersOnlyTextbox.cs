// <copyright file="NumbersOnlyTextbox.cs" company="MSanyi">
// Copyright (c) MSanyi.All rights reserved.
// </copyright>

namespace VegyesBolt.UI.CustomControls
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;
    using System.Windows.Controls;
    using System.Windows.Input;

    /// <summary>
    /// A textbox allowing only Numbers.
    /// </summary>
    public class NumbersOnlyTextbox : TextBox
    {
        private static readonly Regex Regex = new Regex("^[+-]?([0-9]+([.][0-9]*)?|[.][0-9]+)$");

        /// <summary>
        /// If the text is other than what Regex is allows then the event won't proceed.
        /// </summary>
        /// <param name="e">The input arguments.</param>
        protected override void OnPreviewTextInput(TextCompositionEventArgs e)
        {
            if (!Regex.IsMatch(e?.Text))
            {
                e.Handled = true;
            }

            base.OnPreviewTextInput(e);
        }
    }
}
