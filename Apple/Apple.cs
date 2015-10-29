using System;
using Apple.Application.Base.Config;
using Apple.Application.Base.Core;
using System.Collections.Generic;
using Apple.Application.Base.Connection;
using Apple.Application.Base.Sockets;
using System.Net;
using log4net;
using Apple.Application.Game;

namespace Apple
{
    internal sealed class Apple
    {
        private AppleConfig _appleConfig;
        private ConsoleWorker _consoleWorker;
        private SocketManager _socketManager;

        private static GameManager _gameManager;
        private static ServerInformation _severInfo;

        public Apple()
        {
            _severInfo = new ServerInformation
            {
                ServerStarted = DateTime.Now,
                ServerVersion = new Version("2.0.0"),
                Author = "Josh Hallow",
                Title = "Apple Server",
                Developers = new List<string> { "Josh Hallow as creator." }
            };

            SocketSettings socketSettings = new SocketSettings
            {
                EndPoint = new IPEndPoint(IPAddress.Any, 30 * 1000),
                SocketBacklog = 100,
                _log = LogManager.GetLogger(typeof(SocketManager))
            };

            string interval = _appleConfig.GetConfigElement("console.timer.interval");
            _consoleWorker = new ConsoleWorker(ushort.Parse(interval));

            _socketManager = new SocketManager(socketSettings);
            _appleConfig = new AppleConfig("config.ini");

            _gameManager = new GameManager();
        }

        public static ServerInformation ServerInformation
        {
            get { return _severInfo; }
        }

        public static GameManager Game
        {
            get { return _gameManager; }
        }
    }
}