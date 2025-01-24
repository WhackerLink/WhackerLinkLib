namespace WhackerLinkLib.Models.IOSP
{
    public class NET_FAIL : WlinkPacket
    {
        public byte Status { get; set; } = 0xFF; // 0x00 back up, 0x01 down

        public override PacketType PacketType => PacketType.NET_FAIL;

        public override string ToString()
        {
            string status = "UNKOWN";

            if (Status == 0x00)
            {
                status = "Primary back";
            } else if (Status == 0x01) {
                status = "Master revert";
            }

            return $"NET_FAIL, Status: {status}";
        }
    }
}
