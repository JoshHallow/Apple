using System;
using Apple.Application.Base.Config;
using Apple.Application.Base.Core;

namespace Apple
{
    internal sealed class Apple
    {
        /// <summary>
        /// AppleConfig
        /// </summary>
        private AppleConfig _appleConfig;
        
        /// <summary>
        /// ConsoleWorker
        /// </summary>
        private ConsoleWorker _consoleWorker;

        /// <summary>
        /// Apple
        /// </summary>
        public Apple()
        {
            _appleConfig = new AppleConfig("config.ini");
            _consoleWorker = new ConsoleWorker(_appleConfig);

            Console.WriteLine("Hello World.");
        }
    }
}