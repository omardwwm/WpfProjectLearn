using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfProjetFinal.Helpers
{
    public class CryptHelper
    {
        //(Text clair --> base 64)
        public static string Base64Encode(string textClair)
        {
            var textClairBytes = System.Text.Encoding.UTF8.GetBytes(textClair);
            return System.Convert.ToBase64String(textClairBytes);
        }


        // (Base 64 --> text clair)
        public static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }
    }
}
