using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WordGuess.Serialization
{
    public static class StreamMethodExtension
    {
        // Shamelessly copied from Example code - StreamExtension.cs

        public static void Write(this Stream memoryStream, byte value)
        {
            memoryStream.WriteByte(value);
        }

        public static void Write(this Stream memoryStream, short value)
        {
            var bytes = BitConverter.GetBytes(IPAddress.HostToNetworkOrder(value));
            memoryStream.Write(bytes, 0, bytes.Length);
        }

        public static void Write(this Stream memoryStream, int value)
        {
            var bytes = BitConverter.GetBytes(IPAddress.HostToNetworkOrder(value));
            memoryStream.Write(bytes, 0, bytes.Length);
        }

        public static void Write(this Stream memoryStream, long value)
        {
            var bytes = BitConverter.GetBytes(IPAddress.HostToNetworkOrder(value));
            memoryStream.Write(bytes, 0, bytes.Length);
        }

        public static void Write(this Stream memoryStream, string value)
        {
            if (value == null)
                value = string.Empty;

            var bytes = Encoding.BigEndianUnicode.GetBytes(value);
            Write(memoryStream, (short)bytes.Length);
            memoryStream.Write(bytes, 0, bytes.Length);
        }

        public static byte ReadOneByte(this Stream stream)
        {
            var oneByte = stream.ReadByte();
            if (oneByte == -1)
                throw new ApplicationException("Cannot read byte from input stream");
            return (byte)oneByte;
        }

        public static short ReadShort(this Stream stream)
        {
            var bytes = new byte[2];
            var bytesRead = stream.Read(bytes, 0, bytes.Length);
            if (bytesRead != bytes.Length)
                throw new ApplicationException("Cannot decode a short integer from message");

            return IPAddress.NetworkToHostOrder(BitConverter.ToInt16(bytes, 0));
        }

        public static int ReadInt(this Stream stream)
        {
            var bytes = new byte[4];
            var bytesRead = stream.Read(bytes, 0, bytes.Length);
            if (bytesRead != bytes.Length)
                throw new ApplicationException("Cannot decode an integer from message");

            return IPAddress.NetworkToHostOrder(BitConverter.ToInt32(bytes, 0));
        }

        public static long ReadLong(this Stream stream)
        {
            var bytes = new byte[8];
            var bytesRead = stream.Read(bytes, 0, bytes.Length);
            if (bytesRead != bytes.Length)
                throw new ApplicationException("Cannot decode a long integer from message");

            return IPAddress.NetworkToHostOrder(BitConverter.ToInt64(bytes, 0));
        }

        public static string ReadString(this Stream stream)
        {
            var result = string.Empty;
            var length = ReadShort(stream);
            if (length <= 0) return result;

            var bytes = new byte[length];
            var bytesRead = stream.Read(bytes, 0, bytes.Length);
            if (bytesRead != length)
                throw new ApplicationException("Cannot decode a string from message");

            result = Encoding.BigEndianUnicode.GetString(bytes, 0, bytes.Length);
            return result;
        }

    }
}
