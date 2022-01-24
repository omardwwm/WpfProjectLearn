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
    /// Interaction logic for PageListUsers.xaml
    /// </summary>
    public partial class PageListUsers : Page
    {
        private PageProfile pageProfile = new PageProfile(); //Pour tester

        UserViewModel userVM = new UserViewModel();
        public PageListUsers()
        {
            InitializeComponent();
            DataContext = userVM;
        }

        public object Navigation { get; private set; }

        private void GetAllUsers_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("test debug");
            //Debug.WriteLine("test console avant appel methode getUser");
            userVM.GetUsersWS();
        }
        //string test = "test data transfer in navigation";
        private async void GoToProFromList_Click(object sender, RoutedEventArgs e)
        {
            var testUser = userVM.UserSellectionedVM;
            pageProfile.tbxNom.Text = userVM.UserSellectionedVM.Nom;
            pageProfile.tbxEmail.Text = userVM.UserSellectionedVM.Email;
            //pageProfile.imgUser.Source = new BitmapImage(new Uri(userVM.UserSellectionedVM.Picture, UriKind.Relative));
            pageProfile.imgUser2.ImageSource = new BitmapImage(new Uri(userVM.UserSellectionedVM.Picture, UriKind.Relative));
            //pageProfile.bndImg.Path = new BitmapImage(new Uri(userVM.UserSellectionedVM.Picture, UriKind.Relative));
            if (userVM.UserSellectionedVM.IsProfessional)
            {
                pageProfile.tbxStatus.Text = "Statut : Chef/Professionnel";
            }
            else
            {
                pageProfile.tbxStatus.Text = "Statut : Cuisinier Amateur";
            }
            NavigationService.Navigate(pageProfile);  
        }
    }
}
