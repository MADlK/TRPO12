using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.DB;

namespace WpfApp1
{
    public class UserInterestGroupService
    {
        private readonly DBC _db = BaseDbService.Instance.Context;
        public ObservableCollection<UserInterestGroup> UserInterestGroups{ get; set; } = new();
        public UserInterestGroupService ()
        {
            
        }
        public void Add (UserInterestGroup UIG)
        {
            var _uig = new UserInterestGroup
            {
                
                StudentId = UIG.StudentId,
                Student = UIG.Student,
                InterestGroupId = UIG.InterestGroupId,
                InterestGroup= UIG.InterestGroup,
                JoinedAt = UIG.JoinedAt,
                IsModerator = UIG.IsModerator,

            };
            _db.Add<UserInterestGroup>(_uig);
            
            UserInterestGroups.Add(_uig);
            Commit();
            _db.SaveChanges();
        }
        public int Commit () => _db.SaveChanges();
        public void GetAll (int ID)
        {
            var uid = _db.UserInterestGroups
                .Include(c => c.InterestGroup)
                .Include(c => c.Student)
                .ThenInclude(cs => cs.Profile)
                .Include(c => c.Student)
                .ThenInclude(cs => cs.Role)
                
                .ToList();
                
            UserInterestGroups.Clear();
            foreach (var _uid in uid)
            {
                if(_uid.StudentId == ID)
                UserInterestGroups.Add(_uid);
            }
        }
        public void Remove (UserInterestGroup UserInterestGrop)
        {
            _db.Remove<UserInterestGroup>(UserInterestGrop);
            if (Commit() > 0)
                if (UserInterestGroups.Contains(UserInterestGrop))
                    UserInterestGroups.Remove(UserInterestGrop);
        }
    }
}
