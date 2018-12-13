using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GeoLib.WindowsHost.Services
{
    [DataContract]
    public class MyTempContract2
    {
        [DataMember]
        public string Message { get; set; }
    }
}
