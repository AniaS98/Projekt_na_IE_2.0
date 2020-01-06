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
        public DodatkowyPakietWindow(Klient k, int c)
        {
            klient = k;
            czas = c;
            InitializeComponent();
        }
        //Justyna, w listboxsie powinny się pokazać wszystkie pakiet, a te które są wybrane powinny być zaznaczone i wtedy użtkownik może je odznaczyć i zaznaczyć coś innego, a po kliknięciu zatwierdź przez wszystkie zaznaczone przejdzie foreach, który zapisze je do zamówienia
        private void Akceptuj_Click(object sender, RoutedEventArgs e)
        {
            PakietDodatkowy p = new PakietDodatkowy();
            PakietKoncowy pk = new PakietKoncowy();
            foreach (ListBoxItem pd in ListBoxPakiet.SelectedItems)
            {
                if (pd.Content.ToString() == Edodat.Niezdolnosc.ToString())
                {
                    p = new PakietDodatkowy(Edodat.Niezdolnosc.ToString(), 50000.0, 5, 5, 120.0);
                    pk.DodajPakiet2(p);
                }
                else if (pd.Content.ToString() == Edodat.Onkolog.ToString())
                {
                    p = new PakietDodatkowy(Edodat.Onkolog.ToString(), 20000.0, 2, 5, 120.0);
                    pk.DodajPakiet2(p);
                }
                else if (pd.Content.ToString() == Edodat.Ortopeda.ToString())
                {
                    p = new PakietDodatkowy(Edodat.Ortopeda.ToString(), 10000.0, 3, 5, 96.0);
                    pk.DodajPakiet2(p);
                }
                else if (pd.Content.ToString() == Edodat.PowazneZachorowanieDziecka.ToString())
                {
                    p = new PakietDodatkowy(Edodat.PowazneZachorowanieDziecka.ToString(), 20000.0, 4, 5, 120.0);
                    pk.DodajPakiet2(p);
                }
                else if (pd.Content.ToString() == Edodat.smiercNW.ToString())
                {
                    p = new PakietDodatkowy(Edodat.smiercNW.ToString(), 100000.0, 6, 5, 60.0);
                    pk.DodajPakiet2(p);
                }
                else if (pd.Content.ToString() == Edodat.SmiercWK.ToString())
                {
                    p = new PakietDodatkowy(Edodat.SmiercWK.ToString(), 50000.0, 7, 5, 144.0);
                    pk.DodajPakiet2(p);
                }
                else if (pd.Content.ToString() == Edodat.SportyEkstremalne.ToString())
                {
                    p = new PakietDodatkowy(Edodat.SportyEkstremalne.ToString(), 5000.0, 1, 5, 60.0);
                    pk.DodajPakiet2(p);
                }


            }
            klient.historia[klient.historia.Count - 1].PakietKoncowy.dodatkowe = pk.dodatkowe;

        }


    }
}
