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
using GeoLib.Services;

namespace GeoLib.WindowsHost
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MainWindow MainUI;
        private ServiceHost geoManagerHost;
        private ServiceHost messageManagerHost;
        private SynchronizationContext syncContext;

        public MainWindow()
        {
            InitializeComponent();

            btnStart.IsEnabled = true;
            btnStop.IsEnabled = false;

            this.Title = $"UI Running on Thread {Thread.CurrentThread.ManagedThreadId} | Process {Process.GetCurrentProcess().Id}";

            MainUI = this;
            syncContext = SynchronizationContext.Current;
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
            var threadId = Thread.CurrentThread.ManagedThreadId;
            var processId = Process.GetCurrentProcess().Id;

            SendOrPostCallback callback = new SendOrPostCallback(arg =>
            {
                lblMessage.Content = $"{message}{Environment.NewLine} Marshaling from Thread {threadId} " +
                $"to {Thread.CurrentThread.ManagedThreadId} | Process:{processId}";
            });

            syncContext.Send(callback, null);
        }

        private void BtnInProc_Click(object sender, RoutedEventArgs e)
        {
            Thread thread = new Thread(_ =>
            {
                var factory = new ChannelFactory<IMessageService>("");
                var channel = factory.CreateChannel();

                channel.ShowMessage($"{DateTime.Now} from in-proc call");

                factory.Close();
            });

            thread.IsBackground = true;
            thread.Start();
        }
    }
}
