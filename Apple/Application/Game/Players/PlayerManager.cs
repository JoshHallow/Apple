using log4net;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Apple.Application.Game.Players
{
    sealed class PlayerManager
    {
        private readonly ConcurrentDictionary<uint, Player> _activePlayers;
        private readonly ILog _log;

        public PlayerManager()
        {
            _activePlayers = new ConcurrentDictionary<uint, Player>();
            _log = LogManager.GetLogger(typeof(PlayerManager));
        }

        public bool TryCreatePlayer(Socket socket)
        {
            _log.Info("Incoming connection from " + socket.RemoteEndPoint.ToString().Split(':')[0]);
            return (_activePlayers.TryAdd((uint)_activePlayers.Count, new Player((uint)_activePlayers.Count, socket)));
        }

        public void DisposePlayer(uint id)
        {
            //call disconnect
            //remove/dispose from dictionary
        }
    }
}
