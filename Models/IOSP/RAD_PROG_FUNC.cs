using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhackerLinkLib.Models.IOSP
{
    public class RAD_PROG_FUNC : WlinkPacket
    {
        public string SrcId { get; set; }
        public RadProgFunctions Function { get; set; }
        public RadProgCommandTypes Command { get; set; }
        public RadProgReasons Reason { get; set; }
        public string Data { get; set; }

        public override PacketType PacketType => PacketType.RAD_PROG_FUNC;

        public override string ToString()
        {
            return $"RAD_PROG_FUNC, Function: {Function}, Command: {Command}, Reason {Reason} SrcId: {SrcId}";
        }
    }
}
