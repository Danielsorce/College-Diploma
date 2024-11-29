namespace BuildUnit
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Build")]
    public partial class Build
    {
        [Key]
        public int idBuild { get; set; }

        [Required]
        public string BuildName { get; set; }

        [Required]
        [StringLength(50)]
        public string BlueprintCode { get; set; }

        public virtual ConstructionDocument ConstructionDocument { get; set; }
    }
}
