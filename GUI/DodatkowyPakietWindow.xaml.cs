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
        public DodatkowyPakietWindow(Klient klient, int c, List<string> lista, PakietKoncowy pk, int podzial)
        {
            this.podzial = podzial;
            foreach (var item in Enum.GetNames(typeof(Edodat)))
            {
                wszystkie.Add(item);
            }
            foreach (string s in lista)
            {
                wszystkie.Remove(s);
            }

            //this.pk = pk;
            this.klient = klient;
            czas = c;
            InitializeComponent();

            foreach (string s in wszystkie)
            {
                box = new CheckBox();
                box.Content = s;
                checkboxy.Add(box);
            }
            ListBox_Pakiet.ItemsSource = checkboxy;

        }

        public void Akceptuj_Click(object sender, RoutedEventArgs e)
        {
            pk = klient.historia[klient.historia.Count - 1].PakietKoncowy;

            foreach (CheckBox box in ListBox_Pakiet.Items)
            {
                if (box.IsChecked == true && box.Content.ToString() == Edodat.Niezdolnosc.ToString())
                {
                    p = new PakietDodatkowy(Edodat.Niezdolnosc.ToString(), 50000.0, 5, 5, 120.0);
                    pk.DodajPakiet2(p);
                    pkdod.DodajPakiet2(p);
                }
                else if (box.IsChecked == true && box.Content.ToString() == Edodat.Onkolog.ToString())
                {
                    p = new PakietDodatkowy(Edodat.Onkolog.ToString(), 20000.0, 2, 5, 120.0);
                    pk.DodajPakiet2(p);
                    pkdod.DodajPakiet2(p);
                }
                else if (box.IsChecked == true && box.Content.ToString() == Edodat.Ortopeda.ToString())
                {
                    p = new PakietDodatkowy(Edodat.Ortopeda.ToString(), 10000.0, 3, 5, 96.0);
                    pk.DodajPakiet2(p);
                    pkdod.DodajPakiet2(p);
                }
                else if (box.IsChecked == true && box.Content.ToString() == Edodat.PowazneZachorowanieDziecka.ToString())
                {
                    p = new PakietDodatkowy(Edodat.PowazneZachorowanieDziecka.ToString(), 20000.0, 4, 5, 120.0);
                    pk.DodajPakiet2(p);
                    pkdod.DodajPakiet2(p);
                }
                else if (box.IsChecked == true && box.Content.ToString() == Edodat.smiercNW.ToString())
                {
                    p = new PakietDodatkowy(Edodat.smiercNW.ToString(), 100000.0, 6, 5, 60.0);
                    pk.DodajPakiet2(p);
                    pkdod.DodajPakiet2(p);
                }
                else if (box.IsChecked == true && box.Content.ToString() == Edodat.SmiercWK.ToString())
                {
                    p = new PakietDodatkowy(Edodat.SmiercWK.ToString(), 50000.0, 7, 5, 144.0);
                    pk.DodajPakiet2(p);
                    pkdod.DodajPakiet2(p);
                }
                else if (box.IsChecked == true && box.Content.ToString() == Edodat.SportyEkstremalne.ToString())
                {
                    p = new PakietDodatkowy(Edodat.SportyEkstremalne.ToString(), 5000.0, 1, 5, 60.0);
                    pk.DodajPakiet2(p);
                    pkdod.DodajPakiet2(p);
                }

            }
            pkdod.LiczenieSumySkladek(pkdod);
            klient.historia[klient.historia.Count - 1].PakietKoncowy = pk;

            foreach (PakietDodatkowy p in klient.historia[klient.historia.Count - 1].PakietKoncowy.dodatkowe)
            {
                Console.WriteLine("W dodatkowych " + p.ToString());
            }

            Klient2Window okno = new Klient2Window(klient, decyzja, czas,podzial);
            this.Close();
            okno.ShowDialog();
        }

        private void Cofnij_Click(object sender, RoutedEventArgs e)
        {
            Klient2Window okno = new Klient2Window(klient, decyzja, czas, podzial);
            this.Close();
            okno.ShowDialog();
        }
    }
}
