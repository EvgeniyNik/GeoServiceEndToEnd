using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using GeoLib.Contracts;
using GeoLib.Proxies;

namespace GeoLib.Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.Title = $"UI Running on Thread: {Thread.CurrentThread.ManagedThreadId} " +
                         $"| Process {Process.GetCurrentProcess().Id}";
        }

        private void BtnGetInfo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(txtZipCode.Text))
                {
                    GeoClient proxy = new GeoClient("httpEP");

                    ZipCodeData data = proxy.GetZipInfo(txtZipCode.Text);
                    if (data != null)
                    {
                        lblCity.Content = data.City;
                        lblState.Content = data.State;
                    }

                    proxy.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void BtnGetZipCodes_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(txtState.Text))
                {
                    var address = new EndpointAddress("net.tcp://localhost/GeoLib.WebHost/GeoService.svc");
                    var binding = new NetTcpBinding();

                    GeoClient proxy = new GeoClient(binding, address);
                    IEnumerable<ZipCodeData> data = proxy.GetZips(txtState.Text);

                    if (data != null)
                    {
                        lstZips.ItemsSource = data;
                    }

                    proxy.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void BtnMakeCall_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(txtMessage.Text))
                {
                    var factory = new ChannelFactory<IMessageService>("httpEP2");
                    IMessageService proxy = factory.CreateChannel();

                    proxy.ShowMessage(txtMessage.Text);
                    var result = proxy.TestMethod(new MyRequest { Age = 10, Name = "Ivan" });
                    MessageBox.Show(result?.Message ?? "null");

                    factory.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
