namespace WebApplicationQL_TV.Model_new
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhieuYeuCau")]
    public partial class PhieuYeuCau
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PhieuYeuCau()
        {
            HoaDonMuons = new HashSet<HoaDonMuon>();
            YeuCauMuons = new HashSet<YeuCauMuon>();
        }

        [Key]
        [StringLength(20)]
        public string maPhieuYeuCau { get; set; }

        [StringLength(20)]
        public string maNV { get; set; }

        [StringLength(20)]
        public string maThe { get; set; }

        [StringLength(20)]
        public string maThuVien { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HoaDonMuon> HoaDonMuons { get; set; }

        public virtual NhanVien NhanVien { get; set; }

        public virtual TheThuVien TheThuVien { get; set; }

        public virtual ThuVien ThuVien { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<YeuCauMuon> YeuCauMuons { get; set; }
    }
}
