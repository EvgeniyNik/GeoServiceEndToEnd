using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GeoLib.Proxies
{
    [DataContract]
    public class MyResponse
    {
        [DataMember]
        public string Message { get; set; }
    }
}
