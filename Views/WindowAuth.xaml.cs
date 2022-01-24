using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using WpfProjetFinal.Helpers;

namespace WpfProjetFinal.Views
{
    /// <summary>
    /// Interaction logic for WindowAuth.xaml
    /// </summary>
    public partial class WindowAuth : Window
    {
        //fiels 
        private int nbEssai = 3; // 3 essaie (determiner le nombre de tentatives d'authentification)
        public WindowAuth()
        {
            InitializeComponent();
        }

        private void ValiderAuth_Click(object sender, RoutedEventArgs e)
        {
            if (chkbxAuth.IsChecked == false)
            {
                AutentificationWindows();
            }
            else
            {
                AuthentificationSQL();
            }

        }

        private void AuthentificationSQL()
        {
            // MessageBox.Show("AUTH SQL");
            //Verfifier ds la table user l'existance login et password 
            //Creer la methode (avec param login, password) ds le controller de l'api et de recuperer le lien ici,
            // puis lui envoyer le login et password recuperer ici via le binding du form wpf). 


        }

        private void AutentificationWindows()
        {
            //Afficher le compte (login, password) saissis (pour tester)
            // MessageBox.Show($"Login is {tbxLogin.Text}, Password is {pwbPassword.Password}");
            // WPF -- appli en entreprise
            //Authen via AD (Active Directory) (annuaire des compte utilisateurs)
            //Creer une classe qui gere ces methode (class Helper)

            bool accessOK = AccessADHelper.IsLoginCorrecte(tbxLogin.Text, pwbPassword.Password, "");
            string logAction = string.Empty;

            if (accessOK)
            {
                logAction = DateTime.Now + " " + tbxLogin.Text + " from poste (PC)" + Environment.UserName + " Success";
                Logger(logAction);
                this.DialogResult = true;
            }
            else
            {
                Decompte();

            }
        }
         
        //Loger les actions (echecs de conx) de 2 maniere
        // logger ds sql ou bien logger au niveau des journaux d'evenements du syst --crypte

        private void Logger(string logAction)
        {
                // crypter le log
                //chngmt du base : text clair(utf-8) -> base64
                string logCrypted = CryptHelper.Base64Encode(logAction);

                // testet l'affichage
                MessageBox.Show(logAction);
                MessageBox.Show(logCrypted);

            //logger/inscrire au niveau des journaux d'evenements du syst --crypte
            var logJournal = new EventLog("Application");
            logJournal.Source = "Application";
            logJournal.WriteEntry(logAction, EventLogEntryType.Information, 52000);
        }

        private void Decompte()
        {
            --nbEssai;  //Dicremente le nomre d'essai
            string logAction = DateTime.Now + " " + tbxLogin.Text + " from poste (PC)" + Environment.UserName + " Echec";
            Logger(logAction);
            if (nbEssai == 0)
            {
                this.DialogResult = false;
            }
            else
            {
                MessageBox.Show($"Il vous reste {nbEssai} tentatives !");

            }
        }



            // Sinon cas d'une api rest, verifier si le couple login et mot existe en bdd, 
    }
}
