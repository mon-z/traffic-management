using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using DataRepository.entity;

namespace DataRepository.Context
{
    public class DataContext : DbContext
    {
        public DataContext() : base("ChotGTConnection")
        {
        }

        public DbSet<Duong> Duong { get; set; }
        public DbSet<Camera_Backup> Camera_Backup { get; set; }

        public DbSet<Camera> Camera { get; set; }
        public DbSet<ChotGiaoThong> ChotGiaoThong { get; set; }
        public DbSet<CT_Duong> CT_Duong { get; set; }
        public DbSet<CTDenGiaoThong> CTDenGiaoThong { get; set; }
        public DbSet<DenGiaoThong> DenGiaoThong { get; set; }

        public DbSet<NgaDuong> NgaDuong { get; set; }
        public DbSet<TraCuuThongTin> TraCuuThongTin { get; set; }

        public DbSet<DonCongAn> DonCongAn { get; set; }
        public DbSet<CongAn> CongAn { get; set; }
        public DbSet<Dan> Dans { get; set; }
        public DbSet<DanDangKy> DanDangKies { get; set; }
        public DbSet<Luat> Luats { get; set; }
        public DbSet<Xe> Xes { get; set; }
        public DbSet<XeDangKy> XeDangKies { get; set; }
        public DbSet<DoiChuXe> DoiChuXes { get; set; }
        public DbSet<ViPham> ViPhams { get; set; }
        public DbSet<ViPhamLuat> ViPhamLuats { get; set; }
        public DbSet<PhieuNopPhat> PhieuNopPhats { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

        }
    }
}
