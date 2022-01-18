using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LearnSoftBE.Models.UnitModels
{
    [Table("Institutes")]
    public class Institute
    {
        [Required]
        [Key]
        public int InstitudeId { get; set; }

        [Required]
        public string InstituteName { get; set; }

        [ForeignKey("UniversityId")]
        [Required]
        public  University University{ get; set; }
    }
}
