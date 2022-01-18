using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using LearnSoftBE.Models.UserModels;

namespace LearnSoftBE.Models.ChatModels
{
    public class Conversation
    {
        [Key]
        [Required]
        public int ConversationId { get; set; }
        [Required]
        public User HostUser { get; set; }
        [Required]
        public User ParticipantUser { get; set; }
        public IEnumerable<Meessage> Meessages { get; set; }
    }
}
