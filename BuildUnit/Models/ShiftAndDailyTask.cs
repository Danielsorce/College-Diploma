namespace BuildUnit
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ShiftAndDailyTask")]
    public partial class ShiftAndDailyTask
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int workNumber { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idTask { get; set; }

        public int typeOfWork { get; set; }

        public int idBuild { get; set; }

        public int Employeer { get; set; }

        public DateTime? dateOfTheTask { get; set; }

        public DateTime? dateOfComplete { get; set; }

        public virtual Staff Staff { get; set; }

        public virtual Task Task { get; set; }

        public virtual TypeOfWork TypeOfWork1 { get; set; }
    }
}
