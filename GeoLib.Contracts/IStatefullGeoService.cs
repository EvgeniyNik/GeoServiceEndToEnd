using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace GeoLib.Contracts
{
    [ServiceContract]
    public interface IStatefullGeoService
    {
        [OperationContract]
        [FaultContract(typeof(ArgumentException))]
        [FaultContract(typeof(ErrorResponse))]
        void PushZip(string zipCode);
        [OperationContract]
        ZipCodeData GetZipInfo();
        [OperationContract]
        IEnumerable<ZipCodeData> GetZips(int range);
    }
}
