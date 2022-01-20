using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using LearnSoftBE.Models.UserModels;


namespace LearnSoftBE.Models.ChatModels
{
    [Table("UserChats")]
    public class UserChat
    {   
        [Key]
        [Required]
        public int UserChatId { get; set; }

        [Required]
        public int UserId { get; set; }


        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        [Required]
        public int ChatId { get; set; }

        [ForeignKey("ChatId")]
        public virtual Chat Chat { get; set; }

    }
}
