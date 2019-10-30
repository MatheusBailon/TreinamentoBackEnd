using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SpaUserControl.Common.Validation
{
    public class EmailAssertionConcern
    {
        public static void Email(string email,string domain="")
        {
            string pattern = domain == "" ? "\\w.*@\\w+\\.(com|br|org)" : "\\w.*@"+domain;
            if(!Regex.IsMatch(email, "\\w.*@\\w+\\.(com|br|org)"))
            {
                throw new Exception("Email inválido");
            }
        }
    }
}
