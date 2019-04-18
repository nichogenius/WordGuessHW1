using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordGuess.Serialization;

namespace WordGuess.MessageClasses
{
    public class Answer : Message
    {
        public short _GameId { get; set; }
        public byte _Result { get; set; }
        public short _Score { get; set; }
        public string _Hint { get; set; }

        public Answer()
        {
            _GameId = -1;
            _Result = 42;
            _Score = 100;
            _Hint = "This hint is fake.";
        }

        public Answer(short GameId, byte Result, short Score, string Hint)
        {
            _GameId = GameId;
            _Result = Result;
            _Score = Score;
            _Hint = Hint;
        }

        protected override void InternalEncode(MemoryStream s)
        {
            base.InternalEncode(s);
            s.Write(_GameId);
            s.Write(_Result);
            s.Write(_Score);
            s.Write(_Hint);
        }

        protected override void InternalDecode(MemoryStream s)
        {
            base.InternalDecode(s);
            _GameId = s.ReadShort();
            _Result = (byte)s.ReadByte();
            _Score = s.ReadShort();
            _Hint = s.ReadString();
        }
    }
}
