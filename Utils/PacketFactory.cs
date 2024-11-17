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
    }
}
