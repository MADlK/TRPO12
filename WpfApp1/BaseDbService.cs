using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.DB;

namespace WpfApp1
{
    internal class BaseDbService
    {
        private BaseDbService ()
        {
            context = new DBC();
        }
        private static BaseDbService? instance;
        public static BaseDbService Instance
        {

            get
            {
                if (instance == null)
                    instance = new BaseDbService();
                return instance;
            }
        }
        private DBC context;
        public DBC Context => context;
    }
}
