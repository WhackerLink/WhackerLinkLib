namespace WhackerLinkLib.Models.IOSP
{
    public class GRP_VCH_UPD : WlinkPacket
    {
        public VoiceChannel VoiceChannel { get; set; }

        public override PacketType PacketType => PacketType.GRP_VCH_UPD;

        public override string ToString()
        {
            return $"GRP_VCH_UPD, Channel: {VoiceChannel.Frequency}, SrcId: {VoiceChannel.SrcId}, DstId: {VoiceChannel.DstId}";
        }
    }
}
