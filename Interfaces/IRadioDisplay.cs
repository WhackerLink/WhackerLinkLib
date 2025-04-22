/*
 * Copyright (C) 2024-2025 Caleb H. (K4PHP) caleb.k4php@gmail.com
 *
 * This file is part of the WhackerLinkServer project.
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

using WhackerLinkLib.Models;
using WhackerLinkLib.Models.Radio;

namespace WhackerLinkLib.Interfaces
{
    /// <summary>
    /// Radio emulator display interface
    /// </summary>
    public interface IRadioDisplay
    {
        void SetLine1Text(string text, bool forMenu = false);
        void SetLine2Text(string text, bool forMenu = false);
        void SetLine3Text(string text, bool forMenu = false);
        void SetRssiSource(string name);
        void MasterConnection(Codeplug.System system);
        void KillMasterConnection();
        void SendUnitRegistrationRequest();
        void SendGroupAffiliationRequest();
        bool PowerOn { get; }
        bool IsInRange { get; set; }
        string MyRid { get; set; }
        string CurrentTgid { get; set; }
        Site CurrentSite { get; set; }
        Codeplug.System CurrentSystem { get; set; }
    }
}
