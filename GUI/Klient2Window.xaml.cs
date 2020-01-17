using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Logika interakcji dla klasy Klient2Window.xaml
    /// </summary>
    public partial class Klient2Window : Window
    {
        Klient klient;
        bool decyzja;
        int czas;
        int liczba_ubezpieczonych;
        Zamowienie zamowienie;
        PakietKoncowy pk;
        PakietDodatkowy p = new PakietDodatkowy();
        bool czyDodano;
        int podzial;

        Dictionary<string, string> NazwyPakietow = new Dictionary<string, string>()
            {
                { "SportyEkstremalne","Sporty Ekstremalne" }, {"Onkolog","Pakiet Onkolog" }, {"Ortopeda","Pakiet Ortopeda" }, {"PowazneZachorowanieDziecka","Poważne zachorowanie dziecka" }, {"Niezdolnosc","Niezdolność do wykonywania zawodu" }, {"SmiercWK","Śmierć w wypadku komunikacyjnym" },{"smiercNW","Śmierć w nieszczęśliwym wypadku" }
            };

        public Klient2Window()
        {
            InitializeComponent();
        }
        public Klient2Window(Klient klient, bool de, int c, bool czy, int podzial)
        {

            InitializeComponent();
            this.podzial = podzial;

            czyDodano = czy;
            this.klient = klient;
            czas = c;
            decyzja = de;
            if (czyDodano == false)
            {
                klient.FunkcjaPakietDodatkowy(czas, klient, liczba_ubezpieczonych,12);
                if (decyzja == true)
                {
                    klient.PakietRodzinny(czas, klient,podzial);
                }
                else
                {
                    klient.PakietPodstawowyIndywiduany(czas, klient,podzial);
                }
            }

            int k = klient.historia.Count - 1;
            List <PakietDodatkowy> lista = klient.historia[klient.historia.Count - 1].PakietKoncowy.dodatkowe;
            foreach (PakietDodatkowy p in klient.historia[klient.historia.Count - 1].PakietKoncowy.dodatkowe)
                Console.WriteLine(p.ToString());
            Console.WriteLine(lista.Count);
            List<string>  LS = new List<string>();
            ListBox_Pakiety.ItemsSource = new List<String>();
            for (int i = 0; i < lista.Count; i++)
            {
                LS.Add(NazwyPakietow[lista[i].Nazwa]);
            }
            ListBox_Pakiety.ItemsSource = LS;
            Suma.Text = klient.historia[k].PakietKoncowy.Skladka.ToString();
            kosztKoncowy.Text = klient.historia[k].PakietKoncowy.KosztKoncowy.ToString();
            if(podzial == 12)
            {
                TextBox_RodzajSkladki.Text = "/miesiąc";
            }
            else
            {
                TextBox_RodzajSkladki.Text = "/rok";
            }
        }

        private void Kontakt_Click(object sender, RoutedEventArgs e)
        {
            KontaktWindow okno = new KontaktWindow(klient);
            this.Close();
            okno.ShowDialog();
        }

        private void Powrot_Click(object sender, RoutedEventArgs e)
        {
            MainWindow okno = new MainWindow();
            this.Close();
            okno.ShowDialog();
        }

        public void DodajPakiet_Click(object sender, RoutedEventArgs e)
        {
            czyDodano = true;
            List<string> lista = new List<string>();
            foreach(string s in ListBox_Pakiety.Items)
            {
                string a=NazwyPakietow.FirstOrDefault(x => x.Value == s.ToString()).Key;
                lista.Add(a);
                Console.WriteLine(a);
            }

            DodatkowyPakietWindow okno = new DodatkowyPakietWindow(klient, czas, lista,pk, podzial,liczba_ubezpieczonych);
            this.Close();
            okno.ShowDialog();
        }

        private void UsunPakiet_Click(object sender, RoutedEventArgs e)
        {
            czyDodano = true;
            List<string> lista = new List<string>();
            foreach (string s in ListBox_Pakiety.Items)
            {
                lista.Add(s.ToString());
            }
            UsunPakietWindow okno = new UsunPakietWindow(klient, czas, lista, pk,podzial,liczba_ubezpieczonych);
            this.Close();
            okno.ShowDialog();
        }
    }
}
