using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class EventProtocolMessage : EventArgs
    {
        public MessageType MessageType { get; set; }

        public string Message { get; set; }

        public EventProtocolMessage(MessageType type, string message)
        {
            MessageType = type;
            Message = message;
        }
    }
}
