namespace WebApplicationQL_TV.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BangTatCaNhanVienPhucVu")]
    public partial class BangTatCaNhanVienPhucVu
    {
        public int? Luong { get; set; }

        [Key]
        [StringLength(20)]
        public string maBP { get; set; }

        [StringLength(20)]
        public string tenBP { get; set; }
    }
}
