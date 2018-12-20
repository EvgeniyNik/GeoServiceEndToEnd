using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GeoLib.WindowsHost.Services
{
    [DataContract(Name = "MyRequest100500", Namespace = "HDD")]
    public class MyRequest
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int Age { get; set; }
    }
}
