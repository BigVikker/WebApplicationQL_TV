namespace WebApplicationQL_TV.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BangThongTinChiTietCuaSach")]
    public partial class BangThongTinChiTietCuaSach
    {
        [Key]
        [StringLength(20)]
        public string maSach { get; set; }

        [StringLength(50)]
        public string tenSach { get; set; }

        public int? soTrang { get; set; }

        public int? namXuatBan { get; set; }

        public int? giaSach { get; set; }

        [StringLength(20)]
        public string ghiChu { get; set; }

        [StringLength(20)]
        public string ngonNgu { get; set; }

        [StringLength(30)]
        public string tenLoaiSach { get; set; }

        [StringLength(20)]
        public string tenNhaXuatBan { get; set; }

        [StringLength(50)]
        public string tenTacGia { get; set; }
    }
}
