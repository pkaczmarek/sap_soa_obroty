
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;


namespace sap_soa_obroty.Model
{
    class HelpDersk_zgloszenia
    {
        private const string V = "https://domino.aquael.pl/7B/helpdesk_it.nsf/InfZgl?OpenWebService";
        _ws_HelpDeskDomino.DANEZGLOSZENIA sss;
        _ws_HelpDeskDomino.POZYCJALISTY[] lstZgl;
        public _ws_HelpDeskDomino.DANEZGLOSZENIA StatusZgloszenia(string nrzgl)
        {




            BasicHttpBinding binding = new BasicHttpBinding();
            binding.Security.Mode = BasicHttpSecurityMode.TransportCredentialOnly;
            //binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Digest;
            //binding.Security.Message.ClientCredentialType = BasicHttpMessageCredentialType.UserName;
            binding.Security.Mode = BasicHttpSecurityMode.Transport;
            binding.Name = "MyBinding";
            binding.MaxReceivedMessageSize = Int32.MaxValue;
            
            string uri = V;

            EndpointAddress endpoint = new EndpointAddress(uri);







            //SI_SEND_ORG_DATAClient client = new SI_SEND_ORG_DATAClient(binding, endpoint);




            //binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Basic;
            _ws_HelpDeskDomino.InfZglPortClient client = new _ws_HelpDeskDomino.InfZglPortClient(binding,endpoint);
            
            
            
            
            
            
           
            client.ClientCredentials.UserName.UserName = "_ws_Aquael";
            client.ClientCredentials.UserName.Password = "WebService2018!";

            using (new OperationContextScope(client.InnerChannel))
            {
                SoapAuthHeader.Create(client.ClientCredentials.UserName.UserName, client.ClientCredentials.UserName.Password);

                sss = client.STATUSZGLOSZENIA(nrzgl);
                


            };
            return sss;
            
        }



        public _ws_HelpDeskDomino.POZYCJALISTY[] listazgl(string phd)
        {




            BasicHttpBinding binding = new BasicHttpBinding();
            binding.Security.Mode = BasicHttpSecurityMode.TransportCredentialOnly;
            //binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Digest;
            //binding.Security.Message.ClientCredentialType = BasicHttpMessageCredentialType.UserName;
            binding.Security.Mode = BasicHttpSecurityMode.Transport;
            binding.Name = "MyBinding";
            binding.MaxReceivedMessageSize = Int32.MaxValue;

            string uri = V;

            EndpointAddress endpoint = new EndpointAddress(uri);







            //SI_SEND_ORG_DATAClient client = new SI_SEND_ORG_DATAClient(binding, endpoint);




            //binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Basic;
            _ws_HelpDeskDomino.InfZglPortClient client = new _ws_HelpDeskDomino.InfZglPortClient(binding, endpoint);







            client.ClientCredentials.UserName.UserName = "_ws_Aquael";
            client.ClientCredentials.UserName.Password = "WebService2018!";

            //  teraz odpalamy oddzielny space name
            //sss = client.STATUSZGLOSZENIA(nrzgl);


            _ws_HelpDeskDomino.POZYCJALISTY[] lista1;
            using (new OperationContextScope(client.InnerChannel))
            {
                SoapAuthHeader.Create(client.ClientCredentials.UserName.UserName, client.ClientCredentials.UserName.Password);

                //client.Open();

                
                lstZgl = client.POKAZZGLOSZENIAODP(phd);
                //lstZgl = client.(phd);
                _ws_HelpDeskDomino.POZYCJALISTY[] xxx = client.POKAZZGLOSZENIAODP("Piotr Kaczmarek");
            };
            

            

            return lstZgl;

        }



        public void testy(string url, string logon, string password)
        {
            WebRequest request = WebRequest.Create(url);
            request.Method = WebRequestMethods.Http.Get;
            NetworkCredential networkCredential = new NetworkCredential(logon, password); // logon in format "domain\username"
            CredentialCache myCredentialCache = new CredentialCache { { new Uri(url), "Basic", networkCredential } };
            request.PreAuthenticate = true;
            request.Credentials = myCredentialCache;
            using (WebResponse response = request.GetResponse())
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.txtTypObiektu.Text = (((HttpWebResponse)response).StatusDescription);

                using (Stream dataStream = response.GetResponseStream())
                {
                    using (StreamReader reader = new StreamReader(dataStream))
                    {
                        string responseFromServer = reader.ReadToEnd();
                        mainWindow.txtTypObiektu.Text = mainWindow.txtTypObiektu.Text + " - " +(responseFromServer);
                    }
                }
            }
        }


        public void dodajkomentarz(string nrzgl, string komentarz)
        {
            BasicHttpBinding binding = new BasicHttpBinding();
            binding.Security.Mode = BasicHttpSecurityMode.TransportCredentialOnly;
            //binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Digest;
            //binding.Security.Message.ClientCredentialType = BasicHttpMessageCredentialType.UserName;
            binding.Security.Mode = BasicHttpSecurityMode.Transport;
            binding.Name = "MyBinding";
            binding.MaxReceivedMessageSize = Int32.MaxValue;

            string uri = V;

            EndpointAddress endpoint = new EndpointAddress(uri);







            //SI_SEND_ORG_DATAClient client = new SI_SEND_ORG_DATAClient(binding, endpoint);




            //binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Basic;
            _ws_HelpDeskDomino.InfZglPortClient client = new _ws_HelpDeskDomino.InfZglPortClient(binding, endpoint);







            client.ClientCredentials.UserName.UserName = "_ws_Aquael";
            client.ClientCredentials.UserName.Password = "WebService2018!";

            //  teraz odpalamy oddzielny space name
            //sss = client.STATUSZGLOSZENIA(nrzgl);


           
            using (new OperationContextScope(client.InnerChannel))
            {
                SoapAuthHeader.Create(client.ClientCredentials.UserName.UserName, client.ClientCredentials.UserName.Password);

                //client.Open();

                client.DODAJKOMENTARZ(nrzgl, komentarz);
                
            };
        }
    }

}
