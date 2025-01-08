using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhackerLinkLib.Models.IOSP
{
    /// <summary>
    /// General response acknowledgement
    /// </summary>
    public class ACK_RSP : WlinkPacket
    {
        public PacketType Service { get; set; } = PacketType.UNKOWN;
        public SpecFuncType Extended { get; set; } = SpecFuncType.UNKOWN;
        public string SrcId { get; set; } = null;
        public string DstId { get; set; } = null;

        public override PacketType PacketType => PacketType.ACK_RSP;

        public override string ToString()
        {
            var extendedInfo = Extended != SpecFuncType.UNKOWN ? $", Extended: {Extended}" : string.Empty;
            return $"ACK_RSP, Service: {Service}{extendedInfo}, SrcId: {SrcId}, DstId: {DstId}";
        }
    }
}
