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
    using VegyesBolt.Data;
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

        private bool lostFocus;

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

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            EditHonfoglalas edit = null;
            var sajt = this.DataContext as BoltViewModel;
            if (sajt.SelectedTable == Tables.Megyek)
            {
                edit = new EditHonfoglalas();
            }
            else
            {
                MessageBox.Show("Csak a megyéket lehet módosítani.");
            }

            (edit.DataContext as HonfoglaloViewModel).OnSave += sajt.SaveCurrent;
            edit?.Show();
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            /*var sajt = this.DataContext as BoltViewModel;
            EditWindow edit = new EditWindow(new EditViewModel(sajt.SelectedObject));
            edit.Show();*/
            EditHonfoglalas edit = null;
            var sajt = this.DataContext as BoltViewModel;
            if (sajt.SelectedTable == Tables.Megyek)
            {
                if (sajt.SelectedObject != null)
                {
                    edit = new EditHonfoglalas(sajt.SelectedObject as Megyek);
                }
                else
                {
                    MessageBox.Show("Jelölj ki egy elemet.");
                }
            }
            else
            {
                MessageBox.Show("Csak a megyéket lehet módosítani.");
            }
            (edit.DataContext as HonfoglaloViewModel).OnSave += sajt.SaveCurrent;
            edit?.Show();
        }

        private void Window_GotFocus(object sender, EventArgs e)
        {
            var sajt = this.DataContext as BoltViewModel;
            sajt.Refresh();
        }
    }
}
