/*
* WhackerLink - WhackerLinkServer
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
* Copyright (C) 2025 Caleb, K4PHP
* 
*/
    
using System.Security.Cryptography;
using System.Text;

namespace WhackerLinkLib.Managers
{
    public class AuthKeyManager
    {
        private readonly Dictionary<string, HashSet<string>> masterAuthKeys;

        public AuthKeyManager(Dictionary<string, List<string>> authKeys)
        {
            masterAuthKeys = authKeys.ToDictionary(
                kvp => kvp.Key,
                kvp => new HashSet<string>(kvp.Value.Select(HashKey))
            );
        }

        public bool IsValidKey(string masterName, string providedHashedKey)
        {
            return masterAuthKeys.TryGetValue(masterName, out var keys) && keys.Contains(providedHashedKey);
        }

        public static string HashKey(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
                return string.Empty;

            key = key.Trim();

            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(key);
                byte[] hashBytes = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hashBytes);
            }
        }
    }
}
