namespace WebApplicationQL_TV.Model_new
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CanhCao")]
    public partial class CanhCao
    {
        [Key]
        [StringLength(20)]
        public string maViPham { get; set; }

        [StringLength(50)]
        public string tenViPham { get; set; }

        [StringLength(20)]
        public string maThe { get; set; }

        [StringLength(100)]
        public string ghiChu { get; set; }

        public bool? TrangThai { get; set; }

        public virtual TheThuVien TheThuVien { get; set; }
    }
}
