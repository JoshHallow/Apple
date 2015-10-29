using Apple.Application.Game.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apple.Application.Game
{
    class GameManager
    {
        private readonly PlayerManager _playerManager;

        public GameManager()
        {
            _playerManager = new PlayerManager();
        }

        public PlayerManager PlayerManager
        {
            get { return _playerManager; }
        }
    }
}
