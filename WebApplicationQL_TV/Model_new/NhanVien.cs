namespace WebApplicationQL_TV.Model_new
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NhanVien")]
    public partial class NhanVien
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NhanVien()
        {
            PhieuYeuCaus = new HashSet<PhieuYeuCau>();
        }

        [Key]
        [StringLength(20)]
        public string maNV { get; set; }

        [StringLength(30)]
        public string tenNV { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ngaySinh { get; set; }

        public bool? GioiTinh { get; set; }

        public int? Luong { get; set; }

        public int? SDT { get; set; }

        [StringLength(20)]
        public string maBP { get; set; }

        public virtual BoPhan BoPhan { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhieuYeuCau> PhieuYeuCaus { get; set; }
    }
}
