using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfTestMailSender
{
    public static class CodePasswordClass
    {
        public static string GetPassword(string s_paswrd)
        {
            string password = "";
            foreach (char a in s_paswrd)
            {
                char ch = a;
                ch--;
                password += ch;
            }
            return password;
        }

        public static string GetCodePassword(string s_paswrd)
        {
            string password = "";
            foreach (char a in s_paswrd)
            {
                char ch = a;
                ch++;
                password += ch;
            }
            return password;
        }
    }
}
