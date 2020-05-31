namespace WebApplicationQL_TV.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<BoPhan> BoPhans { get; set; }
        public virtual DbSet<HoaDonMuon> HoaDonMuons { get; set; }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
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
        public virtual DbSet<BangTatCaNhanVienPhucVu> BangTatCaNhanVienPhucVus { get; set; }
        public virtual DbSet<BangThongTinChiTietCuaSach> BangThongTinChiTietCuaSaches { get; set; }

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
