using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhackerLinkLib.Models.IOSP
{
    public class SITE_BCAST : WlinkPacket
    {
        public List<Site> Sites;

        public override PacketType PacketType => PacketType.SITE_BCAST;
    }
}
