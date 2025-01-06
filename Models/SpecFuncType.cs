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
    public static class SpecFuncType
    {
        public static byte RESERVED = 0x00;
        public static byte RID_INHIBIT = 0x01;
        public static byte RID_UNINHIBIT = 0x02;
        public static byte UNKOWN = 0xFF;
    }
}
