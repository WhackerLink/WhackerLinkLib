using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhackerLinkLib.Models;

namespace WhackerLinkLib.Models.IOSP
{
    public class EMRG_ALRM_REQ : WlinkPacket
    {
        public string SrcId { get; set; }
        public string DstId { get; set; }
        public Site Site { get; set; }

        public override PacketType PacketType => PacketType.EMRG_ALRM_REQ;

        public override string ToString()
        {
            return $"EMRG_ALRM_REQ, srcId: {SrcId}, dstId: {DstId}";
        }
    }
}