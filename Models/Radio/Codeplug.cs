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

namespace WhackerLinkLib.Models.Radio
{
    /// <summary>
    /// Codeplug object used project wide
    /// </summary>
    public class Codeplug
    {
        public RadioWideConfiguration RadioWide { get; set; }
        public RadioEgroConfiguration ErgonomicsWide { get; set; }
        public List<System> Systems { get; set; }
        public List<Zone> Zones { get; set; }
        public List<ScanList> scanList { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public class RadioWideConfiguration
        {
            public string HostVersion { get; set; }
            public string CodeplugVersion { get; set; }
            public string RadioAlias { get; set; }
            public string SerialNumber { get; set; }
            public string Model { get; set; }
            public string InCarMode { get; set; }
        }

        /// <summary>
        /// 
        /// </summary>
        public class RadioEgroConfiguration
        {
            public bool KeepOnTop { get; set; }
            public bool GlobalPttKeybind { get; set; }
            public string PttKeyBind { get; set; }
        }

        /// <summary>
        /// 
        /// </summary>
        public class System
        {
            public string Name { get; set; }
            public string Address { get; set; }
            public uint PeerId { get; set; } = 0;
            public int Port { get; set; }
            public string Rid { get; set; }
            public string AuthKey { get; set; } = "UNAUTH";
            public string AliasPath { get; set; } = "./alias.yml";
            public List<RadioAlias> RidAlias { get; set; } = null;
            public bool IsDvm { get; set; } = false;
            public Site Site { get; set; }

            public override string ToString()
            {
                return Name;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public class Zone
        {
            public string Name { get; set; }
            public List<Channel> Channels { get; set; }
        }
        
        /// <summary>
        /// 
        /// </summary>
        public class Channel
        {
            public string Name { get; set; }
            public string System { get; set; }
            public string Tgid { get; set; }
            public string EncryptionKey { get; set; }
            public string AlgoId { get; set; } = "0x80";
            public string KeyId { get; set; }

            public ushort GetKeyId()
            {
                return Convert.ToUInt16(KeyId, 16);
            }

            public byte GetAlgoId()
            {
                return Convert.ToByte(AlgoId, 16);
            }

            public byte[] GetEncryptionKey()
            {
                if (EncryptionKey == null)
                    return [];

                return EncryptionKey
                    .Split(',')
                    .Select(s => Convert.ToByte(s.Trim(), 16))
                    .ToArray();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public class ScanList
        {
            public string Name { get; set; }
            public List<ScanListChannel> Channels { get; set; }
        }

        /// <summary>
        /// 
        /// </summary>
        public class ScanListChannel
        {
            public string Zone { get; set; }
            public string Channel { get; set; }
        }

        /// <summary>
        /// Helper to return a system by looking up a <see cref="Channel"/>
        /// </summary>
        /// <param name="channel"></param>
        /// <returns></returns>
        public System GetSystemForChannel(Channel channel)
        {
            return Systems.FirstOrDefault(s => s.Name == channel.System);
        }

        /// <summary>
        /// Helper to return a system by looking up a channel name
        /// </summary>
        /// <param name="channelName"></param>
        /// <returns></returns>
        public System GetSystemForChannel(string channelName)
        {
            foreach (var zone in Zones)
            {
                var channel = zone.Channels.FirstOrDefault(c => c.Name == channelName);
                if (channel != null)
                {
                    return Systems.FirstOrDefault(s => s.Name == channel.System);
                }
            }
            return null;
        }

        /// <summary>
        /// Helper to return a <see cref="Channel"/> by channel name
        /// </summary>
        /// <param name="channelName"></param>
        /// <returns></returns>
        public Channel GetChannelByName(string channelName)
        {
            foreach (var zone in Zones)
            {
                var channel = zone.Channels.FirstOrDefault(c => c.Name == channelName);
                if (channel != null)
                {
                    return channel;
                }
            }
            return null;
        }
    }
}

