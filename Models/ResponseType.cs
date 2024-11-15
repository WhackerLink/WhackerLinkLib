using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhackerLinkLib.Models
{
    public enum ResponseType
    {
        GRANT,
        REJECT,
        DENY,
        REFUSE,
        FAIL,
        UNKOWN = 0xFF
    }
}
