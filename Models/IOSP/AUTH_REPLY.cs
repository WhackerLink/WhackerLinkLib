using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhackerLinkLib.Models.IOSP
{
    public class AUTH_REPLY
    {
        public string SrcId { get; set; }
        public string AuthKey { get; set; }
        public int Status { get; set; }

        public override string ToString()
        {
            return $"AUTH_REPLY, status: {(ResponseType)Status}, srcId: {SrcId}";
        }
    }
}
