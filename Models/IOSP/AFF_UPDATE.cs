using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhackerLinkLib.Models;


#nullable disable

namespace WhackerLinkLib.Models.IOSP
{
    public class AFF_UPDATE : WlinkPacket
    {
        public List<Affiliation> Affiliations;

        public override PacketType PacketType => PacketType.AFF_UPDATE;
    }
}