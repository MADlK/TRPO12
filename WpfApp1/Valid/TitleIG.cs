using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WpfApp1.Valid
{
    public class TitleIG :ValidationRule
    {

        public InterstGroupService interstGroupService { get; set; } = new();
        public override ValidationResult Validate (object value, CultureInfo cultureInfo)
        {

            
             

            if (interstGroupService.InterstGroups.Any(ig => ig.Title.ToLower() == value.ToString().ToLower()))
            {

                return new ValidationResult(false, "Такая группа уже существует");
            }



            //if()


            return ValidationResult.ValidResult;
        }
    }
}
