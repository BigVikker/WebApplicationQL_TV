namespace WebApplicationQL_TV.Model_new
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HoaDonMuon")]
    public partial class HoaDonMuon
    {
        [StringLength(20)]
        public string maPhieuYeuCau { get; set; }

        [Key]
        [StringLength(20)]
        public string maHoaDon { get; set; }

        public bool? TrangThai { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayMuonTra { get; set; }

        [StringLength(100)]
        public string GhiChu { get; set; }

        public virtual PhieuYeuCau PhieuYeuCau { get; set; }
    }
}
