
namespace WebApplicationQL_TV.Model_new
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public class BangDauSachVaSach
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
       

        [Key]
        [StringLength(20)]
        public string maDauSach { get; set; }

        [StringLength(100)]
        public string tenDauSach { get; set; }

        [StringLength(20)]
        public string maTacGia { get; set; }

        [StringLength(20)]
        public string maNgonNgu { get; set; }

        [StringLength(20)]
        public string maNhaXuatBan { get; set; }
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
        public string maLoaiSach { get; set; }

        [StringLength(20)]
        public string maKhoSach { get; set; }


    }
}