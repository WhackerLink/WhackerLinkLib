﻿/*
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

using System.Speech.Synthesis;

namespace WhackerLinkLib.Utils
{
    public static class Util
    {
        /// <summary>
        /// Helper to speak text
        /// </summary>
        /// <param name="text"></param>
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
