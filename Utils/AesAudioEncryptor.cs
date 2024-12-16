using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace WhackerLinkLib.Utils
{
    public class AesAudioEncryptor
    {
        private readonly byte[] Key;

        public AesAudioEncryptor(string key)
        {
            if (key.Length != 32)
                throw new ArgumentException("Key must be 32 characters (256 bits)");
            Key = Encoding.UTF8.GetBytes(key);
        }

        public (byte[] EncryptedData, byte[] IV) Encrypt(byte[] buffer)
        {
            using (var aes = Aes.Create())
            {
                aes.Key = Key;
                aes.GenerateIV();
                using (var encryptor = aes.CreateEncryptor())
                {
                    var encrypted = PerformCryptography(buffer, encryptor);
                    return (encrypted, aes.IV);
                }
            }
        }

        public byte[] Decrypt(byte[] encryptedData, byte[] iv)
        {
            using (var aes = Aes.Create())
            {
                aes.Key = Key;
                aes.IV = iv;
                using (var decryptor = aes.CreateDecryptor())
                {
                    return PerformCryptography(encryptedData, decryptor);
                }
            }
        }

        private byte[] PerformCryptography(byte[] data, ICryptoTransform cryptoTransform)
        {
            using (var memoryStream = new MemoryStream())
            {
                using (var cryptoStream = new CryptoStream(memoryStream, cryptoTransform, CryptoStreamMode.Write))
                {
                    cryptoStream.Write(data, 0, data.Length);
                    cryptoStream.FlushFinalBlock();
                    return memoryStream.ToArray();
                }
            }
        }
    }
}
