using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GeoLib.Contracts
{
    [DataContract]
    public class ErrorResponse
    {
        [DataMember]
        public string Message { get; set; }
        [DataMember]
        public DateTime Time { get; set; }
    }
}
