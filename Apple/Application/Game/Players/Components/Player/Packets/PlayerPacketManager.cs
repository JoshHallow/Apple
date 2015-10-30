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
        private bool _authenticationPassed;

        public void ExecuteIncomingPacket(Player player, IncomingPacket Packet)
        {
            if (Packet.PacketId == IncomingHeaders.SSOTicketMessageEvent)
            {
                if (_authenticationPassed)
                    return;

                _authenticationPassed = true;
            }

            //handle through main packet manager here
        }
    }
}
