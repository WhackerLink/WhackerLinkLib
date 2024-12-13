using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhackerLinkLib.Models.IOSP
{
    public class U_REG_RSP : WlinkPacket
    {
        public string SrcId { get; set; }
        public string SysId { get; set; }
        public string Wacn { get; set; }
        public int Status { get; set; }

        public override PacketType PacketType => PacketType.U_REG_REQ;

        public override string ToString()
        {
            return $"U_REG_RSP, status: {(ResponseType)Status}, srcId: {SrcId}, SysId: {SysId}";
        }
    }
}