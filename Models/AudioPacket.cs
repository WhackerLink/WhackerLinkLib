using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhackerLinkLib.Models
{
    public class AudioPacket : WlinkPacket
    {
        public byte[] Data {  get; set; }
        public VoiceChannel VoiceChannel { get; set; }
        public Site Site { get; set; }
        public byte[] MI {  get; set; } // NOTE: When MI is not set, it is assumed not encrypted

        public override PacketType PacketType => PacketType.AUDIO_DATA;
    }
}
