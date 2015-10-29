using Apple.Application.Game.Players.Data;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Apple.Application.Game.Players
{
    internal sealed class Player
    {
        private readonly PlayerData _playerData;
        private readonly UserData _userData;
        private readonly RoleplayData _roleplayData;
        private readonly ILog _log;

        internal Player(uint id, Socket socket)
        {
            _playerData = new PlayerData(id, socket);
            _log = LogManager.GetLogger(typeof(Player));
        }

        internal PlayerData PlayerData
        {
            get { return _playerData; }
        }

        private void StartPacketProcessing()
        {
            try
            {
                if (_playerData.PlayerSocket == null)
                    return;

                _playerData.PlayerSocket.BeginReceive(_playerData.SocketBuffer, 0, _playerData.SocketBuffer.Length, SocketFlags.None, new AsyncCallback(OnReceiveData), null);
            }
            catch (Exception ex)
            {
                _log.Error(ex);
                Apple.Game.PlayerManager.DisposePlayer(_playerData.PlayerId);
            }
        }

        private void OnReceiveData(IAsyncResult AsyncResult)
        {
            int bytesRead = _playerData.PlayerSocket.EndReceive(AsyncResult);
        
            if (bytesRead <= 0)
            {
                Apple.Game.PlayerManager.DisposePlayer(_playerData.PlayerId);
                return;
            }

            // to be continued...
        }
    }
}
