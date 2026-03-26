using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class InterstGroup: ObservableObject
    {
        private int _id;
        public int Id
        {
            get { return _id; }
            set
            {
                SetProperty(ref _id, value);
            }
        }
        private string _title;
        public string Title
        {
            get { return _title; }
            set
            {
                SetProperty(ref _title, value);
            }
        }
        private string _description;
        public string Description
        {
            get { return _description; }
            set
            {
                SetProperty(ref _description, value);
            }
        }

        private ObservableCollection<UserInterestGroup> _UserInterestGroups;
        public ObservableCollection<UserInterestGroup> UserInterestGroups
        {
            get => _UserInterestGroups;
            set => SetProperty(ref _UserInterestGroups, value);
        }
    }
}
