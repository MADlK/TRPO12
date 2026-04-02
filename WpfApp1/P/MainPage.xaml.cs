using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage :Page, INotifyPropertyChanged
    {

        public UserInterestGroupService UIGService { get; set; } = new();


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged ([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }



        private Student _selectedStudent;
        public Student SelectedStudent
        {
            get => _selectedStudent;
            set
            {
                _selectedStudent = value;
                
                OnPropertyChanged();
            }
        }
        
     
        public StudentSirvice service { get; set; } = new();
       
        public MainPage()
        {
            InitializeComponent();
        }
        public void go_form(object sender, EventArgs e)
        {
            NavigationService.Navigate(new StudentFormPage());
        }
        public void Edit(object sender, EventArgs e)
        {
            if (SelectedStudent == null)
            {
                MessageBox.Show("Выберите элемент из списка!");
                return;
            }
            NavigationService.Navigate(new StudentFormPage(SelectedStudent));
        }

        public void remove(object sender, EventArgs e)
        {

            if (SelectedStudent == null)
            {
                MessageBox.Show("Выберите запись!");
                return;
            }
            if (MessageBox.Show("Вы действительно хотите удалить запись?", "Удалить?",
            MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                service.Remove(SelectedStudent);
            }

        }

        private void ListView_SelectionChanged (object sender, SelectionChangedEventArgs e)
        {
            if(_selectedStudent != null)
                UIGService.GetAll(_selectedStudent.Id);
            UIGService.GetAll();
        }

        private void AddIG_Click (object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddIGForUser((Student)LV.SelectedItem));
        }

        private void GoGroup (object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new All_InterestGrioup_Page());
        }
    }
}
