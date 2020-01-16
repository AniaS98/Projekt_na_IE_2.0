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
    /// Logika interakcji dla klasy UsunPakietWindow.xaml
    /// </summary>
    public partial class UsunPakietWindow : Window
    {
        Klient klient;
        int czas;
        bool decyzja;
        List<CheckBox> checkboxy = new List<CheckBox>();
        CheckBox box = new CheckBox();
        List<string> wszystkie = new List<string>();
        PakietDodatkowy p = new PakietDodatkowy();
        PakietKoncowy pkus = new PakietKoncowy();
        int podzial;
        int lUb;
        Dictionary<string, string> NazwyPakietow = new Dictionary<string, string>()
            {
                { "SportyEkstremalne","Sporty Ekstremalne" }, {"Onkolog","Pakiet Onkolog" }, {"Ortopeda","Pakiet Ortopeda" }, {"PowazneZachorowanieDziecka","Poważne zachorowanie dziecka" }, {"Niezdolnosc","Niezdolność do wykonywania zawodu" }, {"SmiercWK","Śmierć w wypadku komunikacyjnym" },{"smiercNW","Śmierć w nieszczęśliwym wypadku" }
            };
        public UsunPakietWindow(Klient klient, int c, List<string> lista, PakietKoncowy pk,int podzial,int lUb)
        {
            this.lUb = lUb;
            this.podzial = podzial;
            foreach (var item in Enum.GetNames(typeof(Edodat)))
            {
                wszystkie.Add(item);
            }
            this.klient = klient;
            czas = c;
            InitializeComponent();

            int k = klient.historia.Count - 1;
            foreach (string s in lista)
            {
                box = new CheckBox();
                box.Content = s;
                checkboxy.Add(box);
            }
            ListBox_Pakiet.ItemsSource = checkboxy;
        }

        private void Akceptuj_Click(object sender, RoutedEventArgs e)
        {
            
            foreach (CheckBox box in ListBox_Pakiet.Items)
            {
                string a = NazwyPakietow.FirstOrDefault(x => x.Value == box.Content.ToString()).Key;
                Console.WriteLine("Coś się usunęło");
                if (box.IsChecked == true && a == Edodat.Niezdolnosc.ToString())
                {
                    //p = new PakietDodatkowy(Edodat.Niezdolnosc.ToString(), 50000.0, 5, 5, 120.0);
                    klient.historia[klient.historia.Count - 1].PakietKoncowy.UsunPakiet2(Edodat.Niezdolnosc.ToString());
                    klient.UsuwaniePojedynczegoPakietu(12, czas, klient, lUb, podzial);
                    klient.historia[klient.historia.Count - 1].PakietKoncowy.KosztKoncowy -= 50000.0;
                    Console.WriteLine("Niezdolność");
                }
                else if (box.IsChecked == true && a == Edodat.Onkolog.ToString())
                {
                    //p = new PakietDodatkowy(Edodat.Onkolog.ToString(), 20000.0, 2, 5, 120.0);
                    klient.historia[klient.historia.Count - 1].PakietKoncowy.UsunPakiet2(Edodat.Onkolog.ToString());
                    klient.UsuwaniePojedynczegoPakietu(10, czas, klient, lUb, podzial);
                    klient.historia[klient.historia.Count - 1].PakietKoncowy.KosztKoncowy -= 20000.0;
                }
                else if (box.IsChecked == true && a == Edodat.Ortopeda.ToString())
                {
                    //p = new PakietDodatkowy(Edodat.Ortopeda.ToString(), 10000.0, 3, 5, 96.0);
                    klient.historia[klient.historia.Count - 1].PakietKoncowy.UsunPakiet2(Edodat.Ortopeda.ToString());
                    klient.UsuwaniePojedynczegoPakietu(8, czas, klient, lUb, podzial);
                    klient.historia[klient.historia.Count - 1].PakietKoncowy.KosztKoncowy -= 10000.0;
                }
                else if (box.IsChecked == true && a == Edodat.PowazneZachorowanieDziecka.ToString())
                {
                    //p = new PakietDodatkowy(Edodat.PowazneZachorowanieDziecka.ToString(), 20000.0, 4, 5, 120.0);
                    klient.historia[klient.historia.Count - 1].PakietKoncowy.UsunPakiet2(Edodat.PowazneZachorowanieDziecka.ToString());
                    klient.UsuwaniePojedynczegoPakietu(10, czas, klient, lUb, podzial);
                    klient.historia[klient.historia.Count - 1].PakietKoncowy.KosztKoncowy -= 20000.0;
                }
                else if (box.IsChecked == true && a == Edodat.smiercNW.ToString())
                {
                    //p = new PakietDodatkowy(Edodat.smiercNW.ToString(), 100000.0, 6, 5, 60.0);
                    klient.historia[klient.historia.Count - 1].PakietKoncowy.UsunPakiet2(Edodat.smiercNW.ToString());
                    klient.UsuwaniePojedynczegoPakietu(5, czas, klient, lUb, podzial);
                    klient.historia[klient.historia.Count - 1].PakietKoncowy.KosztKoncowy -= 100000.0;
                }
                else if (box.IsChecked == true && a == Edodat.SmiercWK.ToString())
                {
                    //p = new PakietDodatkowy(Edodat.SmiercWK.ToString(), 50000.0, 7, 5, 144.0);
                    klient.historia[klient.historia.Count - 1].PakietKoncowy.UsunPakiet2(Edodat.SmiercWK.ToString());
                    klient.UsuwaniePojedynczegoPakietu(12, czas, klient, lUb, podzial);
                    klient.historia[klient.historia.Count - 1].PakietKoncowy.KosztKoncowy -= 50000.0;
                }
                else if (box.IsChecked == true && a == Edodat.SportyEkstremalne.ToString())
                {
                    //p = new PakietDodatkowy(Edodat.SportyEkstremalne.ToString(), 5000.0, 1, 5, 60.0);
                    klient.historia[klient.historia.Count - 1].PakietKoncowy.UsunPakiet2(Edodat.SportyEkstremalne.ToString());
                    klient.UsuwaniePojedynczegoPakietu(5, czas, klient, lUb, podzial);
                    klient.historia[klient.historia.Count - 1].PakietKoncowy.KosztKoncowy -= 5000.0;
                }

            }
            Console.WriteLine("Wypisaeni w usuwaniu");
            foreach (PakietDodatkowy p in klient.historia[klient.historia.Count - 1].PakietKoncowy.dodatkowe)
                Console.WriteLine(p.ToString());

            Klient2Window okno = new Klient2Window(klient, decyzja, czas, true, podzial);
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
