using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ProjektUbezpieczenia;

namespace GUI
{
    /// <summary>
    /// Logika interakcji dla klasy AgentOczekujacyNaKontakt.xaml
    /// </summary>
    public partial class AgentOczekujacyNaKontakt : Window
    {
        public string agent;
        public AgentOczekujacyNaKontakt(string a)
        {
            InitializeComponent();
            agent = a;

            ListaKlientow lista = ListaKlientow.OdczytajXML("ListaKlientówDoKontaktu.xml");
            StringBuilder sb = new StringBuilder();
            List<string> wpisy = new List<string>();
            foreach(Klient k in lista.klienci)
            {
                wpisy.Add(k.ToString());
            }
            ListBoxKlienci.ItemsSource = wpisy;


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AgentWindow okno = new AgentWindow(agent);
            this.Close();
            okno.ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {//Tu trzeba dodać try catch
            string wybrany = ListBoxKlienci.SelectedItem.ToString();
            ListaKlientow lista = ListaKlientow.OdczytajXML("ListaKlientówDoKontaktu.xml");
            ListaKlientow lista2 = ListaKlientow.OdczytajXML("ListaKlientow.xml");
            Klient result = new Klient();
            foreach (Klient k in lista.klienci)
            {
                if(k.ToString()==wybrany)
                {
                    k.PESEL1 = TextBoxPESEL.ToString();
                    result = k;
                    lista.klienci.Remove(k);
                }
            }
            lista.ZapiszXML("ListaKlientówDoKontaktu");
            lista2.DodajKlienta(result);
            lista2.ZapiszXML("ListaKlientow");

        }
    }
}
