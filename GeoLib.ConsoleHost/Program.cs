using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
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

            #region Создание endpoint в коде

            //string address = "net.tcp://localhost:8009/GeoService";
            //Binding binding = new WSHttpBinding();
            //Type contract = typeof(IGeoService);

            //geoManagerHost.AddServiceEndpoint(contract, binding, address);

            #endregion

            geoManagerHost.Open();

            Console.WriteLine("Services started. Press [Enter] to exit.");
            Console.ReadLine();

            geoManagerHost.Close();
        }
    }
}
