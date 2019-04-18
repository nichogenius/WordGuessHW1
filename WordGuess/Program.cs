using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using WordGuess.MessageClasses;
using WordGuess.Serialization;

namespace WordGuess
{
    class Program
    {
        static void Main(string[] args)
        {
            IPAddress remoteIp = IPAddress.Parse("107.182.239.23");
            int remotePort = 12001;
            int localPort = 13001;
            IPEndPoint remote = new IPEndPoint(remoteIp, 12001);
            IPEndPoint local = new IPEndPoint(IPAddress.Any, localPort);
            UdpClient c = new UdpClient(local) { Client = { ReceiveTimeout = 1000 } };
            Message m = new NewGame();
            byte[] bytes = m.Encode();
            c.Send(bytes, bytes.Length, remote);
            
            byte[] reply = c.Receive(ref remote);
            c.Close();
            Message response = Message.Decode(reply);
            Console.WriteLine(response.MessageType);
            
            Console.ReadLine();
        }
    }
}
