using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearnSoftBE.Dtos
{
    public class MessageDto
    {
        public int SenderId { get; set; }
        public int RecieverId { get; set; }
        public string Body { get; set; }
        public DateTime MessageDateTime { get; set; } = DateTime.Now;
        public bool HasSeen { get; set; }
    }
    public class ReturnMessageDto :  MessageDto
    {
        public int MessageId { get; set; }
    }
}
