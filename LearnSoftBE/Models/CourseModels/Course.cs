using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace LearnSoftBE.Models.CourseModels
{
    [Table ("Courses")]
    public class Course
    {
        [Key]
        [Required]
        public int CourseId { get; set; }

        [Required]
        public string  Name{ get; set; }

        [Required]
        public int ECTS{ get; set; }

        [Required]
        public int NumberOfHours{ get; set; }
 
    }
}
