using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GeoLib.Proxies
{
    [DataContract(Name = "Dich", Namespace = "HDD")]
    public class MyRequest2
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int Age { get; set; }
        [DataMember]
        public string Genger { get; set; }
    }
}
