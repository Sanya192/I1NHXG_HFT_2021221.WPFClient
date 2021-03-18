// <copyright file="EditWindow.xaml.cs" company="MSanyi">
// Copyright (c) MSanyi.All rights reserved.
// </copyright>

namespace VegyesBolt.UI
{
    using System.Windows;
    using VegyesBolt.UI.ViewModel;

    /// <summary>
    /// Interaction logic for EditWindow.xaml.
    /// </summary>
    public partial class EditWindow : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EditWindow"/> class.
        /// </summary>
        public EditWindow()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EditWindow"/> class.
        /// </summary>
        /// <param name="vmodel">An alreadyExistingViewModel.</param>
        public EditWindow(EditViewModel vmodel)
            : this()
        {
            this.DataContext = null;
            this.DataContext = vmodel;
        }
    }
}
