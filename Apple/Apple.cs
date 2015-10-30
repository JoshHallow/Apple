using System;
using Apple.Application.Base.Config;
using Apple.Application.Base.Core;
using System.Collections.Generic;
using Apple.Application.Base.Connection;
using Apple.Application.Base.Sockets;
using System.Net;
using log4net;
using Apple.Application.Game;
using Apple.Application.Base.Core.Util;

namespace Apple
{
    internal sealed class Apple
    {
        private ConsoleWorker _consoleWorker;
        private SocketManager _socketManager;

        private static GameManager _gameManager;
        private static ServerInformation _severInfo;
        private static AppleConfig _appleConfig;
        private static AppleEncoding _appleEncoding;

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

            _appleConfig = new AppleConfig("config.ini");

            SocketSettings socketSettings = new SocketSettings
            {
                EndPoint = new IPEndPoint(IPAddress.Any, int.Parse(_appleConfig.GetConfigElement("game.socket.port"))),
                SocketBacklog = ushort.Parse(_appleConfig.GetConfigElement("game.socket.backlog")),
                _log = LogManager.GetLogger(typeof(SocketManager))
            };

            string interval = _appleConfig.GetConfigElement("console.timer.interval");
            _consoleWorker = new ConsoleWorker(ushort.Parse(interval));

            _socketManager = new SocketManager(socketSettings);
            _appleEncoding = new AppleEncoding();
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

        public static AppleConfig Config
        {
            get { return _appleConfig; }
        }

        public static AppleEncoding Encoding
        {
            get { return _appleEncoding; }
        }
    }
}