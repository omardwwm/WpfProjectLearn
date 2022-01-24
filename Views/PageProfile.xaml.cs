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
using WpfProjetFinal.Models;
using WpfProjetFinal.ViewModel;

namespace WpfProjetFinal.Views
{
    /// <summary>
    /// Interaction logic for PageProfile.xaml
    /// </summary>
    public partial class PageProfile : Page
    {
        private PageUpdateUser pageUpdateUser = new PageUpdateUser();
        UserViewModel userVM = new UserViewModel();

        //private void NavigationService_LoadCompleted(object sender, NavigationEventArgs e)
        //{
        //    string user = (string)e.ExtraData;
        //    Console.WriteLine("EMAIL IS =====================================================>>>>>>>> " + user);

        //    // do whatever with str, like assign to a view model field, etc.
        //}


        public PageProfile()
        {
            InitializeComponent();

            DataContext = userVM;
            tbxNom.Text = "okkkk";
            //User user = new User();
            //NavigationService.LoadCompleted += NavigationService_LoadCompleted;
        }

        //private void NavigationService_LoadCompleted(object sender, NavigationEventArgs e)
        //{
        //    userVM.UserSellectionedVM user = (User)e.ExtraData;
        //    Console.WriteLine(user.Email);

        //    // do whatever with str, like assign to a view model field, etc.
        //}


        private void GoToFormUpdUser_Click(object sender, RoutedEventArgs e)
        {
            frmPage.Navigate(pageUpdateUser);
        }
    }
}
