using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp1.Valid;

namespace WpfApp1.P
{
    /// <summary>
    /// Логика взаимодействия для Add_InterestGroup_Page.xaml
    /// </summary>
    public partial class Add_InterestGroup_Page :Page
    {
        private InterstGroupService _service = new();
        public InterstGroup _student = new();
        bool isEdit = false;


        public Add_InterestGroup_Page (InterstGroup? EditIG = null)
        {
            InitializeComponent();
            if (EditIG != null)
            {
                _student = EditIG;
                isEdit = true;
            }
            
            DataContext = _student;
        }

        private void save (object sender, RoutedEventArgs e)
        {

            //if (Validation.GetHasError(UName) || Validation.GetHasError(LogTB) || Validation.GetHasError(EmailTB) || Validation.GetHasError(PassTB) || Validation.GetHasError(RegTB))
            //{
            //    MessageBox.Show("Если есть ошибка создать не получится");
            //    return;
            //}
            if (Validation.GetHasError(TitleTB) )
            {
                MessageBox.Show("Если есть ошибка создать не получится");
                return;
            }
            if(String.IsNullOrEmpty(DescTB.Text) || String.IsNullOrEmpty(TitleTB.Text))
            {
                MessageBox.Show("Все поля должны быть заполнены");
                return;
            }

            if (isEdit)
                _service.Commit();
            else
                _service.Add(_student);
            NavigationService.Navigate(new All_InterestGrioup_Page());







        }
        private void back (object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
