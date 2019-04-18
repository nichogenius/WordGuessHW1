using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordGuess.Serialization;

namespace WordGuess.MessageClasses
{
    public class Error : Message
    {
        public short _GameId { get; set; }
        public string _Text { get; set; }

        public Error()
        {
            _GameId = -1;
            _Text = "404 - Not Found";
        }

        public Error(short GameId, string Text)
        {
            _GameId = GameId;
            _Text = Text;
        }

        protected override void InternalEncode(MemoryStream s)
        {
            base.InternalEncode(s);
            s.Write(_GameId);
            s.Write(_Text);
        }

        protected override void InternalDecode(MemoryStream s)
        {
            base.InternalDecode(s);
            _GameId = s.ReadShort();
            _Text = s.ReadString();
        }
    }
}
