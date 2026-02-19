using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WpfApp1.Valid
{
    public class ContainDog :ValidationRule
    {
        public override ValidationResult Validate (object value, CultureInfo cultureInfo)
        {
            var input = (value ?? "").ToString().Trim();
            if (input == string.Empty)
            {
                return new ValidationResult(false, "Ввод Почты обязателен обязателен");
            }
            if (!input.Contains('@'))
            {
                return new ValidationResult(false, "Нет знака @");
            }
            
            return ValidationResult.ValidResult;

        }
    }
}
