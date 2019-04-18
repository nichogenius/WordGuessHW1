using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordGuess.Serialization;

namespace WordGuess.MessageClasses
{
    public class NewGame : Message
    {
        public string _ANumber { get; set; }
        public string _LastName { get; set; }
        public string _FirstName { get; set; }
        public string _Alias { get; set; }

        public NewGame()
        {
            _ANumber = "A12345678";
            _LastName = "Hancock";
            _FirstName = "John";
            _Alias = "Hancock409";
        }
  
        public NewGame(string ANumber, string LastName, string FirstName, string Alias)
        {
            _ANumber = ANumber;
            _LastName = LastName;
            _FirstName = FirstName;
            _LastName = LastName;
        }

        protected override void InternalEncode(MemoryStream s)
        {
            base.InternalEncode(s);
            s.Write(_ANumber);
            s.Write(_LastName);
            s.Write(_FirstName);
            s.Write(_Alias);
        }

        protected override void InternalDecode(MemoryStream s)
        {
            base.InternalDecode(s);
            _ANumber = s.ReadString();
            _LastName = s.ReadString();
            _FirstName = s.ReadString();
            _Alias = s.ReadString();
        }
    }
}
