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

        public ConsoleWorker(AppleConfig config)
        {
            _consoleTimer = new Timer(int.Parse(config.GetConfigElement("console.timer.interval")));
            _consoleTimer.Elapsed += new ElapsedEventHandler(OnElapsed);
            _consoleTimer.Enabled = true; // Enable it
        }

        public void OnElapsed(object sender, ElapsedEventArgs e)
        {
            DateTime Startup = Apple.ServerInformation.ServerStarted;
            TimeSpan Uptime = DateTime.Now - Startup;

            string days = Uptime.Days + " day" + (Uptime.Days != 1 ? "s" : "") + ", ";
            string hours = Uptime.Hours + " hour" + (Uptime.Hours != 1 ? "s" : "") + ", and ";
            string mins = Uptime.Minutes + " min" + (Uptime.Minutes != 1 ? "s" : "");
            string UptimeString = days + hours + mins;

            Console.Title = "Apple Server | Uptime: " + UptimeString;
        }
    }
}
