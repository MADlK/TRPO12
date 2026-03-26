using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class UserInterestGroup :ObservableObject
    {
        private int _StudentId;
        public int StudentId
        {
            get { return _StudentId; }
            set
            {
                SetProperty(ref _StudentId, value);
            }
        }

        private Student _student;
        public Student Student
        {
            get { return _student; }
            set
            {
                SetProperty(ref _student, value);
            }
        }

        private int _InterestGroupId;
        public int InterestGroupId
        {
            get { return _InterestGroupId; }
            set
            {
                SetProperty(ref _InterestGroupId, value);
            }
        }

        private InterstGroup _InterestGroup;
        public InterstGroup InterestGroup
        {
            get { return _InterestGroup; }
            set
            {
                SetProperty(ref _InterestGroup, value);
            }
        }

        private DateOnly _JoinedAt;
        public DateOnly JoinedAt
        {
            get { return _JoinedAt; }
            set
            {
                SetProperty(ref _JoinedAt, value);

            }
        }


        private bool _IsModerator;
        public bool IsModerator
        {
            get { return _IsModerator; }
            set
            {
                SetProperty(ref _IsModerator, value);

            }
        }
    }
}