namespace WebApplicationQL_TV.Models
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
        public string maNgonNgu { get; set; }

        [StringLength(20)]
        public string maLoaiSach { get; set; }

        [StringLength(20)]
        public string maNhaXuatBan { get; set; }

        [StringLength(20)]
        public string maTacGia { get; set; }

        public virtual LoaiSach LoaiSach { get; set; }

        public virtual NgonNgu NgonNgu { get; set; }

        public virtual NhaXuatBan NhaXuatBan { get; set; }

        public virtual TacGia TacGia { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<YeuCauMuon> YeuCauMuons { get; set; }
    }
}
