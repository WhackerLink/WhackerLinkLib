using System.Speech.Synthesis;

#nullable disable

namespace WhackerLinkLib.Utils
{
    public static class Util
    {
        [System.Runtime.Versioning.SupportedOSPlatform("windows")]
        public static void SpeakText(string text)
        {
            using (SpeechSynthesizer synthesizer = new SpeechSynthesizer())
            {
                synthesizer.Volume = 100;  // 0...100
                synthesizer.Rate = 0;     // -10...10

                synthesizer.Speak(text);
            }
        }
    }
}
