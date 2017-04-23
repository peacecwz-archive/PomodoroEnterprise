using PomodoroEnterprise.API.EF.Tables;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PomodoroEnterprise.API.EF
{
    public class DataContext : DbContext
    {
        public DataContext():
            base("name=DbConnection")
        {
            Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public System.Data.Entity.DbSet<PomodoroEnterprise.API.EF.Tables.Task> Tasks { get; set; }

        public System.Data.Entity.DbSet<PomodoroEnterprise.API.EF.Tables.Project> Projects { get; set; }

        public System.Data.Entity.DbSet<PomodoroEnterprise.API.EF.Tables.Pomodoro> Pomodoroes { get; set; }
    }
}