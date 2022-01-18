using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using LearnSoftBE.Models.UserModels;

namespace LearnSoftBE.Models.ChatModels
{
    [Table("Chats")]
    public class Chat
    {

        [Key]
        [Required]
        public int ChatId { get; set; }

        [ForeignKey("MessageId")]
        public  virtual IEnumerable <Message> MessagesList { get; set; }

        [ForeignKey("UserChatId")]
        [Required]
        public virtual IEnumerable <User>  ChatUsers { get; set; }

        public string ChatName { get; set; }

    }
}
