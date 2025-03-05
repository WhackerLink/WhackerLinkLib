/*
* WhackerLink - WhackerLinkLib
*
* This program is free software: you can redistribute it and/or modify
* it under the terms of the GNU General Public License as published by
* the Free Software Foundation, either version 3 of the License, or
* (at your option) any later version.
*
* This program is distributed in the hope that it will be useful,
* but WITHOUT ANY WARRANTY; without even the implied warranty of
* MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
* GNU General Public License for more details.
*
* You should have received a copy of the GNU General Public License
* along with this program.  If not, see <http://www.gnu.org/licenses/>.
* 
* Copyright (C) 2024-2025 Caleb, K4PHP
* 
*/

using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WebSocketSharp;
using WhackerLinkLib.Interfaces;
using WhackerLinkLib.Managers;
using WhackerLinkLib.Models;
using WhackerLinkLib.Models.IOSP;

namespace WhackerLinkLib.Network
{
    /// <summary>
    /// WhackerLink peer/client
    /// </summary>
    public class Peer : IPeer
    {
        private WebSocket _socket;
        private string _address;
        private int _port;
        private string _authKey;
        private bool _isReconnecting;
        private bool _isDisconnecting;
        private readonly object _reconnectLock = new();
        private const int ReconnectIntervalSeconds = 5;

        public bool IsConnected => _socket != null && _socket.IsAlive;

        private void CreateWebSocket()
        {
            _socket = new WebSocket($"ws://{_address}:{_port}/client?authKey={AuthKeyManager.HashKey(_authKey)}");

            _socket.OnOpen += (sender, e) =>
            {
                _isReconnecting = false;
                OnOpen?.Invoke();
            };

            _socket.OnClose += (sender, e) =>
            {
                OnClose?.Invoke();

                if (!_isDisconnecting)
                {
                    StartReconnect();
                }
            };

            _socket.OnMessage += (sender, e) =>
            {
                var data = JObject.Parse(e.Data);
                var type = Convert.ToInt32(data["type"]);

                switch (type)
                {
                    case (int)PacketType.U_REG_RSP:
                        OnUnitRegistrationResponse?.Invoke(data["data"].ToObject<U_REG_RSP>());
                        break;
                    case (int)PacketType.U_DE_REG_RSP:
                        OnUnitDeRegistrationResponse?.Invoke(data["data"].ToObject<U_DE_REG_RSP>());
                        break;
                    case (int)PacketType.GRP_AFF_RSP:
                        OnGroupAffiliationResponse?.Invoke(data["data"].ToObject<GRP_AFF_RSP>());
                        break;
                    case (int)PacketType.GRP_VCH_RSP:
                        OnVoiceChannelResponse?.Invoke(data["data"].ToObject<GRP_VCH_RSP>());
                        break;
                    case (int)PacketType.AFF_UPDATE:
                        OnAffiliationUpdate?.Invoke(data["data"].ToObject<AFF_UPDATE>());
                        break;
                    case (int)PacketType.GRP_VCH_RLS:
                        OnVoiceChannelRelease?.Invoke(data["data"].ToObject<GRP_VCH_RLS>());
                        break;
                    case (int)PacketType.EMRG_ALRM_RSP:
                        OnEmergencyAlarmResponse?.Invoke(data["data"].ToObject<EMRG_ALRM_RSP>());
                        break;
                    case (int)PacketType.CALL_ALRT:
                        OnCallAlert?.Invoke(data["data"].ToObject<CALL_ALRT>());
                        break;
                    case (int)PacketType.AUDIO_DATA:
                        OnAudioData?.Invoke(data["data"].ToObject<AudioPacket>());
                        break;
                }
            };

            _socket.Connect();
        }

        /// <summary>
        /// Internal helper to reconnect a lost connection
        /// </summary>
        private void StartReconnect()
        {
            lock (_reconnectLock)
            {
                if (_isReconnecting) return;
                _isReconnecting = true;
            }

            new Thread(() =>
            {
                while (_isReconnecting && !_isDisconnecting)
                {
                    OnReconnecting?.Invoke();
                    Thread.Sleep(ReconnectIntervalSeconds * 1000);

                    if (_isDisconnecting) return;

                    try
                    {
                        CreateWebSocket();
                        if (_socket.IsAlive)
                        {
                            _isReconnecting = false;
                            return;
                        }
                    }
                    catch (Exception)
                    {
                        //Console.WriteLine($"Reconnection failed: {ex.Message}");
                    }
                }
            }).Start();
        }

        /// <summary>
        /// Connect to a WhackerLink master
        /// </summary>
        public void Connect(string address, int port, string authKey = "UNAUTH")
        {
            _address = address;
            _port = port;
            _authKey = authKey;
            _isDisconnecting = false;
            CreateWebSocket();
        }

        /// <summary>
        /// Disconnect from WhackerLink master
        /// </summary>
        public void Disconnect()
        {
            _isDisconnecting = true;
            _socket?.Close();
        }

        /// <summary>
        /// Helper to send a object to the Master
        /// </summary>
        /// <param name="message"></param>
        public void SendMessage(object message)
        {
            if (_socket == null || _socket.ReadyState != WebSocketState.Open)
            {
                Console.WriteLine("Master connection not established to send message");
                return;
            }

            _socket.Send(JsonConvert.SerializeObject(message));
        }

        public event Action<U_REG_RSP> OnUnitRegistrationResponse;
        public event Action<U_DE_REG_RSP> OnUnitDeRegistrationResponse;
        public event Action<GRP_AFF_RSP> OnGroupAffiliationResponse;
        public event Action<AFF_UPDATE> OnAffiliationUpdate;
        public event Action<GRP_VCH_RSP> OnVoiceChannelResponse;
        public event Action<GRP_VCH_RLS> OnVoiceChannelRelease;
        public event Action<EMRG_ALRM_RSP> OnEmergencyAlarmResponse;
        public event Action<CALL_ALRT> OnCallAlert;
        public event Action<AudioPacket> OnAudioData;
        public event Action OnOpen;
        public event Action OnReconnecting;
        public event Action OnClose;
    }
}