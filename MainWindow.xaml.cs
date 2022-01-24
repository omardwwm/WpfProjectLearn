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
using WpfProjetFinal.Views;

namespace WpfProjetFinal
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // La navigation:
        private PageAccueil pageAccueil = new PageAccueil();
        private PageUsersLayout pageUsersLayout = new PageUsersLayout();
        private PageInscription pageInscription = new PageInscription();
        private PageListUsers pageListUsers = new PageListUsers();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MenuButton_Click(object sender, RoutedEventArgs e)
        {
            int index = int.Parse(((Button)e.Source).Uid);

            GridCursor.Margin = new Thickness(10 + (150 * index), 0, 0, 0);
            switch (index)
            {
                case 0:
                    //GridMain.Background = Brushes.Aquamarine;
                    GridMain.Navigate(pageAccueil);
                    break;
                case 1:
                    //GridMain.Background = Brushes.Beige;
                    GridMain.Navigate(pageUsersLayout);
                    break;
                case 2:
                    //GridMain.Background = Brushes.CadetBlue;
                    GridMain.Navigate(pageListUsers);
                    break;
                case 3:
                    GridMain.Background = Brushes.DarkBlue;
                    break;
            }
        }
    }
}
