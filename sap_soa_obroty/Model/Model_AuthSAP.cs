using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sap_soa_obroty.Model
{
    class Model_AuthSAP
    {
        private string username;
        private string password;
        
        public Model_AuthSAP()
        {
            this.username = "admnet";
            this.password = "Pysiek,1972";
        }

        // dodajemy klasę do logowania - w modelu singleton
        public void PobierzAutoryzację(string username, string password)
        {
            this.username = username;
            this.password = password;

        }


        public List<string> PodajAutoryzacje()
        {
            List<string> LAuth = new List<string>();
            LAuth.Add(username);
            LAuth.Add(password);

            return LAuth;
        }
    }
}
