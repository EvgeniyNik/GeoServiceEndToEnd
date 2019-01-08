using GeoLib.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace GeoLib.Proxies
{
    public class StatefullGeoClient : ClientBase<IStatefullGeoService>, IStatefullGeoService
    {
        public ZipCodeData GetZipInfo()
        {
            return Channel.GetZipInfo();
        }

        public IEnumerable<ZipCodeData> GetZips(int range)
        {
            return Channel.GetZips(range);
        }

        public void PushZip(string zipCode)
        {
            Channel.PushZip(zipCode);
        }
    }
}
