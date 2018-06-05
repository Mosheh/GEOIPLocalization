using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GEOIPLocalization.Net.Domain
{
    [DataContract]
    public class IPInformation
    {
        [DataMember(Name ="ip")]
        public string Ip { get; set; }
        [DataMember(Name ="city")]
        public string City { get; set; }
        [DataMember(Name = "region")]
        public string Region { get; set; }
        [DataMember(Name = "country")]
        public string Country { get; set; }
        [DataMember(Name = "loc")]
        public string Localization { get; set; }
        [DataMember(Name = "postal")]
        public string Postal { get; set; }
        [DataMember(Name ="phone")]
        public string Phone { get; set; }

    }
}
