using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhackerLinkLib.Models.IOSP
{
    public class GRP_AFF_RMV : WlinkPacket
    {
        public string SrcId { get; set; }
        public string DstId { get; set; }
        public Site Site { get; set; }

        public override PacketType PacketType => PacketType.GRP_AFF_REQ;

        public override string ToString()
        {
            return $"GRP_AFF_RMV, srcId: {SrcId}, dstId: {DstId}";
        }
    }
}
