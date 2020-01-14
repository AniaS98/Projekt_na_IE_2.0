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
        PakietKoncowy pk;
        PakietKoncowy pkus = new PakietKoncowy();
        Dictionary<string, string> NazwyPakietow = new Dictionary<string, string>()
            {
                { "SportyEkstremalne","Sporty Ekstremalne" }, {"Onkolog","Pakiet Onkolog" }, {"Ortopeda","Pakiet Ortopeda" }, {"PowazneZachorowanieDziecka","Poważne zachorowanie dziecka" }, {"Niezdolnosc","Niezdolność do wykonywania zawodu" }, {"SmiercWK","Śmierć w wypadku komunikacyjnym" },{"smiercNW","Śmierć w nieszczęśliwym wypadku" }
            };
        public UsunPakietWindow(Klient klient, int c, List<string> lista, PakietKoncowy pk)
        {
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
            string nazwa = p.Nazwa;
            pk = klient.historia[klient.historia.Count - 1].PakietKoncowy;
            string a = NazwyPakietow.FirstOrDefault(x => x.Value == box.Content.ToString()).Key;
            foreach (CheckBox box in ListBox_Pakiet.Items)
            {
                if (box.IsChecked == true && a == Edodat.Niezdolnosc.ToString())
                {
                    p = new PakietDodatkowy(Edodat.Niezdolnosc.ToString(), 50000.0, 5, 5, 120.0);
                    pk.UsunPakiet2(p.Nazwa);
                    pkus.UsunPakiet2(nazwa);
                }
                else if (box.IsChecked == true && a == Edodat.Onkolog.ToString())
                {
                    p = new PakietDodatkowy(Edodat.Onkolog.ToString(), 20000.0, 2, 5, 120.0);
                    pk.UsunPakiet2(p.Nazwa);
                    pkus.UsunPakiet2(nazwa);
                }
                else if (box.IsChecked == true && a == Edodat.Ortopeda.ToString())
                {
                    p = new PakietDodatkowy(Edodat.Ortopeda.ToString(), 10000.0, 3, 5, 96.0);
                    pk.UsunPakiet2(p.Nazwa);
                    pkus.UsunPakiet2(nazwa);
                }
                else if (box.IsChecked == true && a == Edodat.PowazneZachorowanieDziecka.ToString())
                {
                    p = new PakietDodatkowy(Edodat.PowazneZachorowanieDziecka.ToString(), 20000.0, 4, 5, 120.0);
                    pk.UsunPakiet2(p.Nazwa);
                    pkus.UsunPakiet2(nazwa);
                }
                else if (box.IsChecked == true && a == Edodat.smiercNW.ToString())
                {
                    p = new PakietDodatkowy(Edodat.smiercNW.ToString(), 100000.0, 6, 5, 60.0);
                    pk.UsunPakiet2(p.Nazwa);
                    pkus.UsunPakiet2(nazwa);
                }
                else if (box.IsChecked == true && a == Edodat.SmiercWK.ToString())
                {
                    p = new PakietDodatkowy(Edodat.SmiercWK.ToString(), 50000.0, 7, 5, 144.0);
                    pk.UsunPakiet2(p.Nazwa);
                    pkus.UsunPakiet2(nazwa);
                }
                else if (box.IsChecked == true && a == Edodat.SportyEkstremalne.ToString())
                {
                    p = new PakietDodatkowy(Edodat.SportyEkstremalne.ToString(), 5000.0, 1, 5, 60.0);
                    pk.UsunPakiet2(p.Nazwa);
                    pkus.UsunPakiet2(nazwa);
                }

            }
            pkus.LiczenieSumySkladek(pkus);
            klient.historia[klient.historia.Count - 1].PakietKoncowy = pk;

            Klient2Window okno = new Klient2Window(klient, decyzja, czas, true);
            this.Close();
            okno.ShowDialog();
        }

        private void Cofnij_Click(object sender, RoutedEventArgs e)
        {
            Klient2Window okno = new Klient2Window(klient, decyzja, czas, true);
            this.Close();
            okno.ShowDialog();
        }
    }
}
