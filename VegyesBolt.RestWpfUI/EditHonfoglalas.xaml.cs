// <copyright file="EditHonfoglalas.xaml.cs" company="MSanyi">
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
    using System.Windows.Shapes;
    using VegyesBolt.Data;
    using VegyesBolt.Logic;
    using VegyesBolt.UI.ViewModel;

    /// <summary>
    /// Interaction logic for EditHonfoglalas.xaml.
    /// </summary>
    public partial class EditHonfoglalas : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EditHonfoglalas"/> class.
        /// </summary>
        /// <param name="megye">The megye which is edited.Optional.</param>
        public EditHonfoglalas(Megyek megye = null)
        {
            this.InitializeComponent();
            if (megye == null)
            {
                this.ViewModel = new HonfoglaloViewModel();
            }
            else
            {
                this.ViewModel = new HonfoglaloViewModel(megye);
            }

            this.DataContext = this.ViewModel;
        }

        private HonfoglaloViewModel ViewModel { get; }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            (this.DataContext as HonfoglaloViewModel).Save();
            this.Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
