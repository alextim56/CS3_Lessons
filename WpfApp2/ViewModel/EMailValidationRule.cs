using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WpfTestMailSender.ViewModel
{
    public class EMailValidationRule : ValidationRule
    {
        Regex regex = new Regex(@"[A-Za-z]+[\.A-Za-z0-9_-]*[A-Za-z0-9]+@[A-Za-z0-9]+\.[A-Za-z]{2,6}");
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string email = value.ToString();
            if (!regex.IsMatch(email))
                return new ValidationResult(false, "Email введен не верно!");
            else
                return new ValidationResult(true, null);
        }
    }
}
