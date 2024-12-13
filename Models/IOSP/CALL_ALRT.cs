using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhackerLinkLib.Models.IOSP
{
    public class CALL_ALRT : WlinkPacket
    {
        public string SrcId { get; set; }
        public string DstId { get; set; }

        public override PacketType PacketType => PacketType.CALL_ALRT;

        public override string ToString()
        {
            return $"CALL_ALRT, srcId: {SrcId}, dstId: {DstId}";
        }
    }
}
