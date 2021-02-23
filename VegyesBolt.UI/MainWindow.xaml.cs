// <copyright file="MainWindow.xaml.cs" company="MSanyi">
// Copyright (c) MSanyi.All rights reserved.
// </copyright>

namespace VegyesBolt.UI
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Navigation;
    using System.Windows.Shapes;
    using VegyesBolt.UI.ViewModel;

    /// <summary>
    /// Interaction logic for MainWindow.xaml.
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        /// <param name="model">The Boltmodel Datacontext.</param>
        public MainWindow(BoltViewModel model)
            : this()
        {
            this.DataContext = null;
            this.DataContext = model;
        }

        private void MegyeButton_Click(object sender, RoutedEventArgs e)
        {
            var sajt = this.DataContext as BoltViewModel;
            sajt.SelectedTable = Tables.Megyek;
        }

        private void VasarloButton_Click(object sender, RoutedEventArgs e)
        {
            var sajt = this.DataContext as BoltViewModel;
            sajt.SelectedTable = Tables.Vasarlok;
        }

        private void TermekButton_Click(object sender, RoutedEventArgs e)
        {
            var sajt = this.DataContext as BoltViewModel;
            sajt.SelectedTable = Tables.Termekek;
        }

        private void VasarlasButton_Click(object sender, RoutedEventArgs e)
        {
            var sajt = this.DataContext as BoltViewModel;
            sajt.SelectedTable = Tables.Vasarlasok;
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var sajt = this.DataContext as BoltViewModel;
            sajt.DeleteCurrent();
        }
    }
}
