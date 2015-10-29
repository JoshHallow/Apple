using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apple.Application.Base.Core
{
    sealed class ServerInformation
    {
        public DateTime ServerStarted { get; set; }
        public Version ServerVersion { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public List<string> Developers { get; set; }
    }
}
