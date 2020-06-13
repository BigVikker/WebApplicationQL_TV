namespace WebApplicationQL_TV.Model_new
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KhachHang")]
    public partial class KhachHang
    {
        [Key]
        [StringLength(20)]
        public string maKH { get; set; }

        [StringLength(30)]
        public string tenKH { get; set; }

        public int? SDT { get; set; }

        [StringLength(50)]
        public string diaChi { get; set; }

        [StringLength(20)]
        public string maThe { get; set; }

        public virtual TheThuVien TheThuVien { get; set; }
    }
}
