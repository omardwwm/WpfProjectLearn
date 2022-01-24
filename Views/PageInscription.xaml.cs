using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for Inscription.xaml
    /// </summary>
    public partial class PageInscription : Page
    {
        UserViewModel userVM = new UserViewModel();
        public PageInscription()
        {
            InitializeComponent();

            DataContext = userVM;
        }

        //private void Authentifier()
        //{
        //    // rendre la fenntre principal invisible
        //    this.Hide();
        //    //Appel la fenetre auth WindowAuth (ds notre dossier Views)
        //    PageInscription pageInscription = new PageInscription();

        //    // Affichage en modal pour redirger ou annuler
        //    if (pageInscription.ShowDialog() == true)
        //    {
        //        // Auth reussi (success)
        //        this.Show();
        //    }
        //    else
        //    {
        //        MessageBox.Show("Echec/failur d'authentification, fermeture de l'appli");
        //        this.Close();
        //    }
        //}

        private void AddUser_Click(object sender, RoutedEventArgs e)
        {
            SaveImg();
            _ = userVM.AddUserWS(userVM.UserVM);
        }

        //public OpenFileDialog op = new OpenFileDialog();
        string folderpath = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + "\\Images\\";
        OpenFileDialog op = new OpenFileDialog();
        private void ShowImg()
        {
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
                        "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
                        "Portable Network Graphic (*.png)|*.png";
            bool? myResult;
            myResult = op.ShowDialog();
            if (myResult != null && myResult == true)
            {
                imgBox.Source = new BitmapImage(new Uri(op.FileName));
                tbxImg.Text = op.FileName;
            }
            else
            {
                // A revoir...!!
                userVM.UserVM.Picture = String.Empty;
            }
        }

        private void SaveImg()
        {
            if (!Directory.Exists(folderpath))
            {
                Directory.CreateDirectory(folderpath);
            }
            string filePath = folderpath + System.IO.Path.GetFileName(op.FileName);
            //tbxImg.Text = filePath;
            userVM.UserVM.Picture = filePath;
            File.Copy(op.FileName, filePath, true);
        }

        private void SelectPicture_Click(object sender, RoutedEventArgs e)
        {
            ShowImg();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        //private void SavePicTest_Click(object sender, RoutedEventArgs e)
        //{
        //    //string testPath = @"C:\Users\Precision 5110\source\repos\WcfFirstSoapSrevice\WpfProjetFinal\Images";
        //    //string _finalPath;
        //    //var files = Directory.GetFiles(@"C:\Users\Precision 5110\Desktop\Camera");
        //    //foreach (var file in files)
        //    //{
        //    //    var filename = file.Substring(file.LastIndexOf("\\") + 1); // Get the filename from absolute path
        //    //    _finalPath = testPath; //it is the destination folder path e.g,C:\Users\Neha\Pictures\11-03-2014
        //    //    if (Directory.Exists(_finalPath))
        //    //    {
        //    //        _finalPath = Path.Combine(_finalPath, filename);
        //    //        File.Copy(file, _finalPath, true);
        //    //    }
        //    //}

        //    //var imagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images");
        //    //string sourceDir = @"C:\Users\Precision 5110\Desktop\Camera\IMG_20180504_090713.jpg";
        //    //string correctFileName = Path.GetFileName(op.FileName);
        //    //File.Copy(op.FileName, Path.Combine(AppDomain.CurrentDomain.BaseDirectory) + "Images" + "\\" + correctFileName);
        //    //File.Copy(op.FileName, testPath +  correctFileName, true);
        //}

        private void OnPasswordChanged(object sender, RoutedEventArgs e)
        {
            userVM.UserVM.Password = pswbxPassword.Password;
        }
    }
}
