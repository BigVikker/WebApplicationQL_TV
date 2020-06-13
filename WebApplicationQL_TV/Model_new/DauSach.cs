namespace WebApplicationQL_TV.Model_new
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DauSach")]
    public partial class DauSach
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DauSach()
        {
            Saches = new HashSet<Sach>();
        }

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

        public virtual NgonNgu NgonNgu { get; set; }

        public virtual NhaXuatBan NhaXuatBan { get; set; }

        public virtual TacGia TacGia { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sach> Saches { get; set; }
    }
}
