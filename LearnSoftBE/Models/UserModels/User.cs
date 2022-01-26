using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using LearnSoftBE.Models.CourseModels;
using LearnSoftBE.Models.ChatModels;
using LearnSoftBE.Models.UnitModels;

namespace LearnSoftBE.Models.UserModels
{
    [Table("Users")]
    public class User
    {
        [Key]
        [Required]
        public int UserId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        public DateTime DateBirth { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Email { get; set; }

        [ForeignKey("UserUnitId")]
        public  IEnumerable< UserUnit> UserUnits{ get; set; }

        public virtual IEnumerable<Message> MessageSend { get; set; }
        public virtual IEnumerable<Message> MessageRecieved { get; set; }

        public byte[] Image { get; set; }
    }
}
