using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using LearnSoftBE.Models.CourseModels;


namespace LearnSoftBE.Models.UserModels
{
    [Table("Students")]
    public class Student : User
    {
        public int IndexNumber{ get; set; }

        [ForeignKey("CourseAssignmentId")]
        public virtual IEnumerable <CourseAssignment> AssigmentCourseList { get; set; }
        

    }
}
