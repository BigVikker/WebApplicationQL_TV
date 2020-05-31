namespace WebApplicationQL_TV.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NgonNgu")]
    public partial class NgonNgu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NgonNgu()
        {
            Saches = new HashSet<Sach>();
        }

        [Key]
        [StringLength(20)]
        public string maNgonNgu { get; set; }

        [Column("ngonNgu")]
        [StringLength(20)]
        public string ngonNgu1 { get; set; }

        [StringLength(30)]
        public string ghiChu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sach> Saches { get; set; }
    }
}
