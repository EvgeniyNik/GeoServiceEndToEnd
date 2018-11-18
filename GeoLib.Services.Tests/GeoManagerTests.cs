using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeoLib.Contracts;
using GeoLib.Data;
using NSubstitute;
using Xunit;

namespace GeoLib.Services.Tests
{
    public class GeoManagerTests
    {
        [Fact]
        public void TestZipCodeRetrieval()
        {
            IZipCodeRepository repository = Substitute.For<IZipCodeRepository>();
            ZipCode zipCode = new ZipCode()
            {
                City = "LINCOLN PARK",
                State = new State() { Abbreviation = "NJ"},
                Zip = "07035"
            };
            repository.GetByZip("07035").Returns(zipCode);
            IGeoService geoManager = new GeoManager(repository);

            var data = geoManager.GetZipInfo(zipCode.Zip);

            Assert.Equal(zipCode.City, data.City);
            Assert.Equal(zipCode.State.Abbreviation, data.State);
        }
    }
}
