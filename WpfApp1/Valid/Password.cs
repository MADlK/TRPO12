using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WpfApp1.Valid
{
    public class Password: ValidationRule
    {

        
        public override ValidationResult Validate (object value, CultureInfo cultureInfo)
        {
            var input = (value ?? "").ToString().Trim();
            if (input == string.Empty)
            {
                return new ValidationResult(false, "Ввод Пароля обязателен");
            }
            
            
            if (input.Any(Char.IsLetterOrDigit))
            {
                return new ValidationResult(false, "Нет спец. символов");
            }
            if (!input.Any(Char.IsUpper))
            {
                return new ValidationResult(false, "Нет букв в верхнем регистре");
            }
            if (!input.Any(Char.IsLower))
            {
                return new ValidationResult(false, "Нет букв в нижнем регистре");
            }
            return ValidationResult.ValidResult;

        }
    }
}
