using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace BTLVinamilk.Models
{
    public partial class VinamilkDB : DbContext
    {
        public VinamilkDB()
            : base("name=VinamilkDB")
        {
        }

        public virtual DbSet<DMSUA> DMSUAs { get; set; }
        public virtual DbSet<SUA> SUAs { get; set; }
        public virtual DbSet<TAIKHOAN> TAIKHOANs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DMSUA>()
                .Property(e => e.IDDM)
                .IsFixedLength();

            modelBuilder.Entity<DMSUA>()
                .Property(e => e.AnhDM)
                .IsUnicode(false);

            modelBuilder.Entity<SUA>()
                .Property(e => e.GiaBan)
                .HasPrecision(19, 4);

            modelBuilder.Entity<SUA>()
                .Property(e => e.IDDM)
                .IsFixedLength();

            modelBuilder.Entity<TAIKHOAN>()
                .Property(e => e.Ten)
                .IsFixedLength();

            modelBuilder.Entity<TAIKHOAN>()
                .Property(e => e.MatKhau)
                .IsFixedLength();

            modelBuilder.Entity<TAIKHOAN>()
                .Property(e => e.QuenTC)
                .IsFixedLength();
        }
    }
}
