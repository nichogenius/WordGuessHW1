using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordGuess.Serialization;

namespace WordGuess.MessageClasses
{
    public class GameDef : Message
    {
        public short _GameId { get; set; }
        public string _Hint { get; set; }
        public string _Definition { get; set; }

        public GameDef()
        {
            _GameId = -1;
            _Hint = "6 x 7";
            _Definition = "THe answer to life, the universe, and everything.";
        }

        public GameDef(short GameId, string Hint, string Definition)
        {
            _GameId = GameId;
            _Hint = Hint;
            _Definition = Definition;
        }

        protected override void InternalEncode(MemoryStream s)
        {
            base.InternalEncode(s);
            s.Write(_GameId);
            s.Write(_Hint);
            s.Write(_Definition);
        }

        protected override void InternalDecode(MemoryStream s)
        {
            base.InternalDecode(s);
            _GameId = s.ReadShort();
            _Hint = s.ReadString();
            _Definition = s.ReadString();
        }
    }
}
