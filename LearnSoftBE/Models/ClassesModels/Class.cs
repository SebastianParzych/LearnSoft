using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace LearnSoftBE.Models.UserModels
{
    [Table ("Classes")]
    public class Class
    {
        [Key]
        [Required]
        public int ClassId { get; set; }
        [Required]
        public string  Name{ get; set; }
        [Required]
        public int ECTS{ get; set; }

    }
}
