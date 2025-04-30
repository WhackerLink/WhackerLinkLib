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

namespace WhackerLinkLib.Models
{
    /// <summary>
    /// 
    /// </summary>
    public static class Defines
    {
        public static string WL_REST_AUTH_HEADER = "WLINK-AUTH-HDR";    // WhackerLink REST server auth header

        public const int FNE_LID = 0xFFFFFC;                            // FNE ID                            
        public const int VHC_UPD_INTERVAL = 3000;                       // VCH Update Interval in MS
    }
}
