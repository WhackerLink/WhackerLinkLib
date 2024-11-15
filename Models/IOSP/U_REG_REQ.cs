﻿using Microsoft.Extensions.Diagnostics.HealthChecks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhackerLinkLib.Models;

#nullable disable

namespace WhackerLinkLib.Models.IOSP
{
    public class U_REG_REQ
    {
        public string SrcId { get; set; }
        public string SysId { get; set; }
        public string Wacn { get; set; }
        public Site Site { get; set; }

        public override string ToString()
        {
            return $"U_REG_REQ, srcId: {SrcId}, SysId: {SysId}";
        }
    }
}