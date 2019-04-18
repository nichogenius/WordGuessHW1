using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordGuess.Serialization;

namespace WordGuess.MessageClasses
{
    public abstract class Message
    {
        public byte MessageType 
        {
            get { return MessageTypes.GetTypeNumber(this.GetType()); }
        }

        public Message() { }

        public byte[] Encode()
        {
            MemoryStream s = new MemoryStream();
            this.InternalEncode(s);
            return s.ToArray();
        }

        public static Message Decode(byte[] bytes)
        {
            Type t = MessageTypes.GetTypeClass(bytes[0]);
            Message m = Activator.CreateInstance(t) as Message;
            m.InternalDecode(new MemoryStream(bytes));
            return m;
        }

        protected virtual void InternalEncode(MemoryStream s)
        {
            s.Write(MessageType);
        }

        protected virtual void InternalDecode(MemoryStream s)
        {
            s.ReadOneByte(); // Consume the type byte - no need not store it
        }
    }
}
