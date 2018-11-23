using System;
using System.Collections.Generic;
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
using GeoLib.Services;

namespace GeoLib.WindowsHost
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ServiceHost geoManagerHost;

        public MainWindow()
        {
            InitializeComponent();

            btnStart.IsEnabled = true;
            btnStop.IsEnabled = false;

            this.Title = $"UI Running on Thread {Thread.CurrentThread.ManagedThreadId}";
        }

        private void BtnStart_Click(object sender, RoutedEventArgs e)
        {
            geoManagerHost = new ServiceHost(typeof(GeoManager));
            geoManagerHost.Open();

            btnStart.IsEnabled = false;
            btnStop.IsEnabled = true;
        }

        private void BtnStop_Click(object sender, RoutedEventArgs e)
        {
            geoManagerHost.Close();

            btnStart.IsEnabled = true;
            btnStop.IsEnabled = false;
        }
    }
}
