namespace WebApplicationQL_TV.Model_new
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Sach")]
    public partial class Sach
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sach()
        {
            YeuCauMuons = new HashSet<YeuCauMuon>();
        }

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
        public string maLoaiSach { get; set; }

        [StringLength(20)]
        public string maDauSach { get; set; }

        [StringLength(20)]
        public string maKhoSach { get; set; }

        public virtual DauSach DauSach { get; set; }

        public virtual KhoSach KhoSach { get; set; }

        public virtual LoaiSach LoaiSach { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<YeuCauMuon> YeuCauMuons { get; set; }
    }
}
