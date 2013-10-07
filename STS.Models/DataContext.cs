using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Configuration;
using STSMvc.Models.Entity;


namespace STS.Models
{
    public class DataContext : DbContext
    {
        public DataContext()
            : base(GetDbConnectionString())
        {
          
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Role>().ToTable("Roles");
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }

        private static string GetDbConnectionString()
        {
            try
            {
                return ConfigurationManager.ConnectionStrings["STSConnectionString"].ToString();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }

}
