using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfProjetFinal.ViewModel;

namespace WpfProjetFinal.Commandes
{
    public class AddUser : ICommand
    {
        private UserViewModel userViewModel;


        public AddUser(UserViewModel userViewModel)
        {
            this.userViewModel = userViewModel;
        }


        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _ = userViewModel.AddUserWS(userViewModel.UserVM);
        }
    }
}
