using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WpfApp1.Valid
{
    public class Login: ValidationRule
    {
        public override ValidationResult Validate (object value, CultureInfo cultureInfo)
        {
            var input = (value ?? "").ToString().Trim();
            if (input == string.Empty)
            {
                return new ValidationResult(false, "Ввод Логина обязателен");
            }


            
            if (input.Length <5)
            {
                return new ValidationResult(false, "Логин должен состоять минимум из 5 символов");
            }


            return ValidationResult.ValidResult;

        }
    }
}
