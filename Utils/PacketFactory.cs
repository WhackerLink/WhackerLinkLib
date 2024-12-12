/*
* WhackerLink - WhackerLinkConsoleV2
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

using Microsoft.AspNetCore.Http;
using WhackerLinkLib.Models;
using WhackerLinkLib.Models.IOSP;

namespace WhackerLinkLib.Utils
{
    public static class PacketFactory
    {
        public static object CreateUnitRegistrationRequest(string srcId, Site site)
        {
            return new
            {
                type = (int)PacketType.U_REG_REQ,
                data = new U_REG_REQ
                {
                    SrcId = srcId,
                    SysId = "",
                    Wacn = "",
                    Site = site
                }
            };
        }

        public static object CreateAffiliationRequest(string srcId, string dstId, Site site)
        {
            return new
            {
                type = (int)PacketType.GRP_AFF_REQ,
                data = new GRP_AFF_REQ
                {
                    SrcId = srcId,
                    DstId = dstId,
                    SysId = "",
                    Site = site
                }
            };
        }

        public static object CreateVoiceChannelRequest(string srcId, string dstId, Site site)
        {
            return new
            {
                type = (int)PacketType.GRP_VCH_REQ,
                data = new GRP_VCH_REQ
                {
                    SrcId = srcId,
                    DstId = dstId,
                    Site = site
                }
            };
        }

        public static object CreateVoiceChannelRelease(string srcId, string dstId, string channel, Site site)
        {
            return new
            {
                type = (int)PacketType.GRP_VCH_RLS,
                data = new GRP_VCH_RLS
                {
                    SrcId = srcId,
                    DstId = dstId,
                    Site = site,
                    Channel = channel
                }
            };
        }

        public static object CreateVoicePacket(string srcId, string dstId, string channel, byte[] audio, Site site)
        {
            return new
            {
                type = (int)PacketType.AUDIO_DATA,
                data = audio,
                voiceChannel = new VoiceChannel
                {
                    SrcId = srcId,
                    DstId = dstId,
                    Frequency = channel,
                },
                site
            };
        }

        public static object CreateCallAlertRequest(string srcId, string dstId)
        {
            return new
            {
                type = (int)PacketType.CALL_ALRT_REQ,
                data = new CALL_ALRT_REQ
                {
                    SrcId = srcId,
                    DstId = dstId
                }
            };
        }

        public static object CreateAuthDemand(string srcId)
        {
            return new
            {
                type = (int)PacketType.AUTH_DEMAND,
                data = new AUTH_DEMAND
                {
                    SrcId = srcId,
                }
            };
        }

        public static object CreateAuthReply(string srcId, string authKey = null, ResponseType status = ResponseType.FAIL)
        {
            return new
            {
                type = (int)PacketType.AUTH_REPLY,
                data = new AUTH_REPLY
                {
                    SrcId = srcId,
                    AuthKey = authKey,
                    Status = (int)status
                }
            };
        }

        public static object CreateRelDemand(string srcId, string dstId, string voiceChannel, Site site)
        {
            return new
            {
                type = (int)PacketType.REL_DEMAND,
                data = new REL_DEMND
                {
                    SrcId = srcId,
                    DstId = dstId,
                    Channel = voiceChannel,
                    Site = site
                }
            };
        }
    }
}
