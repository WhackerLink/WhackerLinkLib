﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using WebSocketSharp;
using WhackerLinkLib.Interfaces;
using WhackerLinkLib.Models;
using WhackerLinkLib.Models.IOSP;

#nullable disable

namespace WhackerLinkLib.Handlers
{
    public class WebSocketHandler : IWebSocketHandler
    {
        private WebSocket _socket;

        public bool IsConnected => _socket != null && _socket.IsAlive;

        public void Connect(string address, int port)
        {
            _socket = new WebSocket($"ws://{address}:{port}/client");
            _socket.OnOpen += (sender, e) => OnOpen?.Invoke();
            _socket.OnClose += (sender, e) => OnClose?.Invoke();
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
                        OnAudioData?.Invoke(data["data"].ToObject<byte[]>(), data["voiceChannel"].ToObject<VoiceChannel>());
                        break;
                }
            };
            _socket.Connect();
        }

        public void Disconnect()
        {
            _socket?.Close();
        }

        public void SendMessage(object message)
        {
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
        public event Action<byte[], VoiceChannel> OnAudioData;
        public event Action OnOpen;
        public event Action OnClose;
    }
}