using Apple.Application.Base.Communication.Packets.Incoming;
using Apple.Application.Game.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apple.Application.Base.Communication.Packets
{
    interface IPacketEvent
    {
        void handleIncomingPacket(Player player, IncomingPacket packet);
    }
}
