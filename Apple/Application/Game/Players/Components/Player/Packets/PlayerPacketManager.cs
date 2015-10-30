using Apple.Application.Base.Communication.Packets.Incoming;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Apple.Application.Game.Players;

namespace Apple.Application.Game.Players
{
    class PlayerPacketManager
    {
        public void ExecuteIncomingPacket(Player player, IncomingPacket Packet)
        {
            if (Packet.PacketId == IncomingHeaders.SSOTicketMessageEvent && _authed)
            {
                return;
            }

            if (Packet.PacketId == IncomingHeaders.SSOTicketMessageEvent)
            {
                this._authed = true;
            }

            Mango.GetServer().GetPacketManager().ExecutePacket(Session, Packet);
        }
    }
}
