namespace WhackerLinkLib.Models.IOSP
{
    public class STS_BCAST : WlinkPacket
    {
        public Site Site { get; set; }
        public SiteStatus Status { get; set; }

        public override PacketType PacketType => PacketType.STS_BCAST;

        public override string ToString()
        {
            return $"STS_BCAST, Name: {Site.Name}, CC: {Site.ControlChannel}, SID: {Site.SiteID}, SysID: {Site.SystemID}, Status {Status}";
        }
    }
}
