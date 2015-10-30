using Apple.Application.Base.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Apple.Application.Base.Core
{
    sealed class ConsoleWorker
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
            UpdateConsoleTitle();
        }

        public void UpdateConsoleTitle()
        {
            DateTime Startup = Apple.ServerInformation.ServerStarted;
            TimeSpan Uptime = DateTime.Now - Startup;

            string days = String.Format("{0} day{1}, ", Uptime.Days, (Uptime.Days != 1 ? "s" : ""));
            string hours = String.Format("{0} hour{1}, and ", Uptime.Hours, (Uptime.Hours != 1 ? "s" : ""));
            string mins = String.Format("{0} min{1}", Uptime.Minutes, (Uptime.Minutes != 1 ? "s" : ""));

            string uptime = days + hours + mins;
            Console.Title = Apple.ServerInformation.Title + " | Uptime: " + uptime;
        }
    }
}
