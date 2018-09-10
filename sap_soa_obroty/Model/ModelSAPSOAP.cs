
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace sap_soa_obroty.Model
{
    class ModelSAPSOAP
    {
        private const string V = "http://er1.aquael.pl:8000/sap/bc/srt/wsdl/sdef_ZPK_S_CRM/wsdl11/ws_policy/document?sap-client=001";

        Model_AuthSAP auth = new Model_AuthSAP();

        // pierwszy konstruktor
        public  ModelSAPSOAP()
        {
            
            
           

    }

        private Model_AuthSAP Dostęp()
        {
            //List<string> userhasło = new List<string>();
            Model_AuthSAP dostępy = new Model_AuthSAP();


            return dostępy;
        }

        public ZPK_S_CRM_ZPARRAP2.ZPK_S_CRM_ZPARRAP2Response Obrót_sklepu(string dzienod, string dziendo, string zaklad)
        {
            BasicHttpBinding binding = new BasicHttpBinding();
            binding.Security.Mode = BasicHttpSecurityMode.TransportCredentialOnly;
            binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Basic;
            binding.Name = "MyBinding";
            binding.MaxReceivedMessageSize = Int32.MaxValue;

            string uri = V; 
            EndpointAddress endpoint = new EndpointAddress(uri);
            //SI_SEND_ORG_DATAClient client = new SI_SEND_ORG_DATAClient(binding, endpoint);

            ZPK_S_CRM_ZPARRAP2.ZPK_S_CRMClient client = new ZPK_S_CRM_ZPARRAP2.ZPK_S_CRMClient(binding, endpoint);

            // teraz funkcja
            ZPK_S_CRM_ZPARRAP2.ZPK_S_CRM_ZPARRAP2 zparrap1_fn = new ZPK_S_CRM_ZPARRAP2.ZPK_S_CRM_ZPARRAP2
            {

                // parametry wejście
                DZIENDO = dzienod,
                DZIENOD = dziendo,
                ZAKLAD = new ZPK_S_CRM_ZPARRAP2.WERKS { WERKS1 = zaklad }
            };

            //client.ClientCredentials.UserName.UserName = "admnet";
            //client.ClientCredentials.UserName.Password = "Pysiek,1972";
            List<string> sapauth = auth.PodajAutoryzacje();
            client.ClientCredentials.UserName.UserName = sapauth[0];
            client.ClientCredentials.UserName.Password = sapauth[1];


            ZPK_S_CRM_ZPARRAP2.ZPK_S_CRM_ZPARRAP2Response res = new ZPK_S_CRM_ZPARRAP2.ZPK_S_CRM_ZPARRAP2Response();
            
            return res;
        }

        public SOAPSAP.REVE_AGGREGATIONResponse Pobierz_obrot(string vkorg, string vtweg, string KNDNR_FROM, string KNDNR_TO, string period_from_month, string period_from_year, string period_to_month, string period_to_year, string uri)
        {
            BasicHttpBinding binding = new BasicHttpBinding();
            binding.Security.Mode = BasicHttpSecurityMode.TransportCredentialOnly;
            binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Basic;
            binding.Name = "MyBinding";
            binding.MaxReceivedMessageSize = Int32.MaxValue;


            EndpointAddress endpoint = new EndpointAddress(uri);
            //SI_SEND_ORG_DATAClient client = new SI_SEND_ORG_DATAClient(binding, endpoint);







            SOAPSAP.ZPK_CRM_RAPORTYClient client = new SOAPSAP.ZPK_CRM_RAPORTYClient(binding, endpoint);

            // SOAPSAP.REVE_AGGREGATIONRequest



            sap_soa_obroty.SOAPSAP.REVE_AGGREGATION fn = new sap_soa_obroty.SOAPSAP.REVE_AGGREGATION();
            fn.IV_VKORG = vkorg;
            fn.IV_VTWEG = vtweg;
            fn.IV_KNDNR_FROM = KNDNR_FROM;
            fn.IV_KNDNR_TO = KNDNR_TO;

            sap_soa_obroty.SOAPSAP.ZPK_S_PERIOD period = new sap_soa_obroty.SOAPSAP.ZPK_S_PERIOD();
            period.MONTH = "001";
            period.YEAR = "2018";

            fn.IV_PERIOD_FROM = new SOAPSAP.ZPK_S_PERIOD { MONTH = period_from_month, YEAR = period_from_year };
            //fn.IV_PERIOD_FROM.MONTH = "001";
            //fn.IV_PERIOD_TO.YEAR = "2018";
            //fn.IV_PERIOD_TO.MONTH = "002";
            fn.IV_PERIOD_TO = new SOAPSAP.ZPK_S_PERIOD { MONTH = period_to_month, YEAR = period_to_year };
            List<string> sapauth = auth.PodajAutoryzacje();
            client.ClientCredentials.UserName.UserName = sapauth[0];
            client.ClientCredentials.UserName.Password = sapauth[1];


            // SOAPSAP.REVE_AGGREGATION_KUNWEResponse res = client.REVE_AGGREGATION_KUNWE(fn);
            SOAPSAP.REVE_AGGREGATIONResponse res = client.REVE_AGGREGATION(fn);
            return res;
        }

        public SOAPSAP.REVE_AGGREGATION_KUNWEResponse PobierzObrotKUNWE(string vtweg, string KNDNR_FROM, string KNDNR_TO, string period_from_month, string period_from_year, string period_to_month, string period_to_year, string uri, string vkorg)
        {
            BasicHttpBinding binding = new BasicHttpBinding();
            binding.Security.Mode = BasicHttpSecurityMode.TransportCredentialOnly;
            binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Basic;
            binding.Name = "MyBinding";
            binding.MaxReceivedMessageSize = Int32.MaxValue;


            EndpointAddress endpoint = new EndpointAddress(uri);
            //SI_SEND_ORG_DATAClient client = new SI_SEND_ORG_DATAClient(binding, endpoint);







            SOAPSAP.ZPK_CRM_RAPORTYClient client = new SOAPSAP.ZPK_CRM_RAPORTYClient(binding, endpoint);

            // SOAPSAP.REVE_AGGREGATIONRequest



            sap_soa_obroty.SOAPSAP.REVE_AGGREGATION_KUNWE fn = new sap_soa_obroty.SOAPSAP.REVE_AGGREGATION_KUNWE();
            fn.IV_VKORG = vkorg;
            fn.IV_VTWEG = vtweg;
            fn.IV_KUNWE_FROM = KNDNR_FROM;
            fn.IV_KUNWE_TO = KNDNR_TO;

            sap_soa_obroty.SOAPSAP.ZPK_S_PERIOD period = new sap_soa_obroty.SOAPSAP.ZPK_S_PERIOD();
            period.MONTH = "001";
            period.YEAR = "2018";

            fn.IV_PERIOD_FROM = new SOAPSAP.ZPK_S_PERIOD { MONTH = period_from_month, YEAR = period_from_year };
            //fn.IV_PERIOD_FROM.MONTH = "001";
            //fn.IV_PERIOD_TO.YEAR = "2018";
            //fn.IV_PERIOD_TO.MONTH = "002";
            fn.IV_PERIOD_TO = new SOAPSAP.ZPK_S_PERIOD { MONTH = period_to_month, YEAR = period_to_year };
            List<string> sapauth = auth.PodajAutoryzacje();
            client.ClientCredentials.UserName.UserName = sapauth[0];
            client.ClientCredentials.UserName.Password = sapauth[1];

            SOAPSAP.REVE_AGGREGATION_KUNWEResponse res = client.REVE_AGGREGATION_KUNWE(fn);


            return res;
        }
    }

    

}