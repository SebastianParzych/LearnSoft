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

        [ForeignKey("UserId")]
        [Required]
        public User User { get; set; }

        [ForeignKey("ChatId")]
        [Required]
        public Chat Chat { get; set; }
        

    }
}
