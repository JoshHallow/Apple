using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apple.Application.Base.Communication.Packets.Incoming
{
    class IncomingPacket
    {
        private readonly uint _packetId;
        private readonly byte[] _packetBody;

        public IncomingPacket(uint PacketId, byte[] PacketBody)
        {
            _packetId = PacketId;
            _packetBody = PacketBody;
        }
    }
}
