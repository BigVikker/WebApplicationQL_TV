namespace WebApplicationQL_TV.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BangThongTinTatCaHoaDon")]
    public class BangThongTinTatCaHoaDon
    {
        [Key]
        [StringLength(20)]
        public string maHoaDon { get; set; }
        [StringLength(20)]
        public string maPhieuYeuCau { get; set; }
        [StringLength(20)]
        public string maThuVien { get; set; }
        public bool? TrangThai { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayMuon { get; set; }
        [StringLength(50)]
        public string tenThuVien { get; set; }
        [StringLength(20)]
        public string maThe { get; set; }
        [StringLength(20)]
        public string maKH { get; set; }
        [StringLength(50)]
        public string tenKH { get; set; }
        [StringLength(20)]
        public string maNV { get; set; }
        [StringLength(50)]
        public string tenNV { get; set; }
        [StringLength(20)]
        public string maSach { get; set; }
        [StringLength(50)]
        public string tenSach { get; set; }
        public int? soLuong { get; set; }
    }
}