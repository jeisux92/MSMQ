using System;

namespace MSMQ.Models
{
    [Serializable]
    public class MessageMq
    {
        public string Content { get; set; }
        public string Tag { get; set; }
    }
}
