namespace WebApplicationQL_TV.Model_new
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KhoSach")]
    public partial class KhoSach
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KhoSach()
        {
            Saches = new HashSet<Sach>();
        }

        [Key]
        [StringLength(20)]
        public string maKhoSach { get; set; }

        [StringLength(100)]
        public string tenKhoSach { get; set; }

        [StringLength(100)]
        public string ViTri { get; set; }

        [StringLength(100)]
        public string GhiChu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sach> Saches { get; set; }
    }
}
