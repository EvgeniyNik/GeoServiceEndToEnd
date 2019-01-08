using GeoLib.Contracts;
using GeoLib.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GeoLib.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession,
        ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class StatefullGeoManager : IStatefullGeoService
    {
        private ZipCode zipCodeEntity;
        private int counter = 0;

        public ZipCodeData GetZipInfo()
        {
            ZipCodeData zipCodeData = null;

            if (zipCodeEntity != null)
            {
                zipCodeData = new ZipCodeData()
                {
                    City = zipCodeEntity.City,
                    State = zipCodeEntity.State.Abbreviation,
                    ZipCode = zipCodeEntity.Zip
                };
            }

            return zipCodeData;
        }

        public IEnumerable<ZipCodeData> GetZips(int range)
        {
            List<ZipCodeData> zipCodeData = new List<ZipCodeData>();

            ZipCodeRepository repository = new ZipCodeRepository();
            var zips = repository.GetZipsForRange(zipCodeEntity, range);
            if (zips != null)
            {
                foreach (var zipCode in zips)
                {
                    zipCodeData.Add(new ZipCodeData()
                    {
                        City = zipCode.City,
                        State = zipCode.State.Abbreviation,
                        ZipCode = zipCode.Zip
                    });
                }
            }

            return zipCodeData;
        }

        public void PushZip(string zipCode)
        {
            ZipCodeRepository repository = new ZipCodeRepository();

            zipCodeEntity = repository.GetByZip(zipCode);

            counter++;
            MessageBox.Show($"ZipCode:{zipCode}. Counter:{counter}");
        }
    }
}
