using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LearnSoftBE.Models.UserModels;
using LearnSoftBE.Models.UnitModels;

namespace LearnSoftBE.Models.CourseModels
{
    [Table("CourseCycles")]
    public class CourseCycle
    {
        [Key]
        [Required]
        public int ClassCycleId { get; set; }

        [Required]
        public int StudentCount { get; set; }

        [Required]
        public int SemesterNumber { get; set; }

        [Required]
        [ForeignKey("InstitudeId")]
        public Institute ExeInstitute { get; set; }

        [Required]
        [ForeignKey("CourseId")]
        public Course ClassInfo { get; set; }
 
        [ForeignKey("CourseTutorId")]
        public virtual IEnumerable<CourseTutor> CourseTutorsList { get; set; }
    }
}
