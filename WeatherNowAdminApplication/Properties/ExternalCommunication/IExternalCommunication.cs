using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherNowApplication.Properties.ExternalCommunication
{
    internal interface IExternalCommunication
    {
        public interface IExternalCommunication
        {
            void OpenConnection(string connectionString);
            void CloseConnection();
            void SendData(string data);
            string ReceiveData();
        }

    }
}
