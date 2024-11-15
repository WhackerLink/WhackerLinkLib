﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhackerLinkLib.Models;

namespace WhackerLinkLib.Models.IOSP
{
    public class CALL_ALRT_REQ
    {
        public string? SrcId { get; set; }
        public string? DstId { get; set; }
        public Site? Site { get; set; }

        public override string ToString()
        {
            return $"CALL_ALRT_REQ, srcId: {SrcId}, dstId: {DstId}";
        }
    }
}