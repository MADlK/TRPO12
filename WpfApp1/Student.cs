using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class Student : ObservableObject
    {
        private int _id;
        public int Id
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }
        private string _Name;
        public string Name
        {
            get => _Name;
            set => SetProperty(ref _Name, value);
        }
      
        
        private string _login;
        public string Login
        {
            get => _login;
            set => SetProperty(ref _login, value);
        }



        private string _email;
        public string Email
        {
            get => _email;
            set => SetProperty(ref _email, value);
        }


        private string _password;
        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }



        private DateTime _createdat = DateTime.Now;
        public DateTime CreatedAt
        {
            get => _createdat;
            set => SetProperty(ref _createdat, value);
        } 
        private UserProfile _profile;
        public UserProfile Profile
        {
            get => _profile;
            set => SetProperty(ref _profile, value);
        }








        private int _roleid;
        public int RoleId
        {
            get => _roleid;
            set => SetProperty(ref _roleid, value);
        }
        private Role _role;
        public Role Role
        {
            get => _role;
            set => SetProperty(ref _role, value);
        }
    }
}
