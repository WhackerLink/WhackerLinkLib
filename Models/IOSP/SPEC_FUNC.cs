using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhackerLinkLib.Models.IOSP
{
    /// <summary>
    /// Special function Wlink packet
    /// </summary>
    public class SPEC_FUNC : WlinkPacket
    {
        public SpecFuncType Function { get; set; } = SpecFuncType.UNKOWN;
        public string SrcId { get; set; } = null;
        public string DstId { get; set; } = null;

        public override PacketType PacketType => PacketType.SPEC_FUNC;

        public override string ToString()
        {
            return $"SPEC_FUNC, Function: {Function}, SrcId: {SrcId}, DstId: ${DstId}";
        }
    }
}
