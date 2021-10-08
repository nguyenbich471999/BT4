using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace BT4.Models
{
    public partial class LapTrinhQuanLyDBcontext : DbContext
    {
        public LapTrinhQuanLyDBcontext()
            : base("name=LapTrinhQuanLyDBcontext")
        {
        }

        public virtual DbSet<Acount> Acounts { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Person> Persons { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Acount>()
                .Property(e => e.Password)
                .IsUnicode(false);
        }
    }
}
