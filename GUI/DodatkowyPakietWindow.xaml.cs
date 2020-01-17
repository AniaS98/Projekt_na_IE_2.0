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
    /// Logika interakcji dla klasy DodatkowyPakietWindow.xaml
    /// </summary>
    public partial class DodatkowyPakietWindow : Window
    {
        Klient klient;
        int czas;
        bool decyzja;
        List<string> wszystkie = new List<string>();
        List<CheckBox> checkboxy = new List<CheckBox>();
        CheckBox box = new CheckBox();
        PakietDodatkowy p = new PakietDodatkowy();
        PakietKoncowy pk;
        PakietKoncowy pkdod = new PakietKoncowy();
        int podzial;
        int lUb;
        Dictionary<string, string> NazwyPakietow = new Dictionary<string, string>()
            {
                { "SportyEkstremalne","Sporty Ekstremalne" }, {"Onkolog","Pakiet Onkolog" }, {"Ortopeda","Pakiet Ortopeda" }, {"PowazneZachorowanieDziecka","Poważne zachorowanie dziecka" }, {"Niezdolnosc","Niezdolność do wykonywania zawodu" }, {"SmiercWK","Śmierć w wypadku komunikacyjnym" },{"smiercNW","Śmierć w nieszczęśliwym wypadku" }
            };
        public DodatkowyPakietWindow(Klient klient, int c, List<string> lista, PakietKoncowy pk,int podzial,int lUb)
        {
            this.lUb = lUb;
            this.podzial = podzial;
            foreach (var item in Enum.GetNames(typeof(Edodat)))
            {
                wszystkie.Add(item);
            }
            foreach (string s in lista)
            {
                wszystkie.Remove(s);
            }

            this.klient = klient;
            czas = c;
            InitializeComponent();

            foreach (string s in wszystkie)
            {
                box = new CheckBox();
                box.Content = NazwyPakietow[s];
                checkboxy.Add(box);
            }
            ListBox_Pakiet.ItemsSource = checkboxy;

        }

        public void Akceptuj_Click(object sender, RoutedEventArgs e)
        {
            pk = klient.historia[klient.historia.Count - 1].PakietKoncowy;

            foreach (CheckBox box in ListBox_Pakiet.Items)
            {
                string a = NazwyPakietow.FirstOrDefault(x => x.Value == box.Content.ToString()).Key;
                if (box.IsChecked == true && a == Edodat.Niezdolnosc.ToString())
                {
                    p = new PakietDodatkowy(Edodat.Niezdolnosc.ToString(), 50000.0, 5, 5, 120.0);
                    klient.historia[klient.historia.Count - 1].PakietKoncowy.DodajPakiet2(p);
                    klient.DodaniePojedynczegoPakietu(12, czas, klient, lUb, podzial);
                    klient.historia[klient.historia.Count - 1].PakietKoncowy.KosztKoncowy += 50000.0;
                    pkdod.DodajPakiet2(p);

                }
                else if (box.IsChecked == true && a == Edodat.Onkolog.ToString())
                {
                    p = new PakietDodatkowy(Edodat.Onkolog.ToString(), 20000.0, 2, 5, 120.0);
                    klient.historia[klient.historia.Count - 1].PakietKoncowy.DodajPakiet2(p);
                    klient.DodaniePojedynczegoPakietu(10, czas, klient, lUb, podzial);
                    klient.historia[klient.historia.Count - 1].PakietKoncowy.KosztKoncowy += 20000.0;
                    pkdod.DodajPakiet2(p);
                }
                else if (box.IsChecked == true && a == Edodat.Ortopeda.ToString())
                {
                    p = new PakietDodatkowy(Edodat.Ortopeda.ToString(), 10000.0, 3, 5, 96.0);
                    klient.historia[klient.historia.Count - 1].PakietKoncowy.DodajPakiet2(p);
                    klient.DodaniePojedynczegoPakietu(8, czas, klient, lUb, podzial);
                    klient.historia[klient.historia.Count - 1].PakietKoncowy.KosztKoncowy += 10000.0;
                    pkdod.DodajPakiet2(p);
                }
                else if (box.IsChecked == true && a == Edodat.PowazneZachorowanieDziecka.ToString())
                {
                    p = new PakietDodatkowy(Edodat.PowazneZachorowanieDziecka.ToString(), 20000.0, 4, 5, 120.0);
                    klient.historia[klient.historia.Count - 1].PakietKoncowy.DodajPakiet2(p);
                    klient.DodaniePojedynczegoPakietu(10, czas, klient, lUb, podzial);
                    klient.historia[klient.historia.Count - 1].PakietKoncowy.KosztKoncowy += 20000.0;
                    pkdod.DodajPakiet2(p);
                }
                else if (box.IsChecked == true && a == Edodat.smiercNW.ToString())
                {
                    p = new PakietDodatkowy(Edodat.smiercNW.ToString(), 100000.0, 6, 5, 60.0);
                    klient.historia[klient.historia.Count - 1].PakietKoncowy.DodajPakiet2(p);
                    klient.DodaniePojedynczegoPakietu(5, czas, klient, lUb, podzial);
                    klient.historia[klient.historia.Count - 1].PakietKoncowy.KosztKoncowy += 100000.0;
                    pkdod.DodajPakiet2(p);
                }
                else if (box.IsChecked == true && a == Edodat.SmiercWK.ToString())
                {
                    p = new PakietDodatkowy(Edodat.SmiercWK.ToString(), 50000.0, 7, 5, 144.0);
                    klient.historia[klient.historia.Count - 1].PakietKoncowy.DodajPakiet2(p);
                    klient.DodaniePojedynczegoPakietu(12, czas, klient, lUb, podzial);
                    klient.historia[klient.historia.Count - 1].PakietKoncowy.KosztKoncowy += 50000.0;
                    pkdod.DodajPakiet2(p);
                }
                else if (box.IsChecked == true && a == Edodat.SportyEkstremalne.ToString())
                {
                    p = new PakietDodatkowy(Edodat.SportyEkstremalne.ToString(), 5000.0, 1, 5, 60.0);
                    klient.historia[klient.historia.Count - 1].PakietKoncowy.DodajPakiet2(p);
                    klient.DodaniePojedynczegoPakietu(5, czas, klient, lUb, podzial);
                    klient.historia[klient.historia.Count - 1].PakietKoncowy.KosztKoncowy += 5000.0;
                    pkdod.DodajPakiet2(p);
                }

            }
            pkdod.LiczenieSumySkladek(pkdod);
            klient.historia[klient.historia.Count - 1].PakietKoncowy = pk;

            foreach (PakietDodatkowy p in klient.historia[klient.historia.Count - 1].PakietKoncowy.dodatkowe)
            {
                Console.WriteLine("W dodatkowych " + p.ToString());
            }

            Klient2Window okno = new Klient2Window(klient, decyzja, czas,true, podzial);
            this.Close();
            okno.ShowDialog();
        }

        private void Cofnij_Click(object sender, RoutedEventArgs e)
        {
            Klient2Window okno = new Klient2Window(klient, decyzja, czas, true, podzial);
            this.Close();
            okno.ShowDialog();
        }
    }
}
