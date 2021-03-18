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
        HonfoglaloViewModel ViewModel { get; }
        public EditHonfoglalas(Megyek megye = null)
        {
            InitializeComponent();
            if (megye == null)
            {
                ViewModel = new HonfoglaloViewModel();
            }
            else
            {
                ViewModel = new HonfoglaloViewModel(megye);
            }
            this.DataContext = ViewModel;
        }
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.Save();
            this.Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.Save();
            this.Close();
        }
    }
}
