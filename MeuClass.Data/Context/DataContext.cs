using MeuClass.Entity.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuClass.Data.Context
{
    public class DataContext : DbContext
    {
        public DataContext() : base("name=DataContext")
        {
            
        }

        public virtual DbSet<User> User { get; set; }

        public virtual DbSet<UserFollow> UserFollow { get; set; }

        public virtual DbSet<Department> Department { get; set; }

        public virtual DbSet<UserType> UserType { get; set; }

        public virtual DbSet<BlockedUser> BlockedUser { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
        }

    }
}
