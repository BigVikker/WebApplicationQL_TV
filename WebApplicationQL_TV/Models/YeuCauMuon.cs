namespace WebApplicationQL_TV.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("YeuCauMuon")]
    public partial class YeuCauMuon
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(20)]
        public string maPhieuYeuCau { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(20)]
        public string maSach { get; set; }

        public int? soLuong { get; set; }

        public virtual PhieuYeuCau PhieuYeuCau { get; set; }

        public virtual Sach Sach { get; set; }
    }
}
