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
        public StudentSirvice p { get; set; } = new();
        public override ValidationResult Validate (object value, CultureInfo cultureInfo)
        {
            
        string input = (value ?? "").ToString().Trim();
            if (input == string.Empty)
            {
                return new ValidationResult(false, "Ввод Почты обязателен обязателен");
            }
            if (!input.Contains('@'))
            {
                return new ValidationResult(false, "Нет знака @");
            }
            if (p.Students.Any(x => x.Email == input))
            {
                return new ValidationResult(false, "такая почта уже существует");
            }

                return ValidationResult.ValidResult;

        }
    }
}
