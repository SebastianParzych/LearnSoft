﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using LearnSoftBE.Models.UserModels;

namespace LearnSoftBE.Models.ChatModels
{
    [Table("Messages")]
    public class Message
    {

        [Key]
        [Required]
        public int MessageId { get; set; }


        [Required]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User Sender { get; set; }

        [Required]
        public int ChatId { get; set; }
        [ForeignKey("ChatId")]
        public virtual Chat Chatroom{ get; set; }

        [Required]
        [MaxLength(1000)]
        public string Body { get; set; }

        [Required]
        public DateTime MessageDateTime { get; set; }
        
        public bool HasSeen { get; set; }
    }
}
