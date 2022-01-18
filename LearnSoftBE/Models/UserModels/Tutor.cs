using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using LearnSoftBE.Models.CourseModels;


namespace LearnSoftBE.Models.UserModels
{
    [Table("Tutors")]
    public class Tutor : User
    {
        public string Degree { get; set; }

        public string Bio { get; set; }

        [ForeignKey("CourseTutorId")]
        public virtual IEnumerable<CourseTutor> AsignedCoursesList { get; set; }

    }
}
