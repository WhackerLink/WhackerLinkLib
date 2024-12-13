using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhackerLinkLib.Models.IOSP
{
    public class AUTH_REPLY : WlinkPacket
    {
        public string SrcId { get; set; }
        public string AuthKey { get; set; }
        public int Status { get; set; }

        public override PacketType PacketType => PacketType.AUTH_REPLY;

        public override string ToString()
        {
            return $"AUTH_REPLY, status: {(ResponseType)Status}, srcId: {SrcId}";
        }
    }
}
