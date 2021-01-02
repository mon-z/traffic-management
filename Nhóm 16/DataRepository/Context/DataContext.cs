using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace DataRepository.Context
{
    public class DataContext : DbContext
    {
        public DataContext() : base("TrichXuatCameraConnection")
        {
        }

        public DbSet<Duong> Duongs { get; set; }
        public DbSet<Camera_Backup> Camera_Backups { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

        }
    }
}
