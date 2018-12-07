using System;
using System.Diagnostics;
using GeoLib.Services;
using System.ServiceModel;
using System.Threading;
using System.Windows;

namespace GeoLib.WindowsHost
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ServiceHost geoManagerHost;
        private ServiceHost messageManagerHost;

        public static MainWindow MainUI;

        public MainWindow()
        {
            InitializeComponent();

            MainUI = this;

            btnStart.IsEnabled = true;
            btnStop.IsEnabled = false;

            this.Title = $"UI Running on Thread {Thread.CurrentThread.ManagedThreadId} | Process {Process.GetCurrentProcess().Id}";
        }

        private void BtnStart_Click(object sender, RoutedEventArgs e)
        {
            geoManagerHost = new ServiceHost(typeof(GeoManager));
            messageManagerHost = new ServiceHost(typeof(MessageManager));

            geoManagerHost.Open();
            messageManagerHost.Open();

            btnStart.IsEnabled = false;
            btnStop.IsEnabled = true;
        }

        private void BtnStop_Click(object sender, RoutedEventArgs e)
        {
            geoManagerHost.Close();
            messageManagerHost.Close();

            btnStart.IsEnabled = true;
            btnStop.IsEnabled = false;
        }

        public void ShowMessage(string message)
        {
            lblMessage.Content = $"{message}{Environment.NewLine}(shown on thread {Thread.CurrentThread.ManagedThreadId} " +
                                 $"| Process {Process.GetCurrentProcess().Id})";
        }
    }
}
