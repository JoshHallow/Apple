using Apple.Application.Base.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Apple.Application.Base.Core
{
    class ConsoleWorker
    {
        /// <summary>
        /// Console timer
        /// </summary>
        private Timer _consoleTimer;

        /// <summary>
        /// ConsoleWorker
        /// </summary>
        /// <param name="config">Instance of AppleConfig</param>
        public ConsoleWorker(AppleConfig config)
        {
            _consoleTimer = new Timer(int.Parse(config.GetConfigElement("console.timer.interval")));
            _consoleTimer.Elapsed += new ElapsedEventHandler(OnElapsed);
            _consoleTimer.Enabled = true; // Enable it
        }

        public void OnElapsed()
        {
        }
    }
}
