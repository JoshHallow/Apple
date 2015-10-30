using Apple.Application.Base.Communication.Packets.Outgoing.Composers.Handshake;
using Apple.Application.Game.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apple.Application.Base.Communication.Packets.Incoming.Events.Handshake
{
    class InitCryptoEvent : IPacketEvent
    {
        public void handleIncomingPacket(Player player, IncomingPacket packet)
        {
            player.SendPacket(new InitCryptoComposer());
        }
    }
}
