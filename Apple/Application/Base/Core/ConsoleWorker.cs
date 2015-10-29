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
        private Timer _consoleTimer;

        public ConsoleWorker(ushort consoleInterval)
        {
            _consoleTimer = new Timer(consoleInterval);
            _consoleTimer.Elapsed += new ElapsedEventHandler(OnElapsed);
            _consoleTimer.Enabled = true; 
        }

        public void OnElapsed(object sender, ElapsedEventArgs e)
        {
            DateTime Startup = Apple.ServerInformation.ServerStarted;
            TimeSpan Uptime = DateTime.Now - Startup;

            string UptimeString = string.Format("{0}, {1}, and {2}",
                Uptime.Days + " day" + (Uptime.Days != 1 ? "s" : ""),
                Uptime.Hours + " hour" + (Uptime.Hours != 1 ? "s" : ""),
                Uptime.Minutes + " min" + (Uptime.Minutes != 1 ? "s" : ""));

            Console.Title = "Apple Server | Uptime: " + UptimeString;
        }
    }
}
