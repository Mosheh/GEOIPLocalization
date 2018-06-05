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
            try
            {
                using (WebClient wc = new WebClient())
                {
                    var jsonData = wc.DownloadData($"http://ipinfo.io/{ip}/geo");
                    var json = Encoding.UTF8.GetString(jsonData);
                    IPInformation ipInf = new IPInformation();
                    MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(json));
                    DataContractJsonSerializer ser = new DataContractJsonSerializer(ipInf.GetType());
                    ipInf = ser.ReadObject(ms) as IPInformation;
                    ms.Close();
                    return ipInf;
                }
            }
            catch (InvalidOperationException ex)
            {

                throw new Exceptions.InvalidServerReponse(ex.Message);
            }

            catch (Exception ex)
            {
                throw ex;
            }
           

        }

        public string GetRemoteInternetAddress()
        {
            try
            {
                using (WebClient wc = new WebClient())
            {
                var req = wc.DownloadString("http://icanhazip.com/");
                return req;
            }
            }
            catch (InvalidOperationException ex)
            {

                throw new Exceptions.InvalidServerReponse(ex.Message);
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
