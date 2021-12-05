using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class EventProvider : EventArgs
    {
        public MessageType MessageType { get; set; }

        public string Message { get; set; }

        public EventProvider(MessageType type, string message)
        {
            MessageType = type;
            Message = message;
        }
    }
}
