﻿using System.Globalization;
using System.IO;
using System.Net;
using System;
using Newtonsoft.Json;
using Quasar.Common;

namespace Quasar.Client
{

    /// <summary>
    /// Stores the IP geolocation information.
    /// </summary>
    public class GeoInformation
    {
        public string IpAddress { get; set; }
        public string Country { get; set; }
        public string CountryCode { get; set; }
        public string Timezone { get; set; }
        public string Asn { get; set; }
        public string Isp { get; set; }
        public int ImageIndex { get; set; }
    }
    public class GeoResponse
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("data")]
        public DataObject Data { get; set; }
    }

    public class DataObject
    {
        [JsonProperty("geo")]
        public LocationData Geo { get; set; }
    }
    public class LocationData
    {
        [JsonProperty("host")]
        public string Host;

        [JsonProperty("ip")]
        public string Ip;

        [JsonProperty("rdns")]
        public string Rdns;

        [JsonProperty("asn")]
        public int Asn;

        [JsonProperty("isp")]
        public string Isp;

        [JsonProperty("country_name")]
        public string CountryName;

        [JsonProperty("country_code")]
        public string CountryCode;

        [JsonProperty("region_name")]
        public string RegionName;

        [JsonProperty("region_code")]
        public string RegionCode;

        [JsonProperty("city")]
        public string City;

        [JsonProperty("postal_code")]
        public string PostalCode;

        [JsonProperty("continent_name")]
        public string ContinentName;

        [JsonProperty("continent_code")]
        public string ContinentCode;

        [JsonProperty("latitude")]
        public double Latitude;

        [JsonProperty("longitude")]
        public double Longitude;

        [JsonProperty("metro_code")]
        public object MetroCode;

        [JsonProperty("timezone")]
        public string Timezone;

        [JsonProperty("datetime")]
        public string Datetime;
    }
    /// <summary>
    /// Class to retrieve the IP geolocation information.
    /// </summary>
    public class GeoInformationRetriever
    {
        /// <summary>
        /// List of all available flag images on the server side.
        /// </summary>
        private readonly string[] _imageList =
        {
            "ad", "ae", "af", "ag", "ai", "al",
            "am", "an", "ao", "ar", "as", "at", "au", "aw", "ax", "az", "ba",
            "bb", "bd", "be", "bf", "bg", "bh", "bi", "bj", "bm", "bn", "bo",
            "br", "bs", "bt", "bv", "bw", "by", "bz", "ca", "catalonia", "cc",
            "cd", "cf", "cg", "ch", "ci", "ck", "cl", "cm", "cn", "co", "cr",
            "cs", "cu", "cv", "cx", "cy", "cz", "de", "dj", "dk", "dm", "do",
            "dz", "ec", "ee", "eg", "eh", "england", "er", "es", "et",
            "europeanunion", "fam", "fi", "fj", "fk", "fm", "fo", "fr", "ga",
            "gb", "gd", "ge", "gf", "gh", "gi", "gl", "gm", "gn", "gp", "gq",
            "gr", "gs", "gt", "gu", "gw", "gy", "hk", "hm", "hn", "hr", "ht",
            "hu", "id", "ie", "il", "in", "io", "iq", "ir", "is", "it", "jm",
            "jo", "jp", "ke", "kg", "kh", "ki", "km", "kn", "kp", "kr", "kw",
            "ky", "kz", "la", "lb", "lc", "li", "lk", "lr", "ls", "lt", "lu",
            "lv", "ly", "ma", "mc", "md", "me", "mg", "mh", "mk", "ml", "mm",
            "mn", "mo", "mp", "mq", "mr", "ms", "mt", "mu", "mv", "mw", "mx",
            "my", "mz", "na", "nc", "ne", "nf", "ng", "ni", "nl", "no", "np",
            "nr", "nu", "nz", "om", "pa", "pe", "pf", "pg", "ph", "pk", "pl",
            "pm", "pn", "pr", "ps", "pt", "pw", "py", "qa", "re", "ro", "rs",
            "ru", "rw", "sa", "sb", "sc", "scotland", "sd", "se", "sg", "sh",
            "si", "sj", "sk", "sl", "sm", "sn", "so", "sr", "st", "sv", "sy",
            "sz", "tc", "td", "tf", "tg", "th", "tj", "tk", "tl", "tm", "tn",
            "to", "tr", "tt", "tv", "tw", "tz", "ua", "ug", "um", "us", "uy",
            "uz", "va", "vc", "ve", "vg", "vi", "vn", "vu", "wales", "wf",
            "ws", "ye", "yt", "za", "zm", "zw"
        };

        /// <summary>
        /// Retrieves the IP geolocation information.
        /// </summary>
        /// <returns>The retrieved IP geolocation information.</returns>
        public GeoInformation Retrieve()
        {
            var geo = TryRetrieveOnline() ?? TryRetrieveLocally();

            if (string.IsNullOrEmpty(geo.IpAddress))
                geo.IpAddress = TryGetWanIp();

            geo.IpAddress = (string.IsNullOrEmpty(geo.IpAddress)) ? "Unknown" : geo.IpAddress;
            geo.Country = (string.IsNullOrEmpty(geo.Country)) ? "Unknown" : geo.Country;
            geo.CountryCode = (string.IsNullOrEmpty(geo.CountryCode)) ? "-" : geo.CountryCode;
            geo.Timezone = (string.IsNullOrEmpty(geo.Timezone)) ? "Unknown" : geo.Timezone;
            geo.Asn = (string.IsNullOrEmpty(geo.Asn)) ? "Unknown" : geo.Asn;
            geo.Isp = (string.IsNullOrEmpty(geo.Isp)) ? "Unknown" : geo.Isp;

            geo.ImageIndex = 0;
            for (int i = 0; i < _imageList.Length; i++)
            {
                if (_imageList[i] == geo.CountryCode.ToLower())
                {
                    geo.ImageIndex = i;
                    break;
                }
            }
            if (geo.ImageIndex == 0) geo.ImageIndex = 247; // question icon

            return geo;
        }

        /// <summary>
        /// Tries to retrieve the geolocation information online.
        /// </summary>
        /// <returns>The retrieved geolocation information if successful, otherwise <c>null</c>.</returns>
        private GeoInformation TryRetrieveOnline()
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://tools.keycdn.com/geo.json");
                request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:76.0) Gecko/20100101 Firefox/76.0";
                request.Proxy = null;
                request.Timeout = 10000;

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    using (Stream dataStream = response.GetResponseStream())
                    {
                        var geoInfo = JsonConvert.DeserializeObject<GeoResponse>(dataStream.ReadToEnd().GetString());

                        GeoInformation g = new GeoInformation
                        {
                            IpAddress = geoInfo.Data.Geo.Ip,
                            Country = geoInfo.Data.Geo.CountryName,
                            CountryCode = geoInfo.Data.Geo.CountryCode,
                            Timezone = geoInfo.Data.Geo.Timezone,
                            Asn = geoInfo.Data.Geo.Asn.ToString(),
                            Isp = geoInfo.Data.Geo.Isp
                        };

                        return g;
                    }
                }
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Tries to retrieve the geolocation information locally.
        /// </summary>
        /// <returns>The retrieved geolocation information if successful, otherwise <c>null</c>.</returns>
        private GeoInformation TryRetrieveLocally()
        {
            try
            {
                GeoInformation g = new GeoInformation();

                // use local information
                var cultureInfo = CultureInfo.CurrentUICulture;
                var region = new RegionInfo(cultureInfo.LCID);

                g.Country = region.DisplayName;
                g.CountryCode = region.TwoLetterISORegionName;
                g.Timezone = DateTimeHelper.GetLocalTimeZone();

                return g;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Tries to retrieves the WAN IP.
        /// </summary>
        /// <returns>The WAN IP as string if successful, otherwise <c>null</c>.</returns>
        private string TryGetWanIp()
        {
            string wanIp = "";

            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://api.ipify.org/");
                request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:76.0) Gecko/20100101 Firefox/76.0";
                request.Proxy = null;
                request.Timeout = 5000;

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    using (Stream dataStream = response.GetResponseStream())
                    {
                        using (StreamReader reader = new StreamReader(dataStream))
                        {
                            wanIp = reader.ReadToEnd();
                        }
                    }
                }
            }
            catch
            {
            }

            return wanIp;
        }
    }

    /// <summary>
    /// Factory to retrieve and cache the last IP geolocation information for <see cref="MINIMUM_VALID_TIME"/> minutes.
    /// </summary>
    public static class GeoInformationFactory
    {
        /// <summary>
        /// Retriever used to get geolocation information about the WAN IP address.
        /// </summary>
        private static readonly GeoInformationRetriever Retriever = new GeoInformationRetriever();

        /// <summary>
        /// Used to cache the latest IP geolocation information.
        /// </summary>
        private static GeoInformation _geoInformation;

        /// <summary>
        /// Time of the last successful location retrieval.
        /// </summary>
        private static DateTime _lastSuccessfulLocation = new DateTime(1, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        /// <summary>
        /// The minimum amount of minutes a successful IP geolocation retrieval is valid.
        /// </summary>
        private const int MINIMUM_VALID_TIME = 60 * 12;

        /// <summary>
        /// Gets the IP geolocation information, either cached or freshly retrieved if more than <see cref="MINIMUM_VALID_TIME"/> minutes have passed.
        /// </summary>
        /// <returns>The latest IP geolocation information.</returns>
        public static GeoInformation GetGeoInformation()
        {
            var passedTime = new TimeSpan(DateTime.UtcNow.Ticks - _lastSuccessfulLocation.Ticks);

            if (_geoInformation == null || passedTime.TotalMinutes > MINIMUM_VALID_TIME)
            {
                _geoInformation = Retriever.Retrieve();
                _lastSuccessfulLocation = DateTime.UtcNow;
            }

            return _geoInformation;
        }
    }
}
