using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;

namespace sap_soa_obroty.Model
{
   public static class SoapAuthHeader
    {
        public static void Create(string username, string password)
        {
            // Add HTTP Soap Header to an outgoing request
            string auth = "Basic " + Convert.ToBase64String(System.Text.Encoding.Default.GetBytes(username + ":" + password));
            HttpRequestMessageProperty requestMessage = new HttpRequestMessageProperty();
            requestMessage.Headers.Add("Authorization", auth);
            System.ServiceModel.OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = requestMessage;
        }
    }
}
