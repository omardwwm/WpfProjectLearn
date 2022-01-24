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
using WpfProjetFinal.ViewModel;

namespace WpfProjetFinal.Views
{
    /// <summary>
    /// Interaction logic for PageAccueil.xaml
    /// </summary>
    public partial class PageAccueil : Page
    {
        private PageInscription pageInscription = new PageInscription();
        //private WindowAuth windowAuth = new WindowAuth();
        private PageAuth pageAuth = new PageAuth();

        UserViewModel userVM = new UserViewModel();
        public PageAccueil()
        {
            InitializeComponent();
            DataContext = userVM;
        }

        private void GoToFormInscription_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(pageInscription);
        }

        private void GoToWindAuth_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(pageAuth);
        }
    }
}
