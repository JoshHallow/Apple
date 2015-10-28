using System;
using Apple.Application.Base.Config;
using Apple.Application.Base.Core;

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
                ServerStarted = DateTime.Now
            };

            _appleConfig = new AppleConfig("config.ini");
            _consoleWorker = new ConsoleWorker(_appleConfig);
        }

        public static ServerInformation ServerInformation
        {
            get { return _severInfo; }
        }
    }
}