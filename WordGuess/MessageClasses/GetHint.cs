using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordGuess.Serialization;

namespace WordGuess.MessageClasses
{
    public class GetHint : Message
    {
        public short _GameId { get; set; }

        public GetHint()
        {
            _GameId = -1;
        }

        public GetHint(short GameId)
        {
            _GameId = GameId;
        }

        protected override void InternalEncode(MemoryStream s)
        {
            base.InternalEncode(s);
            s.Write(_GameId);
        }

        protected override void InternalDecode(MemoryStream s)
        {
            base.InternalDecode(s);
            _GameId = s.ReadShort();
        }
    }
}
