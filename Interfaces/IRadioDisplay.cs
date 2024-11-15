using WhackerLinkLib.Models;
using WhackerLinkLib.Models.Radio;

namespace WhackerLinkLib.Interfaces
{
    public interface IRadioDisplay
    {
        void SetLine1Text(string text, bool forMenu = false);
        void SetLine2Text(string text, bool forMenu = false);
        void SetLine3Text(string text, bool forMenu = false);
        void SetRssiSource(string name);
        void MasterConnection(Codeplug.System system);
        void KillMasterConnection();
        void SendUnitRegistrationRequest();
        void SendGroupAffiliationRequest();
        bool PowerOn { get; }
        bool IsInRange { get; set; }
        string MyRid { get; set; }
        string CurrentTgid { get; set; }
        Site CurrentSite { get; set; }
        Codeplug.System CurrentSystem { get; set; }
    }
}