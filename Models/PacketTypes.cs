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
    /// WhackerLink packet opcode enum
    /// </summary>
    public enum PacketType
    {
        /// <summary>
        /// Misc
        /// </summary>
        UNKOWN = 0x00,          // UNKOWN
        AUDIO_DATA = 0x01,      // Audio Packet

        /// <summary>
        /// Affiliation Opcodes
        /// </summary>
        GRP_AFF_REQ = 0x02,     // Group Affiliation Request
        GRP_AFF_RSP = 0x03,     // Group Affiliation Response
        AFF_UPDATE = 0x04,      // Affiliation Update Broadcast
        GRP_AFF_RMV = 0x26,     // Group Affiliation Removal

        /// <summary>
        /// Registration Opcodes
        /// </summary>
        U_REG_REQ = 0x08,       // Unit Registration Request
        U_REG_RSP = 0x09,       // Unit Registration Response
        U_DE_REG_REQ = 0x10,    // Unit De Registration Request
        U_DE_REG_RSP = 0x11,    // Unit De Registration Response

        /// <summary>
        /// Voice Channel Opcodes
        /// </summary>
        GRP_VCH_REQ = 0x05,     // Group Voice Channel Request
        GRP_VCH_RLS = 0x06,     // Group Voice Channel Release
        GRP_VCH_RSP = 0x07,     // Group Voice Channel Response
        REL_DEMAND = 0x18,      // Release Demand
        GRP_VCH_UPD = 0x24,     // Group Voice Channel Update

        /// <summary>
        /// Emergencyu Opcodes
        /// </summary>
        EMRG_ALRM_REQ = 0x12,   // Emergency Alarm Request
        EMRG_ALRM_RSP = 0x13,   // Emergency Alarm Response

        /// <summary>
        /// Call Alert Opcodes
        /// </summary>
        CALL_ALRT = 0x14,       // Call Alert
        CALL_ALRT_REQ = 0x15,   // Call Alert Request (DEPRECATED)

        /// <summary>
        /// Auth Opcodes
        /// </summary>
        AUTH_DEMAND = 0x16,     // Auth Demand
        AUTH_REPLY = 0x17,      // Auth Reply

        /// <summary>
        /// Location/Site Opcodes
        /// </summary>
        LOC_BCAST = 0x19,       // Location Broadcast
        SITE_BCAST = 0x20,      // Site Broadcast
        STS_BCAST = 0x21,       // Status Broadcast

        /// <summary>
        /// Misc
        /// </summary>
        SPEC_FUNC = 0x22,       // Special (extended) Function
        ACK_RSP = 0x23,         // Acknowledge Response
        NET_FAIL = 0x25,        // Network Failover

        /// <summary>
        /// Radio Program Opcodes
        /// </summary>
        RAD_PROG_FUNC = 0x90    // Radio Program Function
    }
}