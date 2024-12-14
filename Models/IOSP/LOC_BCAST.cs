namespace WhackerLinkLib.Models.IOSP
{
    public class LOC_BCAST : WlinkPacket
    {
        public string SrcId { get; set; }
        public Site Site { get; set; }
        public string Lat { get; set; }
        public string Long { get; set; }

        public override PacketType PacketType => PacketType.LOC_BCAST;

        public override string ToString()
        {
            return $"LOC_BCAST, srcId: {SrcId}, Lat: {Lat}, Long: {Long}";
        }
    }
}
