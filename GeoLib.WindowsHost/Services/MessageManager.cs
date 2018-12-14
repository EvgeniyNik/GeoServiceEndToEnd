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

        public MyResponse TestMethod(MyRequest request)
        {
            MessageBox.Show(request?.Name ?? "null");
            return new MyResponse { Message = "Все ОК"};
        }
    }
}
