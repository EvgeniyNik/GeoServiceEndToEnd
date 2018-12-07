using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace GeoLib.WindowsHost
{
    [ServiceContract(Namespace = "http://mysitename.com/evgeniy")]
    public interface IMessageService
    {
        [OperationContract]
        void ShowMessage(string message);
    }
}
