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
    /// Логика взаимодействия для AddIGForUser.xaml
    /// </summary>
    public partial class AddIGForUser : Page
    {
        public InterstGroupService IGServise { get; set; } = new();
        public InterstGroup IGselected { get; set; } = new();
        public UserInterestGroupService UIGService { get; set; } = new();
        public UserInterestGroup UIG { get; set; } = new();
        public Student student { get; set; } = new();
        public AddIGForUser(Student st)
        {
            student = st;
            InitializeComponent();
            UIGService.GetAll(student.Id);

        }

        private void AddBtn_Click (object sender, RoutedEventArgs e)
        {
            InterstGroup interstGroup = (InterstGroup) IGBox.SelectedItem;
            UIG.StudentId = student.Id;
            UIG.InterestGroupId = interstGroup.Id;
            

            
            foreach(UserInterestGroup _uig in UIGService.UserInterestGroups)
            {
                if(_uig.InterestGroupId == interstGroup.Id && _uig.StudentId == student.Id)
                {
                    MessageBox.Show("Студент уже есть в этой группе");
                    return;
                }

            }


            

            UIGService.Add(UIG);
        }

        private void goBack (object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainPage());
        }
    }
}
