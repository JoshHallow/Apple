using System;
using Apple.Application.Base.Config;
using Apple.Application.Base.Core;
using System.Collections.Generic;

namespace Apple
{
    internal sealed class Apple
    {
        private AppleConfig _appleConfig;
        private ConsoleWorker _consoleWorker;
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

            _appleConfig = new AppleConfig("config.ini");
            _consoleWorker = new ConsoleWorker(ushort.Parse(_appleConfig.GetConfigElement("console.timer.interval")));
        }

        public static ServerInformation ServerInformation
        {
            get { return _severInfo; }
        }
    }
}