﻿/*
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

namespace WhackerLinkLib.Models
{
    /// <summary>
    /// Enum for site state
    /// </summary>
    public enum SiteStatus
    {
        DOWN = 0x00,
        UP = 0x01,
        FAILSOFT = 0x02,
        UNKOWN = 0xFF
    }
}
