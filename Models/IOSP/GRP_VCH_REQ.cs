﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhackerLinkLib.Models;

#nullable disable

namespace WhackerLinkLib.Models.IOSP
{
    public class GRP_VCH_REQ
    {
        public string SrcId { get; set; }
        public string DstId { get; set; }
        public Site Site { get; set; }

        public override string ToString()
        {
            return $"GRP_VCH_REQ, srcId: {SrcId}, dstId: {DstId}, CC: {Site.ControlChannel}, SiteID: {Site.SiteID}, SystemID: {Site.SystemID}";
        }
    }
}