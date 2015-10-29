using Apple.Application.Base.Sockets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Apple.Application.Base.Connection
{
    class SocketManager
    {
        private Socket _serverSocket;
        private SocketSettings _settings;

        public SocketManager(SocketSettings settings)
        {
            _settings = settings;
            _serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            BeginListen();
            BeginAccept();
        }

        public void BeginListen()
        {
            _serverSocket.Bind(_settings.EndPoint);
            _serverSocket.Listen(_settings.SocketBacklog);
        }

        public void BeginAccept()
        {
            _serverSocket.BeginAccept(new AsyncCallback(OnAccept), null);
        }

        public void OnAccept(IAsyncResult AsyncResult)
        {
            try
            {
                _settings._log.Info("New connection was received");
            }
            catch (Exception exception)
            {
                _settings._log.Error(exception);
            }
            finally
            {
                BeginAccept();
            }
        }
    }
}
