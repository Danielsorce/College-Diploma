namespace BuildUnit
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Task
    {
        [Key]
        public int idTask { get; set; }

        [Required]
        public string nameOfTask { get; set; }

        public int idDetail { get; set; }

        [Required]
        [StringLength(50)]
        public string numberOfDetails { get; set; }

        [Required]
        [StringLength(50)]
        public string numberOfHours { get; set; }

        public virtual Detail Detail { get; set; }

        public virtual ShiftAndDailyTask ShiftAndDailyTask { get; set; }
    }
}
