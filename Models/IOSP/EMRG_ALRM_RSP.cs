using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhackerLinkLib.Models.IOSP
{
    public class EMRG_ALRM_RSP : WlinkPacket
    {
        public string SrcId { get; set; }
        public string DstId { get; set; }

        public override PacketType PacketType => PacketType.EMRG_ALRM_RSP;

        public override string ToString()
        {
            return $"EMRG_ALRM_RSP, srcId: {SrcId}, dstId: {DstId}";
        }
    }
}