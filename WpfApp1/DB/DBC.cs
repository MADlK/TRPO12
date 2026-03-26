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
        public DbSet<InterstGroup> InterestGroups { get; set; }
        public DbSet<UserInterestGroup> UserInterestGroups { get; set; }
        public DbSet<UserProfile> Profiles { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=sql.ects;Database=MABD14;User Id=student_09;" +
            "Password=student_09;" +
            "TrustServerCertificate=True;");

            //optionsBuilder.UseSqlServer("Server=localhost;Database=MADBD12;Trusted_Connection=True;" +
            //"TrustServerCertificate = True;");
        }
        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasOne(s => s.Profile)
                .WithOne(ps => ps.Student)
                .HasForeignKey<UserProfile>(ps => ps.StudentId);

            modelBuilder.Entity<Role>()
                .HasMany(r => r.Students)
                .WithOne(s => s.Role)
                .HasForeignKey(s => s.RoleId);




            modelBuilder.Entity<UserInterestGroup>()
                .HasKey(uig => new { uig.StudentId, uig.InterestGroupId });

            modelBuilder.Entity<UserInterestGroup>()
                .HasOne(uig => uig.Student)
                .WithMany(s => s.UserInterestGroups)
                .HasForeignKey(cs => cs.StudentId);

            modelBuilder.Entity<UserInterestGroup>()
                .HasOne(uig => uig.InterestGroup)
                .WithMany(ig => ig.UserInterestGroups)
                .HasForeignKey(cs => cs.InterestGroupId);

        }
    }
}
