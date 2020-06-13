namespace WebApplicationQL_TV.Model_new
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model2 : DbContext
    {
        public Model2()
            : base("name=Model2")
        {
        }

        public virtual DbSet<BoPhan> BoPhans { get; set; }
        public virtual DbSet<CanhCao> CanhCaos { get; set; }
        public virtual DbSet<DauSach> DauSaches { get; set; }
        public virtual DbSet<HoaDonMuon> HoaDonMuons { get; set; }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<KhoSach> KhoSaches { get; set; }
        public virtual DbSet<LoaiSach> LoaiSaches { get; set; }
        public virtual DbSet<NgonNgu> NgonNgus { get; set; }
        public virtual DbSet<NhanVien> NhanViens { get; set; }
        public virtual DbSet<NhaXuatBan> NhaXuatBans { get; set; }
        public virtual DbSet<PhieuYeuCau> PhieuYeuCaus { get; set; }
        public virtual DbSet<Sach> Saches { get; set; }
        public virtual DbSet<TacGia> TacGias { get; set; }
        public virtual DbSet<TheThuVien> TheThuViens { get; set; }
        public virtual DbSet<ThuVien> ThuViens { get; set; }
        public virtual DbSet<YeuCauMuon> YeuCauMuons { get; set; }
        public virtual DbSet<BangThongTinTatCaHoaDon> BangThongTinTatCaHoaDons { get; set; }

        public virtual DbSet<BangDauSachVaSach> BangDauSachVaSaches { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PhieuYeuCau>()
                .HasMany(e => e.YeuCauMuons)
                .WithRequired(e => e.PhieuYeuCau)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Sach>()
                .HasMany(e => e.YeuCauMuons)
                .WithRequired(e => e.Sach)
                .WillCascadeOnDelete(false);
        }
    }
}
