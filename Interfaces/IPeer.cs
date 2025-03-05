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
* Copyright (C) 2024 Caleb, K4PHP
* 
*/

using WhackerLinkLib.Models.IOSP;
using WhackerLinkLib.Models;

namespace WhackerLinkLib.Interfaces
{
    /// <summary>
    /// WhackerLink client/peer websocket handler interface
    /// </summary>
    public interface IPeer
    {
        bool IsConnected { get; }

        void Connect(string address, int port, string authKey = "UNAUTH");
        void Disconnect();
        void SendMessage(object message);

        event Action<U_REG_RSP> OnUnitRegistrationResponse;
        event Action<U_DE_REG_RSP> OnUnitDeRegistrationResponse;
        event Action<GRP_AFF_RSP> OnGroupAffiliationResponse;
        event Action<AFF_UPDATE> OnAffiliationUpdate;
        event Action<GRP_VCH_RSP> OnVoiceChannelResponse;
        event Action<GRP_VCH_RLS> OnVoiceChannelRelease;
        event Action<EMRG_ALRM_RSP> OnEmergencyAlarmResponse;
        event Action<CALL_ALRT> OnCallAlert;
        event Action<AudioPacket> OnAudioData;
        event Action OnOpen;
        event Action OnReconnecting;
        event Action OnClose;
    }
}