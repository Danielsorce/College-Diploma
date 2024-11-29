namespace BuildUnit
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ConstructionDocument
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ConstructionDocument()
        {
            Builds = new HashSet<Build>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int numberInOrder { get; set; }

        [Key]
        [StringLength(50)]
        public string blueprintCode { get; set; }

        public int? blueprintImage { get; set; }

        public string Comment { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Build> Builds { get; set; }

        public virtual ImagePath ImagePath { get; set; }
    }
}
