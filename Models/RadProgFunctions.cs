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
    public enum RadProgFunctions
    {
        UNKOWN = 0x00,          // UNKOWN
        
        ENTER_PROG = 0x01,      // Enter Program Mode
        EXIT_PROG = 0x02,       // Exit Program Mode

        WHL_CPG_UPD = 0x10,     // Whole Codeplug Update
        WHL_CPG_DEL = 0x11,     // Whole Codeplug Delete

        WRT_SER_NUM = 0x20,     // Write Serial Number
        RED_SER_NUM = 0x21,     // Read Serial Number
    }

    public enum RadProgCommandTypes
    {
        UNKOWN = 0x00,      // UNKOWN

        SND_CMD = 0x01,     // Send Data Command
        ACK_CMD = 0x02,     // Acknowledge Data Command
        NACK_CMD = 0x03,    // Negative Acknowledge Data Command
        QUE_CMD = 0x03,     // Que Data Command
    }

    public enum RadProgReasons
    {
        NA = 0x00,          // Not Used

        INV_CPG = 0x01,     // Invalid Codeplug Data
        NO_STORAG = 0x02,   // No Storage Available
        INV_SER = 0x03,     // Invalid Serial Number

        MISC = 0xFF         // Misc/Unhandled
    }
}
