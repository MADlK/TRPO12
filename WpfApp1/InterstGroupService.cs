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
    public class InterstGroupService
    {
        private readonly DBC _db = BaseDbService.Instance.Context;
        public ObservableCollection<InterstGroup> InterstGroups { get; set; } = new();
        public InterstGroupService ()
        {
            GetAll();
        }
        public void Add (InterstGroup interstGroup)
        {
            var _interestgroup = new InterstGroup
            {
                Id = interstGroup.Id,
                Title = interstGroup.Title,
                Description = interstGroup.Description,

            };
            _db.Add<InterstGroup>(_interestgroup);
            Commit();
            InterstGroups.Add(_interestgroup);
        }
        public int Commit () => _db.SaveChanges();
        public void GetAll ()
        {
            var interestgroups = _db.InterestGroups
                .Include(c => c.UserInterestGroups)
                .ThenInclude(cs => cs.Student)
                .ToList();
            InterstGroups.Clear();
            foreach (var _interestgroup in interestgroups)
            {
                InterstGroups.Add(_interestgroup);
            }


        }
        public void Remove (InterstGroup interestgroup)
        {
            _db.Remove<InterstGroup>(interestgroup);
            if (Commit() > 0)
                if (InterstGroups.Contains(interestgroup))
                    InterstGroups.Remove(interestgroup);
        }
    }
}
