using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearnSoftBE.Dtos
{
    public class MessageDto
    {
        public int UserId { get; set; }
        public int ChatId { get; set; }
        public string Body { get; set; }
        public DateTime MessageDateTime { get; set; } = DateTime.Now;
        public bool HasSeen { get; set; } = false;
    }
}
