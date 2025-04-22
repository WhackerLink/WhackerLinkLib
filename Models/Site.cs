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
    /// Object to represent a trunking Site
    /// </summary>
    public class Site
    {
        public string Name { get; set; }
        public string ControlChannel { get; set; }
        public List<string> VoiceChannels { get; set; }
        public Location Location { get; set; }
        public string SiteID { get; set; }
        public string SystemID { get; set; }
        public float Range { get; set; }
    }

    /// <summary>
    /// Location of a <see cref="Site"/>
    /// </summary>
    public class Location
    {
        public string X { get; set; }
        public string Y { get; set; }
        public string Z { get; set; }
    }
}

