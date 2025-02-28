using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace WhackerLinkLib.Utils
{
    /// <summary>
    /// From https://github.com/W3AXL/rc2-dvm/blob/main/rc2-dvm/Audio.cs
    /// No license info or copyright header was present, but attempting to give credit where credit is due.
    /// </summary>
    public static class MBEToneGenerator
    {
        /// <summary>
        /// Encodes a single tone to an AMBE tone frame
        /// </summary>
        /// <param name="tone_freq_hz"></param>
        /// <param name="tone_amplitude"></param>
        /// <param name="codeword"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static void AmbeEncodeSingleTone(int tone_freq_hz, char tone_amplitude, [Out] byte[] codeword)
        {
            // U bit vectors
            // u0 and u1 are 12 bits
            // u2 is 11 bits
            // u3 is 14 bits
            // total length is 49 bits
            ushort[] u = new ushort[4];

            // Convert the tone frequency to the nearest tone index
            uint tone_idx = (uint)((float)tone_freq_hz / 31.25f);

            // Validate tone index
            if (tone_idx < 5 || tone_idx > 122)
            {
                throw new ArgumentOutOfRangeException($"Tone index for frequency out of range!");
            }

            // Validate amplitude value
            if (tone_amplitude > 127)
            {
                throw new ArgumentOutOfRangeException("Tone amplitude must be between 0 and 127!");
            }

            // Make sure tone index only has 7 bits (it should but we make sure :) )
            tone_idx &= 0b01111111;

            // Encode u vectors per TIA-102.BABA-1 section 7.2

            // u0[11-6] are always 1 to indicate a tone, so we left-shift 63u (0x00111111) a full byte (8 bits)
            u[0] |= (ushort)(63 << 8);

            // u0[5-0] are AD (tone amplitude byte) bits 6-1
            u[0] |= (ushort)(tone_amplitude >> 1);

            // u1[11-4] are tone index bits 7-0 (the full byte)
            u[1] |= (ushort)(tone_idx << 4);

            // u1[3-0] are tone index bits 7-4
            u[1] |= (ushort)(tone_idx >> 4);

            // u2[10-7] are tone index bits 3-0
            u[2] |= (ushort)((tone_idx & 0b00001111) << 7);

            // u2[6-0] are tone index bits 7-1
            u[2] |= (ushort)(tone_idx >> 1);

            // u3[13] is the last bit of the tone index
            u[3] |= (ushort)((tone_idx & 0b1) << 13);

            // u3[12-5] is the full tone index byte
            u[3] |= (ushort)(tone_idx << 5);

            // u3[4] is the last bit of the amplitude byte
            u[3] |= (ushort)((tone_amplitude & 0b1) << 4);

            // u3[3-0] is always 0 so we don't have to do anything here

            // Convert u buffer to byte
            Buffer.BlockCopy(u, 0, codeword, 0, 8);
        }

        /// <summary>
        /// Encode a single tone to an IMBE codeword sequence using a lookup table
        /// </summary>
        /// <param name="tone_freq_hz"></param>
        /// <param name="codeword"></param>
        public static void IMBEEncodeSingleTone(ushort tone_freq_hz, [Out] byte[] codeword)
        {
            // Find nearest tone in the lookup table
            List<ushort> tone_keys = VocoderToneLookupTable.IMBEToneFrames.Keys.ToList();
            ushort nearest = tone_keys.Aggregate((x, y) => Math.Abs(x - tone_freq_hz) < Math.Abs(y - tone_freq_hz) ? x : y);
            byte[] tone_codeword = VocoderToneLookupTable.IMBEToneFrames[nearest];
            Array.Copy(tone_codeword, codeword, tone_codeword.Length);
        }
    }
}
