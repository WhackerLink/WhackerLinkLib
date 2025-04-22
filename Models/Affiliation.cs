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
    /// Object that represents a group affiliation
    /// </summary>
    public class Affiliation
    {
        /// <summary>
        /// Creates an instance of <see cref="Affiliation"/>
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="srcId"></param>
        /// <param name="dstId"></param>
        /// <param name="site"></param>
        public Affiliation(string clientId, string srcId, string dstId, Site site)
        {
            ClientId = clientId;
            SrcId = srcId;
            DstId = dstId;
            Site = site;
        }

        public string ClientId { get; set; }
        public string SrcId { get; set; }
        public string DstId { get; set; }
        public Site Site { get; set; }
    }
}

