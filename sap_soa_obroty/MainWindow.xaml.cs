
using sap_soa_obroty.Model;
using Stimulsoft.Report;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

namespace sap_soa_obroty
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ModelSAPSOAP model = new ModelSAPSOAP();
        SOAPSAP.REVE_AGGREGATIONResponse odp = new SOAPSAP.REVE_AGGREGATIONResponse();
        SOAPSAP.REVE_AGGREGATION_KUNWEResponse odp_we = new SOAPSAP.REVE_AGGREGATION_KUNWEResponse();
        ZPK_S_CRM_ZPARRAP2.ZPK_S_CRM_ZPARRAP2Response odp_skl = new ZPK_S_CRM_ZPARRAP2.ZPK_S_CRM_ZPARRAP2Response();
        public MainWindow()
        {
            InitializeComponent();

            string[] miesiące = new string[] { "001", "002", "003", "004", "005", "006", "007", "008", "009", "010", "011", "012"};
            string[] lata = new string[] { "2011", "2012", "2013", "2014", "2015", "2016", "2017", "2018", "2019" };
            okresod.ItemsSource = miesiące;
            okresod.SelectedIndex = 0;
            okresdo.ItemsSource = miesiące;
            okresdo.SelectedIndex = 0;

            rokod.ItemsSource = lata;
            rokod.SelectedIndex = 0;
            rokdo.ItemsSource = lata;
            rokdo.SelectedIndex = 0;

            string[] dzsprzedazy = new string[] { "1000","1050", "1100", "1200" };
            działsprzedaży.ItemsSource = dzsprzedazy;
            string[] kanalydystrybucji = new string[] { "KR", "EX", "DT", "MO" };
            kanałdystrybucji.ItemsSource = kanalydystrybucji;
            string[] klienciod = new string[] { "0" };
            Klienciod.ItemsSource = klienciod;
            string[] kliencido = new string[] { "9999999999" };
            KlienciDO.ItemsSource = kliencido;


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            sap_soa_obroty.SOAPSAP.ZPK_S_REVE_RESULT_EXTWG lista_zwg = new SOAPSAP.ZPK_S_REVE_RESULT_EXTWG();
            string url = "http://er1.aquael.pl:8000/sap/bc/srt/rfc/sap/zpk_crm_raporty/001/zpk_crm_raporty/zpk_crm_raporty";
            // tutaj pobieramy założenia - z combo boxów

            string okrod = okresod.Text;
            string okrdo = okresdo.Text;
            string rod = rokod.Text;
            string rdo = rokdo.Text;
            string dzsprz = działsprzedaży.Text;
            string kd = kanałdystrybucji.Text;
            string klod = Klienciod.Text;
            string kldo = KlienciDO.Text;
            


            //odp = model.Pobierz_obrot(dzsprz, kd, klod, kldo, dziedzina, rod, okrod, rdo, url);
            odp = model.Pobierz_obrot(dzsprz, kd, klod, kldo, okrod, rod, okrdo, rdo, url);
            if (gp.IsChecked.Value)
                dataGridSOADATA.ItemsSource = odp.ET_AQ2;
            else if (wm.IsChecked.Value)
                dataGridSOADATA.ItemsSource = odp.ET_AQ10;
            else if (gz.IsChecked.Value)
                dataGridSOADATA.ItemsSource = odp.ET_EXTWG;
            else
                dataGridSOADATA.ItemsSource = null;
        }

        private void gp_Checked(object sender, RoutedEventArgs e)
        {
            dataGridSOADATA.ItemsSource = odp.ET_AQ2;
        }

        private void wm_Checked(object sender, RoutedEventArgs e)
        {
            dataGridSOADATA.ItemsSource = odp.ET_AQ10;
        }

        private void gz_Checked(object sender, RoutedEventArgs e)
        {
            dataGridSOADATA.ItemsSource = odp.ET_EXTWG;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            sap_soa_obroty.SOAPSAP.REVE_AGGREGATION_KUNWE lista_obrotow = new SOAPSAP.REVE_AGGREGATION_KUNWE();
            string url = "http://er1.aquael.pl:8000/sap/bc/srt/rfc/sap/zpk_crm_raporty/001/zpk_crm_raporty/zpk_crm_raporty";
            // tutaj pobieramy założenia - z combo boxów

            string okrod = okresod.Text;
            string okrdo = okresdo.Text;
            string rod = rokod.Text;
            string rdo = rokdo.Text;
            string dzsprz = działsprzedaży.Text;
            string kd = kanałdystrybucji.Text;
            string klod = Klienciod.Text;
            string kldo = KlienciDO.Text;

            odp_we = model.PobierzObrotKUNWE(kd, klod, kldo, okrod, rod, okrdo, rdo, url, dzsprz);

            dataGridWE.ItemsSource = odp_we.ET_AQ10;
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void BtnParagony_CLICK(object sender, RoutedEventArgs e)
        {
            sap_soa_obroty.ZPK_S_CRM_ZPARRAP2.ZPK_S_CRM_ZPARRAP2 lista_paragonow = new ZPK_S_CRM_ZPARRAP2.ZPK_S_CRM_ZPARRAP2();
            string url = "http://er1.aquael.pl:8000/sap/bc/srt/rfc/sap/zpk_s_crm/001/zpk_s_crm/zpk_s_crm";
            // tutaj pobieramy założenia - z combo boxów

            string okrod = okresod.Text;
            string okrdo = okresdo.Text;
            string rod = rokod.Text;
            string rdo = rokdo.Text;
            string dzsprz = działsprzedaży.Text;
            string kd = kanałdystrybucji.Text;
            string klod = Klienciod.Text;
            string kldo = KlienciDO.Text;

            odp_skl = model.Obrót_sklepu("01.01.2018", "10.01.2018", "1070");

            dataGridParagonySAP.ItemsSource = odp_skl.RESPONSE;
            
        }

        private void BtnZgłoszenia_CLICK(object sender, RoutedEventArgs e)
        {

            sap_soa_obroty.pl.aquael.domino.DANEZGLOSZENIA lst_zgłoszenie = new pl.aquael.domino.DANEZGLOSZENIA();

            HelpDersk_zgloszenia zgl = new HelpDersk_zgloszenia();
            //lista zgłoszeń dla wpisanej osoby

            _ws_HelpDeskDomino.POZYCJALISTY[] listazlg = zgl.listazgl(txtPracownikHD.Text.ToString());

            dgListaZgloszen.ItemsSource = listazlg;


        }

        private void dataGridHelpDeskZgłosznia_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void dgListaZgloszen_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void dgListaZgloszen_MouseWheel(object sender, MouseWheelEventArgs e)
        {

        }

        public class _Zgloszenie
        {
            public string DATA { get; set; }
            public string NUMER { get; set; }
            public string ZGLASZAJACY { get; set; }
        }


        private void dgListaZgloszen_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

            try
            {
                if (dgListaZgloszen.SelectedItem == null)
                    return;
                sap_soa_obroty.pl.aquael.domino.DANEZGLOSZENIA lst_zgłoszenie = new pl.aquael.domino.DANEZGLOSZENIA();

                HelpDersk_zgloszenia zgl = new HelpDersk_zgloszenia();
                _Zgloszenie _zgl = new _Zgloszenie();
                // data Row View 
                var zgloszenieselected = dgListaZgloszen.SelectedItem as _ws_HelpDeskDomino.POZYCJALISTY;

                String nrzgl = zgloszenieselected.NUMER;
                


                _ws_HelpDeskDomino.DANEZGLOSZENIA statzgl = zgl.StatusZgloszenia(nrzgl);


                var typobiektu = statzgl.GetType();
                txtNrZgłoszenia.Text = nrzgl;
                txtTypObiektu.Text = (String)typobiektu.ToString();

                //TxtLibrary myList = new TxtLibrary(filePathBooks);
                //myList.chooise = "all";

                txtOpisZgłoszenia.Text = statzgl.OPIS.ToString();
                txtStatusZgłoszenia.Text = statzgl.STATUS.ToString();
                txtOdpowiedzialnyZgłoszenia.Text = statzgl.ODPOWIEDZIALNY.ToString();
                txtBlad.Text = statzgl.BLAD.ToString();
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.ToString() + " - " + ex.Message);
            }





            
        }

        private void btndodajkomentarz_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Jesteś pewny że chcesz dodać wpisany komentarz?", "zapisz komentarz", System.Windows.MessageBoxButton.YesNo);

                if (messageBoxResult == MessageBoxResult.Yes)
                { //obiekt
                    HelpDersk_zgloszenia ws_ = new HelpDersk_zgloszenia();

                    ws_.dodajkomentarz(txtNrZgłoszenia.Text.ToString(), tekstkomentarz.Text.ToString());
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.ToString() + "  " + ex.Message);
            }
        }

        private void TabItem_GotFocus(object sender, RoutedEventArgs e)
        {
            lblkom.Content ="Dodaj komentarz do zgłoszenia nr:" + txtNrZgłoszenia.Text.ToString();
        }

        private void TabItem_GotFocus_1(object sender, RoutedEventArgs e)
        {

        }



        //public void przeczytajxml(System.Xml.XmlDocument wejscie)
        //{
        //    var doc = XDocument.Load(wejscie);

        //    var rows = doc.Descendants("QuestId").Select(el => new Quest
        //    {
        //        Answer1 = el.Element("Answer1").Value,
        //        Answer2 = el.Element("Answer2").Value,
        //        Answer3 = el.Element("Answer3").Value,
        //        Answer4 = el.Element("Answer4").Value,
        //    });

        //    // iterate over the rows and add to DataTable ...

        //}


        //private void wm_Checked(object sender, RoutedEventArgs e)
        //{
        //    dataGridSOADATA.ItemsSource = odp.ET_AQ10;
        //}

        //private void gz_Checked(object sender, RoutedEventArgs e)
        //{


        //}


        //raportowanie:


    }
}
