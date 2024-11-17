﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhackerLinkLib.Models.IOSP
{
    public class CALL_ALRT
    {
        public string SrcId { get; set; }
        public string DstId { get; set; }

        public override string ToString()
        {
            return $"CALL_ALRT, srcId: {SrcId}, dstId: {DstId}";
        }
    }
}
