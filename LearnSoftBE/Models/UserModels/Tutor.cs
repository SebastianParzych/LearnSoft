using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using LearnSoftBE.Models.CourseModels;
using LearnSoftBE.Models.UnitModels;

namespace LearnSoftBE.Models.UserModels
{
    [Table("Tutors")]
    public class Tutor : User
    {
        public string Degree { get; set; }

        public string Bio { get; set; }

        [ForeignKey("DepartmentId")]
        public Department Department { get; set; }
    }
}
