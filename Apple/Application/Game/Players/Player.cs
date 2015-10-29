using Apple.Application.Base.Communication.Packets.Incoming;
using Apple.Application.Game.Players.Data;
using log4net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Apple.Application.Game.Players
{
    internal sealed class Player
    {
        private readonly PlayerData _playerData;
        private readonly UserData _userData;
        private readonly RoleplayData _roleplayData;
        private readonly ILog _log;
        private bool _beingDisconnected;

        internal Player(uint id, Socket socket)
        {
            _playerData = new PlayerData(id, socket);
            _log = LogManager.GetLogger(typeof(Player));

            StartPacketProcessing();
        }

        internal PlayerData PlayerData
        {
            get { return _playerData; }
        }

        private void StartPacketProcessing()
        {
            try
            {
                if (_playerData.PlayerSocket == null)
                    return;

                _playerData.PlayerSocket.BeginReceive(_playerData.SocketBuffer, 0, _playerData.SocketBuffer.Length, SocketFlags.None, new AsyncCallback(OnReceiveData), null);
            }
            catch (Exception ex)
            {
                _log.Error(ex);
                Apple.Game.PlayerManager.DisposePlayer(_playerData.PlayerId);
            }
        }

        private void OnReceiveData(IAsyncResult AsyncResult)
        {
            int bytesRead = _playerData.PlayerSocket.EndReceive(AsyncResult);
        
            if (bytesRead <= 0 || bytesRead > _playerData.SocketBuffer.Length)
            {
                Apple.Game.PlayerManager.DisposePlayer(_playerData.PlayerId);
                return;
            }

            byte[] packetData = new byte[bytesRead];
            Array.Copy(_playerData.SocketBuffer, packetData, bytesRead);
            
            if (packetData.Length <= 0)
                return;

            if (packetData[0] == 60)
            {
                SendData("<?xml version=\"1.0\"?>\r\n<!DOCTYPE cross-domain-policy SYSTEM \"/xml/dtds/cross-domain-policy.dtd\">\r\n<cross-domain-policy>\r\n<allow-access-from domain=\"*\" to-ports=\"" +
                Apple.Config.GetConfigElement("game.socket.port") + "\" />\r\n</cross-domain-policy>\0");

                Apple.Game.PlayerManager.DisposePlayer(_playerData.PlayerId);
            }
            else if (packetData[0] != 67)
            {
                Console.WriteLine("Attempting to handle packet " + packetData[0]);
            }
        }

        private void SendData(string Data)
        {
            SendData(Encoding.ASCII.GetBytes(Data));
        }

        private void SendData(byte[] Data)
        {
            try
            {
                if (_playerData.PlayerSocket != null)
                    _playerData.PlayerSocket.BeginSend(Data, 0, Data.Length, SocketFlags.None, new AsyncCallback(OnDataSent), null);
            }
            catch (Exception ex)
            {
                _log.Error(ex);
            }
        }

        private void OnDataSent(IAsyncResult AsyncResult)
        {
            try
            {
                if (_playerData.PlayerSocket != null)
                    _playerData.PlayerSocket.EndSend(AsyncResult);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Apple.Game.PlayerManager.DisposePlayer(_playerData.PlayerId);
            }
        }

        public void Disconnect()
        {
            if (_beingDisconnected)
                return;

            _beingDisconnected = true;
            _playerData.PlayerSocket.Shutdown(SocketShutdown.Both);
            _playerData.PlayerSocket.Close(); // also calls dispose
        }
    }
}
