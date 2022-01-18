using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LearnSoftBE.Models.UnitModels
{
    [Table("Universities")]
    public class University
    {
        [Required]
        [Key]
        public int UniversityId { get; set; }

        [Required]
        public string UniversityName { get; set; } 
    }
}
