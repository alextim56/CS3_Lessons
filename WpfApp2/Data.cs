using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfTestMailSender
{
    
    public static class Data
    {
        public static string MailSender = "alexandertimofeev56@gmail.com";
        public static string MailReciever = "nikonov5885@yandex.ru";
        public static string MailPassword;
        public static string SMTP_server = "smtp.gmail.com";
        public static int SMTP_port = 587;

        public static bool Check(string login, string password)
        {
            if (login == "admin" && password == "admin") return true;
            return false;
        }
    }
}
