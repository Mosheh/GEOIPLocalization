using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEOIPLocalization.Net.Domain
{
    public interface IIPLocationService
    {
        /// <summary>
        /// Get information of geo localization by IP Address
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        IPInformation GetLocalization(string ip);

        /// <summary>
        /// Get internet Address
        /// </summary>
        /// <returns></returns>
        string GetRemoteInternetAddress();

        /// <summary>
        /// Get actual localization by Remote IP
        /// </summary>
        /// <returns></returns>
        IPInformation GetLocalization();
    }
}
