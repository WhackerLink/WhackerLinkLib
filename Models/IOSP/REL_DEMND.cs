﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhackerLinkLib.Models.IOSP
{
    public class REL_DEMND : WlinkPacket
    {
        public string SrcId { get; set; }
        public string DstId { get; set; }
        public string Channel { get; set; }
        public Site Site { get; set; }

        public override PacketType PacketType => PacketType.REL_DEMAND;

        public override string ToString()
        {
            return $"REL_DEMND, srcId: {SrcId}, dstId: {DstId}, channel: {Channel}";
        }
    }
}
