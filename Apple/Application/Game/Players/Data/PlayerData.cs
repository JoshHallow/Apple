using Apple.Application.Game.Players.Components.Player.Packets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Apple.Application.Game.Players.Data
{
    sealed class PlayerData
    {
        private readonly uint _playerId;
        private readonly Socket _playerSocket;
        private readonly IPAddress _playerIp;
        private readonly PlayerPacketManager _playerPm;
        private readonly int _bufferSize;
        private readonly byte[] _socketBuffer;

        public PlayerData(uint id, Socket socket)
        {
            _playerId = id;
            _playerSocket = socket;
            _playerPm = new PlayerPacketManager();
            _bufferSize = 1024;
            _socketBuffer = new byte[_bufferSize];
            _playerIp = IPAddress.Parse(socket.RemoteEndPoint.ToString().Split(':')[0].ToString());
        }

        public uint PlayerId
        {
            get { return this._playerId; }
        }

        public Socket PlayerSocket
        {
            get { return _playerSocket; }
        }

        public IPAddress PlayerIp
        {
            get { return _playerIp; }
        }

        public PlayerPacketManager PacketManager
        {
            get { return _playerPm; }
        }

        public byte[] SocketBuffer
        {
            get { return _socketBuffer; }
        }
    }
}
