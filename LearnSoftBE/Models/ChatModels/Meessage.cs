using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LearnSoftBE.Models.ChatModels
{
    [Table("Messages")]
    public class Meessage
    {
        [Key]
        [Required]
        public int MessageId { get; set; }


        [Required]
        [MaxLength(1000)]
        public string Body { get; set; }
    }
}
