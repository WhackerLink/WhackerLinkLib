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
        public string SrcId { get; set; } = null;
        public string DstId { get; set; } = null;

        public override PacketType PacketType => PacketType.ACK_RSP;

        public override string ToString()
        {
            return $"ACK_RSP, Service: {Service}, SrcId: {SrcId}, DstId: ${DstId}";
        }
    }
}
