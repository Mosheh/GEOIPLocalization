using GEOIPLocalization.Net.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace GEOIPLocalization.Net.Services
{
    public class LocalizationService : IIPLocationService
    {
        public IPInformation GetLocalization()
        {
            var ip = GetRemoteInternetAddress();
            return GetLocalization(ip);
        }

        public IPInformation GetLocalization(string ip)
        {
            using (WebClient wc = new WebClient())
            {

                var json = wc.DownloadString($"http://ipinfo.io/{ip}/geo");
                IPInformation ipInf = new IPInformation();
                MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(json));
                DataContractJsonSerializer ser = new DataContractJsonSerializer(ipInf.GetType());
                ipInf = ser.ReadObject(ms) as IPInformation;
                ms.Close();
                return ipInf;
            }

        }

        public string GetRemoteInternetAddress()
        {
            using (WebClient wc = new WebClient())
            {
                var req = wc.DownloadString("http://icanhazip.com/");
                return req;
            }
            return string.Empty;
        }
    }
}
