using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordGuess.Serialization;

namespace WordGuess.MessageClasses
{
    public class Guess : Message
    {
        public short _GameId { get; set; }
        public string _Guess { get; set; }

        public Guess()
        {
            _GameId = -1;
            _Guess = "42";
        }

        public Guess(short GameId, string Guess)
        {
            _GameId = GameId;
            _Guess = Guess;
        }

        protected override void InternalEncode(MemoryStream s)
        {
            base.InternalEncode(s);
            s.Write(_GameId);
            s.Write(_Guess);
        }

        protected override void InternalDecode(MemoryStream s)
        {
            base.InternalDecode(s);
            _GameId = s.ReadShort();
            _Guess = s.ReadString();
        }
    }
}
