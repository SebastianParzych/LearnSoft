using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using LearnSoftBE.Models.UserModels;


namespace LearnSoftBE.Models.CourseModels
{
    [Table("CourseAssignment")]
    public class CourseAssignment
    {
        [Key]
        [Required]
        public int CourseAssignmentId { get; set; }
        [Required]
        public int CourseCycleId { get; set; }
        [Required]
        [ForeignKey("CourseCycleId")]
        public CourseCycle AssigmentCourse { get; set; }

        [Required]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual Student AssigmentUser { get; set; }
        public float WeightedMark { get; set; }
        public float FinalMark { get; set; }

    }
}
