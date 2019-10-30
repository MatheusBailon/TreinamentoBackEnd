using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaUserControl.Common.Validation
{
    public class AssertionConcern
    {
        //Nesta classe ficará todos os "IF's" comuns para ser utilizado de um modo mais simples e padronizado facilitando também na manutenção
        static public void AssertArgumentNotNullOrEmpty(string text,string message ="Campo vazio")
        {
            if (String.IsNullOrEmpty(text))
            {
                throw new ArgumentException(message);
            }
        }

        public static void AssertArgumentEquals(string text1, string text2,string message)
        {
            if(text1 != text2)
            {
                throw new ArgumentException(message);
            }
            
        }

        public static void AssertArgumentLength(string password, int min, int max, string message)
        {
            if(password.Length > max || password.Length < min)
            {
                throw new ArgumentException(message);
            }
        }
    }
}
