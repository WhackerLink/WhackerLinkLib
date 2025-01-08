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

using Serilog;
using WhackerLinkLib.Models;

namespace WhackerLinkLib.Interfaces
{
    /// <summary>
    /// WhackerLink Master interface
    /// </summary>
    public interface IMasterService
    {
        ILogger Logger { get; }
        List<Affiliation> GetAffiliations();
        List<VoiceChannel> GetVoiceChannels();
        List<Site> GetSites();
        List<RidAclEntry> GetRidAcl();
        bool GetRidAclEnabled();
        void Start(CancellationToken cancellationToken);
        void BroadcastPacket(string packet);
    }
}