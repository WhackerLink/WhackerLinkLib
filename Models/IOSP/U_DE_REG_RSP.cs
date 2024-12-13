using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhackerLinkLib.Models.IOSP
{
    public class U_DE_REG_RSP : WlinkPacket
    {
        public string SrcId { get; set; }
        public string SysId { get; set; }
        public string Wacn { get; set; }
        public int Status { get; set; }

        public override PacketType PacketType => PacketType.U_DE_REG_RSP;

        public override string ToString()
        {
            return $"U_DE_REG_RSP, srcId: {SrcId}, SysId: {SysId}";
        }
    }
}