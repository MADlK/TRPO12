using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
    public partial class All_InterestGrioup_Page :Page, INotifyPropertyChanged
    {

        public InterstGroupService IGService { get; set; } = new();
        
        

        public UserInterestGroupService service { get; set; } = new();



        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged ([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }



        private InterstGroup _selectedIG;
        public InterstGroup SelectedIG
        {
            get => _selectedIG;
            set
            {
                _selectedIG = value;

                OnPropertyChanged();
            }
        }





        public All_InterestGrioup_Page ()
        {
            InitializeComponent();
        }

        private void Edit_Click (object sender, RoutedEventArgs e)
        {
            if (SelectedIG != null)
                NavigationService.Navigate(new Add_InterestGroup_Page(SelectedIG));
            else
                MessageBox.Show("Сначало надо выбрать гурппу интересов");

        }

        private void Add_Click (object sender, RoutedEventArgs e)
        {
            
                NavigationService.Navigate(new Add_InterestGroup_Page());
           

        }

        private void Del_Click (object sender, RoutedEventArgs e)
        {
            if (SelectedIG != null)
            {
                if(MessageBox.Show("Вы действительно хотите удалить?", "Удалить", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                IGService.Remove(SelectedIG);
            }
            else
                MessageBox.Show("Сначало надо выбрать гурппу интересов");
        }

        private void Back_Click (object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainPage());
        }



        
        private void ListView_SelectionChanged (object sender, SelectionChangedEventArgs e)
        {

            

            if (_selectedIG != null)
                service.GetAllStud(_selectedIG.Id);
            service.GetAllStud();
            
        }
    }
}
