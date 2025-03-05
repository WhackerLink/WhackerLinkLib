using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhackerLinkLib.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class AuthKeyFileEntry
    {
        public bool Enabled { get; set; }
        public string Alias { get; set; }
        public string AuthKey { get; set; }
    }
}
