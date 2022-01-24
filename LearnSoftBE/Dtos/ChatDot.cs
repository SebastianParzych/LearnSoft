using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearnSoftBE.Dtos
{
    public class ChatRequestDot
    {

        public int ChatId { get; set; }
        public string ChatName { get; set; } 

        public IEnumerable<UserChatDot> Participants { get; set; }

    }
    public class UserChatDot
    {
        public int UserId { get; set; }
    }

    public class ChatResponseDot
    {
        public int ChatId { get; set; }
        public IEnumerable<int> UserIds { get; set; }

    }
}
