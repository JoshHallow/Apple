using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apple.Application.Base.Communication.Packets.Incoming
{
    class IncomingPacket
    {
        private readonly int _packetId;
        private readonly byte[] _packetBody;

        public IncomingPacket(int PacketId, byte[] PacketBody)
        {
            _packetId = PacketId;
            _packetBody = PacketBody;
        }

        public int PacketId
        {
            get { return _packetId; }
        }
    }
}
