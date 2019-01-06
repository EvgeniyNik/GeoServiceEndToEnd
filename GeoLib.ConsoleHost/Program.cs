using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;
using GeoLib.Contracts;
using GeoLib.Services;

namespace GeoLib.ConsoleHost
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost geoManagerHost = new ServiceHost(typeof(GeoManager));
                //new Uri("http://localhost:8080"),
                //new Uri("net.tcp://localhost:8009"));

            #region Создание endpoint в коде

            //string address = "net.tcp://localhost:8009/GeoService";
            //Binding binding = new WSHttpBinding();
            //Type contract = typeof(IGeoService);

            //geoManagerHost.AddServiceEndpoint(contract, binding, address);

            #endregion

            #region Создание MEX endpoint в коде

            //var behavior = geoManagerHost.Description.Behaviors.Find<ServiceMetadataBehavior>();
            //if (behavior == null)
            //{
            //    var metadataBehavior = new ServiceMetadataBehavior();
            //    metadataBehavior.HttpGetEnabled = true;
            //    geoManagerHost.Description.Behaviors.Add(metadataBehavior);
            //}

            //geoManagerHost.AddServiceEndpoint(typeof(IMetadataExchange),
            //    MetadataExchangeBindings.CreateMexTcpBinding(),
            //    "MEX");

            #endregion

            geoManagerHost.Open();

            Console.WriteLine("Services started. Press [Enter] to exit.");
            Console.ReadLine();

            geoManagerHost.Close();
        }
    }
}
