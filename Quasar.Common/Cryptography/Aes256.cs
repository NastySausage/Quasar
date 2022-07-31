using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Quasar.Common
{
    public class Aes256
    {
        private readonly Aes _aes = Aes.Create();
        public Aes256(string key)
        {
            _aes.Key = key.GetSHA256Hash();
            _aes.IV=new byte[] { 7, 203, 246, 228, 146, 184, 75, 125, 240, 194, 101, 35, 171, 25, 206, 4 };
        }
        public byte[] Encrypt(byte[] data)
        {
            return new CryptoStream(new MemoryStream(data), _aes.CreateEncryptor(), CryptoStreamMode.Read).ReadToEnd();
        }
        public byte[] Decrypt(byte[] data)
        {
            return new CryptoStream(new MemoryStream(data), _aes.CreateDecryptor(), CryptoStreamMode.Read).ReadToEnd();
        }
        public string Encrypt(string input)
        {
            return Convert.ToBase64String(Encrypt(Encoding.UTF8.GetBytes(input)));
        }
        public string Decrypt(string input)
        {
            return Encoding.UTF8.GetString(Decrypt(Convert.FromBase64String(input)));
        }
    }
}
