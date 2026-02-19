using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WpfApp1.Valid
{
    public  class Nopast:ValidationRule
    {
        public override ValidationResult Validate (object value, CultureInfo cultureInfo)
        {
             
            if (value == null)
            {
                return new ValidationResult(false, "Ввод даты обязателен обязателен");
            }

            DateTime input;

            if (!DateTime.TryParse(value.ToString(), out input))
            {
                return new ValidationResult(false, "Неврный формат даты");
            }


            if (input.Date < DateTime.Today)
            {
                return new ValidationResult(false, "Дата и время не может быть раньше текущей");
            }

            return ValidationResult.ValidResult;

        }
    }
}
