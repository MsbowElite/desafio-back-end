using System;
using System.Collections.Generic;
using System.Text;

namespace Conexa.Core.Messages
{
    public abstract class Message
    {
        protected Message()
        {
            MessageType = GetType().Name;
        }

        public string MessageType { get; set; }
    }
}
