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
    /// Interaction logic for PageUsersLayout.xaml
    /// </summary>
    public partial class PageUsersLayout : Page
    {
        private PageInscription pageInscription = new PageInscription();
        private PageListUsers pageListUsers = new PageListUsers();
        private PageProfile pageProfile = new PageProfile();

        UserViewModel userVM = new UserViewModel();
        public PageUsersLayout()
        {
            InitializeComponent();
            DataContext = userVM;
        }

        private void PageInscription_Click(object sender, RoutedEventArgs e)
        {
            frmPages.Navigate(pageInscription);
        }

        private void PageListUsers_Click(object sender, RoutedEventArgs e)
        {
            frmPages.Navigate(pageListUsers);
        }

        private void GoToProfilPage_Click(object sender, RoutedEventArgs e)
        {
            frmPages.Navigate(pageProfile);
            //NavigationService.Navigate(pageProfile, userVM.UserSellectionedVM);
        }
    }
}
