using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhackerLinkLib.Models.IOSP
{
    public class AUTH_DEMAND : WlinkPacket
    {
        public string SrcId { get; set; }
        public string DstId { get; set; }

        public override PacketType PacketType => PacketType.AUTH_DEMAND;

        public override string ToString()
        {
            return $"AUTH_DEMAND, srcId: {SrcId}, dstId: {DstId}, ";
        }
    }
}
