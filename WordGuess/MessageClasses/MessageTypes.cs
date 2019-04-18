using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordGuess.MessageClasses
{
    public class MessageTypes
    {
        private static readonly List<Type> types = new List<Type> {
                 typeof(Message),
                 typeof(NewGame),
                 typeof(GameDef),
                 typeof(Guess),
                 typeof(Answer),
                 typeof(GetHint),
                 typeof(Hint),
                 typeof(Exit),
                 typeof(Ack),
                 typeof(Error),
                 typeof(Heartbeat)
            };

        public static Type GetTypeClass(short id)
        {
            return types[id];
        }

        public static byte GetTypeNumber(Type type)
        {
            return (byte)types.IndexOf(type);
        }
    }
}
