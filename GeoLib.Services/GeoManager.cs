using GeoLib.Contracts;
using System;
using System.Collections.Generic;

namespace GeoLib.Services
{
    public class GeoManager : IGeoService
    {
        public IEnumerable<string> GetStates(bool primaryOnly)
        {
            throw new NotImplementedException();
        }

        public ZipCodeData GetZipInfo(string zip)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ZipCodeData> GetZips(string state)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ZipCodeData> GetZips(string zip, int range)
        {
            throw new NotImplementedException();
        }
    }
}
