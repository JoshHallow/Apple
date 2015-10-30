using Apple.Application.Base.Communication.Packets.Incoming;
using Apple.Application.Base.Communication.Packets.Incoming.Events.Handshake;
using Apple.Application.Game.Players;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apple.Application.Base.Communication.Packets
{
    sealed class PacketManager
    {
        private readonly Dictionary<int, IPacketEvent> _packets;
        private readonly ILog _log;

        public PacketManager()
        {
            _packets = new Dictionary<int, IPacketEvent>();
            _log = LogManager.GetLogger(typeof(PacketManager));

            RegisterPackets();
        }

        public void ExecuteIncomingPacket(Player player, IncomingPacket packet)
        {
            IPacketEvent Pak = null;

            if (!_packets.TryGetValue(packet.PacketId, out Pak))
            {
                _log.Warn("Unhandled packet " + packet.PacketId);
                return;
            }

            Pak.handleIncomingPacket(player, packet);
            _log.Info("Handled packet " + packet.PacketId);
        }

        public void RegisterPackets()
        {
            RegisterHandshake();
        }

        public void RegisterHandshake()
        {
            _packets.Add(IncomingHeaders.ReleaseVersion, new ReleaseVersionEvent());
            _packets.Add(IncomingHeaders.InitCryptoMessageEvent, new InitCryptoEvent());
            _packets.Add(IncomingHeaders.GenerateSecretKeyMessageEvent, new GenerateSecretKeyEvent());
        }
    }
}
