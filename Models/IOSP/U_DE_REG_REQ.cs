using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhackerLinkLib.Models;

namespace WhackerLinkLib.Models.IOSP
{
    public class U_DE_REG_REQ : WlinkPacket
    {
        public string SrcId { get; set; }
        public string SysId { get; set; }
        public string Wacn { get; set; }
        public Site Site { get; set; }

        public override PacketType PacketType => PacketType.U_DE_REG_REQ;

        public override string ToString()
        {
            return $"U_DE_REG_REQ, srcId: {SrcId}, SysId: {SysId}";
        }
    }
}
