﻿using GeoLib.Contracts;
using GeoLib.Proxies;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.ServiceModel;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace GeoLib.Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private StatefullGeoClient proxy;
        private SynchronizationContext syncContext;

        public MainWindow()
        {
            InitializeComponent();

            this.Title = $"UI Running on Thread: {Thread.CurrentThread.ManagedThreadId} " +
                         $"| Process {Process.GetCurrentProcess().Id}";

            proxy = new StatefullGeoClient("tcpEP");
            proxy.Open();
            syncContext = SynchronizationContext.Current;
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
                    try
                    {
                        string zipCode = txtZipCode.Text;
                        proxy.PushZip(zipCode);
                    }
                    catch (FaultException<ErrorResponse> ex)
                    {
                        MessageBox.Show($"Exception type: FaultException<ErrorResponse>{Environment.NewLine}" +
                            $"Message: {ex.Message}{Environment.NewLine}" +
                            $"Detail message: {ex.Detail.Message} - {ex.Detail.Time}{Environment.NewLine}" +
                            $"Proxy state: {proxy.State}");
                    }
                    catch (FaultException<ArgumentException> ex)
                    {
                        MessageBox.Show($"Exception type: FaultException<ArgumentException>{Environment.NewLine}" +
                            $"Message: {ex.Message}{Environment.NewLine}" +
                            $"Detail message: {ex.Detail.Message}{Environment.NewLine}" +
                            $"Proxy state: {proxy.State}");
                    }
                    catch (FaultException<ExceptionDetail> ex)
                    {
                        MessageBox.Show($"Exception type: FaultException<ExceptionDetail>{Environment.NewLine}" +
                            $"Message: {ex.Message}{Environment.NewLine}" +
                            $"Proxy state: {proxy.State}");
                    }
                    catch (FaultException ex)
                    {
                        MessageBox.Show($"Exception type: {ex.GetType()}{Environment.NewLine}" +
                            $"Message: {ex.Message}{Environment.NewLine}" +
                            $"Proxy state: {proxy.State}");
                    }
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