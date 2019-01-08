using GeoLib.Contracts;
using GeoLib.Proxies;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.ServiceModel;
using System.Threading;
using System.Windows;

namespace GeoLib.Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private StatefullGeoClient proxy;

        public MainWindow()
        {
            InitializeComponent();

            this.Title = $"UI Running on Thread: {Thread.CurrentThread.ManagedThreadId} " +
                         $"| Process {Process.GetCurrentProcess().Id}";

            proxy = new StatefullGeoClient();
        }

        private void BtnGetInfo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ZipCodeData zipCode = proxy.GetZipInfo();

                lblState.Content = zipCode.State;
                lblCity.Content = zipCode.City;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void BtnPushInfo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(txtZipCode.Text))
                {
                    proxy.PushZip(txtZipCode.Text);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void BtnGetZipCodeByRange_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(txtRange.Text))
                {
                    int.TryParse(txtRange.Text, out int range);
                    IEnumerable<ZipCodeData> data = proxy.GetZips(range);

                    if (data != null)
                        lstZips.ItemsSource = data;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}