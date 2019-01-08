using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace GeoLib.Contracts
{
    [ServiceContract (SessionMode = SessionMode.Required)]
    public interface IStatefullGeoService
    {
        [OperationContract(IsInitiating = false)]
        void PushZip(string zipCode);
        [OperationContract(IsInitiating = true)]
        ZipCodeData GetZipInfo();
        [OperationContract(IsInitiating = true)]
        IEnumerable<ZipCodeData> GetZips(int range);
    }
}
