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
        Agent agent;
        public AgentOczekujacyNaKontakt(Agent a)
        {
            InitializeComponent();
            agent = a;

            ListaKlientow lista = ListaKlientow.OdczytajXML("ListaKlientówDoKontaktu.xml");
            StringBuilder sb = new StringBuilder();
            List<string> wpisy = new List<string>();
            foreach(Klient k in lista.klienci)
            {
                if(wpisy.Contains(k.ToString())==false)
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
            //try
            //{
                ListaKlientow lista = ListaKlientow.OdczytajXML("ListaKlientówDoKontaktu.xml");

                ListaKlientow lista2 = ListaKlientow.OdczytajXML("ListaKlientow.xml");
                Klient result = new Klient();
                ListaKlientow listaDoUsuniecia = new ListaKlientow();
                foreach (Klient k in lista.klienci)
                {
                    Console.WriteLine("Badany:"+k.ToString());
                    Console.WriteLine("Wybrany:"+wybrany);
                    if (k.ToString()==wybrany.ToString())
                    {
                        k.PESEL1 = TextBoxPESEL.ToString();
                        result = k;
                        listaDoUsuniecia.DodajKlienta(k);
                    }
                }
                Klient klient = listaDoUsuniecia.klienci[0];
                klient.ZapisKlientaDoXLSX(klient, agent);
                foreach (Klient k in listaDoUsuniecia.klienci)
                {
                    lista.klienci.Remove(k);
                }

                lista.ZapiszXML("ListaKlientówDoKontaktu");
                lista2.DodajKlienta(result);
                lista2.ZapiszXML("ListaKlientow");
            /*}
            catch (Exception ex)
            {
                MessageBox.Show("Proszę wybrać klienta i podać PESEL");
            }*/
            

        }
    }
}
