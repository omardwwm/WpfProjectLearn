using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfProjetFinal.Helpers
{
    public class AccessADHelper
    {
        //Le code est fourni par Microsoft
        // 1- Specifier la thread principale de l'appli
        [STAThread]
        //Importer une dll qui communique avec l'AD
        [System.Runtime.InteropServices.DllImport("advapi32.dll")] // import de bibliotheque

        public static extern bool LogonUser(string userName, string domainName, string password, int LogonType, int LogonProvider, ref IntPtr phToken);

        //La methode qui verifier si le compte est valide ou pas
        public static bool IsLoginCorrecte(string login, string password, string domain)
        {

            IntPtr tokenHandler = IntPtr.Zero;

            bool isValid = LogonUser(login, domain, password, 2, 0, ref tokenHandler);
            return isValid;

        }



    }
}
