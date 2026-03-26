using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class UserProfile: ObservableObject
    {
        private int _id;
        public int Id 
        {
            get => _id;
            set
            {
                
                SetProperty(ref _id, value);
            }
        }

        private string _avatarUrl;
        public string AvatarUrl
        {
            get => _avatarUrl;
            set => SetProperty(ref _avatarUrl, value);
        }

        

        private int _phone;
        public int Phone
        {
            get => _phone;
            set
            {

                SetProperty(ref _phone, value);
            }
        }

        private string _Birthday = DateTime.Today.ToString();
        public string Birthday
        {
            get => _Birthday;
            set
            {

                SetProperty(ref _Birthday, value);
            }
        }


        private string _Bio;
        public string Bio
        {
            get => _Bio;
            set
            {

                SetProperty(ref _Bio, value);
            }
        }

        private int _studentid;
        public int StudentId
        {
            get => _studentid;
            set
            {

                SetProperty(ref _studentid, value);
            }
        }

        private Student _student;
        public Student Student
        {
            get => _student;
            set
            {

                SetProperty(ref _student, value);
            }
        }



    }
}
