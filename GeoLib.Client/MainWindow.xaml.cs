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
        private GeoClient proxyMe;

        public MainWindow()
        {
            InitializeComponent();

            this.Title = $"UI Running on Thread: {Thread.CurrentThread.ManagedThreadId} " +
                         $"| Process {Process.GetCurrentProcess().Id}";

            this.proxyMe = new GeoClient("tcpEP");
        }

        private void BtnGetInfo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(txtZipCode.Text))
                {
                    GeoClient proxy = new GeoClient("tcpEP");

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
                    //GeoClient proxy = new GeoClient("tcpEP");
                    IEnumerable<ZipCodeData> data = proxyMe.GetZips(txtState.Text);

                    if (data != null)
                    {
                        lstZips.ItemsSource = data;
                    }

                    //proxy.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void BtnMakeCall_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
