namespace WebApplicationQL_TV.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class maThuVien : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BangThongTinTatCaHoaDon",
                c => new
                    {
                        maHoaDon = c.String(nullable: false, maxLength: 20),
                        maPhieuYeuCau = c.String(maxLength: 20),
                        maThuVien = c.String(maxLength: 20),
                        TrangThai = c.Boolean(),
                        NgayMuon = c.DateTime(storeType: "date"),
                        tenThuVien = c.String(maxLength: 50),
                        maThe = c.String(maxLength: 20),
                        maKH = c.String(maxLength: 20),
                        tenKH = c.String(maxLength: 50),
                        maNV = c.String(maxLength: 20),
                        tenNV = c.String(maxLength: 50),
                        maSach = c.String(maxLength: 20),
                        tenSach = c.String(maxLength: 50),
                        soLuong = c.Int(),
                    })
                .PrimaryKey(t => t.maHoaDon);
            
            CreateTable(
                "dbo.BoPhan",
                c => new
                    {
                        maBP = c.String(nullable: false, maxLength: 20),
                        tenBP = c.String(maxLength: 20),
                        maTruongBP = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.maBP);
            
            CreateTable(
                "dbo.NhanVien",
                c => new
                    {
                        maNV = c.String(nullable: false, maxLength: 20),
                        tenNV = c.String(maxLength: 30),
                        ngaySinh = c.DateTime(storeType: "date"),
                        GioiTinh = c.Boolean(),
                        Luong = c.Int(),
                        SDT = c.Int(),
                        maBP = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.maNV)
                .ForeignKey("dbo.BoPhan", t => t.maBP)
                .Index(t => t.maBP);
            
            CreateTable(
                "dbo.PhieuYeuCau",
                c => new
                    {
                        maPhieuYeuCau = c.String(nullable: false, maxLength: 20),
                        maNV = c.String(maxLength: 20),
                        maThe = c.String(maxLength: 20),
                        maThuVien = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.maPhieuYeuCau)
                .ForeignKey("dbo.NhanVien", t => t.maNV)
                .ForeignKey("dbo.TheThuVien", t => t.maThe)
                .ForeignKey("dbo.ThuVien", t => t.maThuVien)
                .Index(t => t.maNV)
                .Index(t => t.maThe)
                .Index(t => t.maThuVien);
            
            CreateTable(
                "dbo.HoaDonMuon",
                c => new
                    {
                        maHoaDon = c.String(nullable: false, maxLength: 20),
                        maPhieuYeuCau = c.String(maxLength: 20),
                        TrangThai = c.Boolean(),
                        NgayMuon = c.DateTime(storeType: "date"),
                    })
                .PrimaryKey(t => t.maHoaDon)
                .ForeignKey("dbo.PhieuYeuCau", t => t.maPhieuYeuCau)
                .Index(t => t.maPhieuYeuCau);
            
            CreateTable(
                "dbo.TheThuVien",
                c => new
                    {
                        maThe = c.String(nullable: false, maxLength: 20),
                        ngayBatDau = c.DateTime(storeType: "date"),
                        GhiChu = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.maThe);
            
            CreateTable(
                "dbo.KhachHang",
                c => new
                    {
                        maKH = c.String(nullable: false, maxLength: 20),
                        tenKH = c.String(maxLength: 30),
                        SDT = c.Int(),
                        diaChi = c.String(maxLength: 50),
                        maThe = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.maKH)
                .ForeignKey("dbo.TheThuVien", t => t.maThe)
                .Index(t => t.maThe);
            
            CreateTable(
                "dbo.ThuVien",
                c => new
                    {
                        maThuVien = c.String(nullable: false, maxLength: 20),
                        tenThuVien = c.String(maxLength: 30),
                        diaDiem = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.maThuVien);
            
            CreateTable(
                "dbo.YeuCauMuon",
                c => new
                    {
                        maPhieuYeuCau = c.String(nullable: false, maxLength: 20),
                        maSach = c.String(nullable: false, maxLength: 20),
                        soLuong = c.Int(),
                    })
                .PrimaryKey(t => new { t.maPhieuYeuCau, t.maSach })
                .ForeignKey("dbo.Sach", t => t.maSach)
                .ForeignKey("dbo.PhieuYeuCau", t => t.maPhieuYeuCau)
                .Index(t => t.maPhieuYeuCau)
                .Index(t => t.maSach);
            
            CreateTable(
                "dbo.Sach",
                c => new
                    {
                        maSach = c.String(nullable: false, maxLength: 20),
                        tenSach = c.String(maxLength: 50),
                        soTrang = c.Int(),
                        namXuatBan = c.Int(),
                        giaSach = c.Int(),
                        ghiChu = c.String(maxLength: 20),
                        maNgonNgu = c.String(maxLength: 20),
                        maLoaiSach = c.String(maxLength: 20),
                        maNhaXuatBan = c.String(maxLength: 20),
                        maTacGia = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.maSach)
                .ForeignKey("dbo.LoaiSach", t => t.maLoaiSach)
                .ForeignKey("dbo.NgonNgu", t => t.maNgonNgu)
                .ForeignKey("dbo.NhaXuatBan", t => t.maNhaXuatBan)
                .ForeignKey("dbo.TacGia", t => t.maTacGia)
                .Index(t => t.maNgonNgu)
                .Index(t => t.maLoaiSach)
                .Index(t => t.maNhaXuatBan)
                .Index(t => t.maTacGia);
            
            CreateTable(
                "dbo.LoaiSach",
                c => new
                    {
                        maLoaiSach = c.String(nullable: false, maxLength: 20),
                        tenLoaiSach = c.String(maxLength: 30),
                    })
                .PrimaryKey(t => t.maLoaiSach);
            
            CreateTable(
                "dbo.NgonNgu",
                c => new
                    {
                        maNgonNgu = c.String(nullable: false, maxLength: 20),
                        ngonNgu = c.String(maxLength: 20),
                        ghiChu = c.String(maxLength: 30),
                    })
                .PrimaryKey(t => t.maNgonNgu);
            
            CreateTable(
                "dbo.NhaXuatBan",
                c => new
                    {
                        maNhaXuatBan = c.String(nullable: false, maxLength: 20),
                        tenNhaXuatBan = c.String(maxLength: 20),
                        lienHe = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.maNhaXuatBan);
            
            CreateTable(
                "dbo.TacGia",
                c => new
                    {
                        maTacGia = c.String(nullable: false, maxLength: 20),
                        tenTacGia = c.String(maxLength: 50),
                        LienHe = c.String(maxLength: 50),
                        ghiChu = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.maTacGia);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.YeuCauMuon", "maPhieuYeuCau", "dbo.PhieuYeuCau");
            DropForeignKey("dbo.YeuCauMuon", "maSach", "dbo.Sach");
            DropForeignKey("dbo.Sach", "maTacGia", "dbo.TacGia");
            DropForeignKey("dbo.Sach", "maNhaXuatBan", "dbo.NhaXuatBan");
            DropForeignKey("dbo.Sach", "maNgonNgu", "dbo.NgonNgu");
            DropForeignKey("dbo.Sach", "maLoaiSach", "dbo.LoaiSach");
            DropForeignKey("dbo.PhieuYeuCau", "maThuVien", "dbo.ThuVien");
            DropForeignKey("dbo.PhieuYeuCau", "maThe", "dbo.TheThuVien");
            DropForeignKey("dbo.KhachHang", "maThe", "dbo.TheThuVien");
            DropForeignKey("dbo.PhieuYeuCau", "maNV", "dbo.NhanVien");
            DropForeignKey("dbo.HoaDonMuon", "maPhieuYeuCau", "dbo.PhieuYeuCau");
            DropForeignKey("dbo.NhanVien", "maBP", "dbo.BoPhan");
            DropIndex("dbo.Sach", new[] { "maTacGia" });
            DropIndex("dbo.Sach", new[] { "maNhaXuatBan" });
            DropIndex("dbo.Sach", new[] { "maLoaiSach" });
            DropIndex("dbo.Sach", new[] { "maNgonNgu" });
            DropIndex("dbo.YeuCauMuon", new[] { "maSach" });
            DropIndex("dbo.YeuCauMuon", new[] { "maPhieuYeuCau" });
            DropIndex("dbo.KhachHang", new[] { "maThe" });
            DropIndex("dbo.HoaDonMuon", new[] { "maPhieuYeuCau" });
            DropIndex("dbo.PhieuYeuCau", new[] { "maThuVien" });
            DropIndex("dbo.PhieuYeuCau", new[] { "maThe" });
            DropIndex("dbo.PhieuYeuCau", new[] { "maNV" });
            DropIndex("dbo.NhanVien", new[] { "maBP" });
            DropTable("dbo.TacGia");
            DropTable("dbo.NhaXuatBan");
            DropTable("dbo.NgonNgu");
            DropTable("dbo.LoaiSach");
            DropTable("dbo.Sach");
            DropTable("dbo.YeuCauMuon");
            DropTable("dbo.ThuVien");
            DropTable("dbo.KhachHang");
            DropTable("dbo.TheThuVien");
            DropTable("dbo.HoaDonMuon");
            DropTable("dbo.PhieuYeuCau");
            DropTable("dbo.NhanVien");
            DropTable("dbo.BoPhan");
            DropTable("dbo.BangThongTinTatCaHoaDon");
        }
    }
}
