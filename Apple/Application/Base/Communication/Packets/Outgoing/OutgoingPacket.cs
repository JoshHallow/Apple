using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apple.Application.Base.Communication.Packets.Outgoing
{
    class OutgoingPacket
    {
        private readonly Encoding Encoding = Encoding.Default;
        private readonly int _packetId; 
        private List<byte> Body = new List<byte>();

        public OutgoingPacket(int id)
        {
            _packetId = PacketId;
            WriteShort(id);
        }

        public int PacketId
        {
            get { return _packetId; }
        }

        internal void WriteBytes(byte[] b, bool IsInt) // d
        {
            if (IsInt)
            {
                for (int i = (b.Length - 1); i > -1; i--)
                {
                    Body.Add(b[i]);
                }
            }
            else
            {
                Body.AddRange(b);
            }
        }

        public void WriteRawString(string s)
        {
            this.Body.AddRange(Encoding.GetBytes(s));
        }

        public void WriteDouble(double d) // d
        {
            string Raw = Math.Round(d, 1).ToString();

            if (Raw.Length == 1)
            {
                Raw += ".0";
            }

            WriteString(Raw.Replace(',', '.'));
        }

        public void WriteString(string s) // d
        {
            WriteShort(s.Length);
            WriteBytes(Encoding.GetBytes(s), false);
        }

        public void WriteShort(int s) // d
        {
            Int16 i = (Int16)s;
            WriteBytes(BitConverter.GetBytes(i), true);
        }

        public void WriteInteger(int i) // d
        {
            WriteBytes(BitConverter.GetBytes(i), true);
        }

        public void WriteRawInteger(int i) // d
        {
            WriteString(i.ToString());
        }

        public void WriteBoolean(bool b) // d
        {
            WriteBytes(new byte[] { (byte)(b ? 1 : 0) }, false);
        }

        public byte[] GetBytes()
        {
            List<byte> Final = new List<byte>();
            Final.AddRange(BitConverter.GetBytes(Body.Count)); // packet len
            Final.Reverse();
            Final.AddRange(Body); // Add Packet
            return Final.ToArray();
        }
    }
}
