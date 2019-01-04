using GeoLib.Contracts;
using System;
using System.Collections.Generic;
using GeoLib.Data;
using System.Threading;

namespace GeoLib.Services
{
    public class GeoManager : IGeoService
    {
        private IZipCodeRepository zipCodeRepository;
        private IStateRepository stateRepository;

        public GeoManager()
        {
        }

        public GeoManager(IZipCodeRepository zipCodeRepository)
        {
            this.zipCodeRepository = zipCodeRepository;
        }

        public GeoManager(IStateRepository stateRepository)
        {
            this.stateRepository = stateRepository;
        }

        public GeoManager(IZipCodeRepository zipCodeRepository, IStateRepository stateRepository)
        {
            this.zipCodeRepository = zipCodeRepository;
            this.stateRepository = stateRepository;
        }

        
        public ZipCodeData GetZipInfo(string zip)
        {
            Thread.Sleep(6000);

            ZipCodeData zipCodeData = null;

            IZipCodeRepository repository = this.zipCodeRepository ?? new ZipCodeRepository();
            ZipCode zipCodeEntity = repository.GetByZip(zip);

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

        public IEnumerable<string> GetStates(bool primaryOnly)
        {
            List<string> stateData = new List<string>();

            IStateRepository repository = stateRepository ?? new StateRepository();

            IEnumerable<State> states = repository.Get(primaryOnly);
            if (states != null)
            {
                foreach (var state in states)
                    stateData.Add(state.Abbreviation);
            }

            return stateData;
        }
        
        public IEnumerable<ZipCodeData> GetZips(string state)
        {
            List<ZipCodeData> zipCodeData = new List<ZipCodeData>();

            IZipCodeRepository repository = zipCodeRepository ?? new ZipCodeRepository();
            var zips = repository.GetByState(state);
            if (zips != null)
            {
                foreach (var zipCode in zips)
                {
                    zipCodeData.Add(new ZipCodeData()
                    {
                        City =  zipCode.City,
                        State = zipCode.State.Abbreviation,
                        ZipCode = zipCode.Zip
                    });
                }
            }

            return zipCodeData;
        }

        public IEnumerable<ZipCodeData> GetZips(string zip, int range)
        {
            List<ZipCodeData> zipCodeData = new List<ZipCodeData>();

            IZipCodeRepository repository = zipCodeRepository ?? new ZipCodeRepository();
            var zipEntity = repository.GetByZip(zip);
            var zips = repository.GetZipsForRange(zipEntity, range);
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
    }
}
