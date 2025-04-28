/*
 * Copyright (C) 2024-2025 Caleb H. (K4PHP) caleb.k4php@gmail.com
 *
 * This file is part of the WhackerLinkLib project.
 *
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU Affero General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
 * GNU Affero General Public License for more details.
 *
 * You should have received a copy of the GNU Affero General Public License
 * along with this program. If not, see <https://www.gnu.org/licenses/>.
 *
 * DO NOT ALTER OR REMOVE COPYRIGHT NOTICES OR THIS FILE HEADER.
 */

using Serilog;
using WhackerLinkLib.Managers;
using WhackerLinkLib.Models;
using WhackerLinkServer.Managers;

namespace WhackerLinkLib.Interfaces
{
    /// <summary>
    /// WhackerLink Master interface
    /// </summary>
    public interface IMasterService
    {
        string Name { get; }
        ILogger Logger { get; }
        List<Affiliation> GetAffiliations();
        List<VoiceChannel> GetVoiceChannels();
        List<Site> GetSites();
        List<RidAclEntry> GetRidAcl();
        AuthKeyFileManager GetAuthManager();
        bool GetRidAclEnabled();
        void Start(CancellationToken cancellationToken);
        void BroadcastPacket(string packet, string skipClientId = null);
        void BroadcastPacket(string message, List<string> clientIds, string skipClientId = null);
    }
}

