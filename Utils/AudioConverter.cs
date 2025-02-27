/*
* WhackerLink - WhackerLinkLib
*
* This program is free software: you can redistribute it and/or modify
* it under the terms of the GNU General Public License as published by
* the Free Software Foundation, either version 3 of the License, or
* (at your option) any later version.
*
* This program is distributed in the hope that it will be useful,
* but WITHOUT ANY WARRANTY; without even the implied warranty of
* MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
* GNU General Public License for more details.
*
* You should have received a copy of the GNU General Public License
* along with this program.  If not, see <http://www.gnu.org/licenses/>.
* 
* Copyright (C) 2024 Caleb, K4PHP
* 
*/

namespace WhackerLinkLib.Utils
{
    /// <summary>
    /// Helper to convert audio between different chunk sizes
    /// </summary>
    public static class AudioConverter
    {
        public const int OriginalPcmLength = 1600;
        public const int ExpectedPcmLength = 320;

        /// <summary>
        /// Helper to go from a big chunk size to smaller
        /// </summary>
        /// <param name="audioData"></param>
        /// <returns></returns>
        public static List<byte[]> SplitToChunks(byte[] audioData, int OgLength = OriginalPcmLength, int ExepcetedLength = ExpectedPcmLength)
        {
            List<byte[]> chunks = new List<byte[]>();

            if (audioData.Length != OgLength)
            {
                Console.WriteLine($"Invalid PCM length: {audioData.Length}, expected: {OgLength}");
                return chunks;
            }

            for (int offset = 0; offset < OgLength; offset += ExepcetedLength)
            {
                byte[] chunk = new byte[ExpectedPcmLength];
                Buffer.BlockCopy(audioData, offset, chunk, 0, ExepcetedLength);
                chunks.Add(chunk);
            }

            return chunks;
        }

        /// <summary>
        /// Helper to go from small chunks to a big chunk
        /// </summary>
        /// <param name="chunks"></param>
        /// <returns></returns>
        public static byte[] CombineChunks(List<byte[]> chunks, int OgLength = OriginalPcmLength, int ExepcetedLength = ExpectedPcmLength)
        {
            if (chunks.Count * ExepcetedLength != OgLength)
            {
                Console.WriteLine($"Invalid number of chunks: {chunks.Count}, expected total length: {OgLength}");
                return null;
            }

            byte[] combined = new byte[OgLength];
            int offset = 0;

            foreach (var chunk in chunks)
            {
                Buffer.BlockCopy(chunk, 0, combined, offset, ExepcetedLength);
                offset += ExepcetedLength;
            }

            return combined;
        }

        /// <summary>
        /// From https://github.com/W3AXL/rc2-dvm/blob/main/rc2-dvm/Audio.cs
        /// </summary>
        /// <param name="pcm16"></param>
        /// <returns></returns>
        public static float[] PcmToFloat(short[] pcm16)
        {
            float[] floats = new float[pcm16.Length];
            for (int i = 0; i < pcm16.Length; i++)
            {
                float v = (float)pcm16[i] / (float)short.MaxValue;
                if (v > 1) { v = 1; }
                if (v < -1) { v = -1; }
                floats[i] = v;
            }
            return floats;
        }
    }
}