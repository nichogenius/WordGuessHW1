using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordGuess.Serialization;

namespace WordGuess.MessageClasses
{
    public class Hint : Message
    {
        public short _GameId { get; set; }
        public string _Hint { get; set; }

        public Hint()
        {
            _GameId = -1;
            _Hint = "6 X 7";
        }

        public Hint(short GameId, string Hint)
        {
            _GameId = GameId;
            _Hint = Hint;
        }

        protected override void InternalEncode(MemoryStream s)
        {
            base.InternalEncode(s);
            s.Write(_GameId);
            s.Write(_Hint);
        }

        protected override void InternalDecode(MemoryStream s)
        {
            base.InternalDecode(s);
            _GameId = s.ReadShort();
            _Hint = s.ReadString();
        }
    }
}
