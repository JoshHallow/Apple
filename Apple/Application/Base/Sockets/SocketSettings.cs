using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Apple.Application.Base.Sockets
{
    sealed class SocketSettings
    {
        public IPEndPoint EndPoint { get; set; }
        public ushort SocketPort { get; set; }
        public ushort SocketBacklog { get; set; }
    }
}
