using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhackerLinkLib.Models
{
    /// <summary>
    /// List of special function types
    /// </summary>
    public enum SpecFuncType
    {
        RESERVED = 0x00,
        RID_INHIBIT = 0x01,
        RID_UNINHIBIT = 0x02,
        UNKOWN = 0xFF
    }
}
