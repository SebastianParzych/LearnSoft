using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using LearnSoftBE.Models.UserModels;


namespace LearnSoftBE.Models.CourseModels
{
    [Table("CourseTutors")]
    public class CourseTutor
    {
        [Key]
        [Required]
        public int CourseTutorId { get; set; }
        [ForeignKey ("UserId")]
        public Tutor Tutor { get; set; }
        [ForeignKey("CourseCycleId")]
        public CourseCycle Course { get; set; }

    }
}
