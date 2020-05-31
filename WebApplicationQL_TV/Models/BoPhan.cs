namespace WebApplicationQL_TV.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BoPhan")]
    public partial class BoPhan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BoPhan()
        {
            NhanViens = new HashSet<NhanVien>();
        }

        [Key]
        [StringLength(20)]
        public string maBP { get; set; }

        [StringLength(20)]
        public string tenBP { get; set; }

        [StringLength(20)]
        public string maTruongBP { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NhanVien> NhanViens { get; set; }
    }
}
