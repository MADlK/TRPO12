using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace WpfApp1.P
{
    /// <summary>
    /// Логика взаимодействия для All_InterestGrioup_Page.xaml
    /// </summary>
    public partial class All_InterestGrioup_Page :Page
    {

        public InterstGroupService IGService { get; set; } = new();
        
        public InterstGroup selectedIG { get; set; } = null;
        public All_InterestGrioup_Page ()
        {
            InitializeComponent();
        }

        private void Edit_Click (object sender, RoutedEventArgs e)
        {
            if (selectedIG != null)
                NavigationService.Navigate(new Add_InterestGroup_Page(selectedIG));
            else
                MessageBox.Show("Сначало надо выбрать гурппу интересов");

        }

        private void Add_Click (object sender, RoutedEventArgs e)
        {
            if (selectedIG != null)
                NavigationService.Navigate(new Add_InterestGroup_Page());
            else
                MessageBox.Show("Сначало надо выбрать гурппу интересов");

        }

        private void Del_Click (object sender, RoutedEventArgs e)
        {
            if (selectedIG != null)
            {
                if(MessageBox.Show("Вы действительно хотите удалить?", "Удалить", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                IGService.Remove(selectedIG);
            }
            else
                MessageBox.Show("Сначало надо выбрать гурппу интересов");
        }
    }
}
