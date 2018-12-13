using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GeoLib.WindowsHost.Services
{
    public class MessageManager : IMessageService
    {
        public void ShowMessage(string message)
        {
            MainWindow.MainUI.ShowMessage(message);
        }

        public MyTempContract2 TestMethod(MyTempContract request)
        {
            MessageBox.Show(request.Name);
            return null;
        }
    }
}
