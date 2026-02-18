using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.DB
{
    public class DBC : DbContext
    {
        public DbSet<Student> Students { get; set; }

        protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Server=sql.ects;Database=MADBD12;User Id = student_09;" +

            //"Password = student_09;"+
            //"TrustServerCertificate = True;");

            optionsBuilder.UseSqlServer("Server=localhost;Database=MADBD12;Trusted_Connection=True;" +

            
            "TrustServerCertificate = True;");
        }
    }
}
