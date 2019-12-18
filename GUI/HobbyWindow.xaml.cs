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
    /// Logika interakcji dla klasy HobbyWindow.xaml
    /// </summary>
    public partial class HobbyWindow : Window
    {
        Klient klient;
        bool decyzja;
        public HobbyWindow(Klient klient, bool d)
        {
            decyzja = d;
            InitializeComponent();
            this.klient = klient;
        }

        private void Zatwierdz_Click(object sender, RoutedEventArgs e)
        {
            foreach(CheckBox cb in ListBox_Hobby.Items)
            {
                if (cb.IsChecked == true && cb.Name== "wspinaczka_gorska")
                {
                    klient.DodajHobby(Pasje.wspinaczka_gorska);
                }
                if (cb.IsChecked == true && cb.Name == "sporty_ekstremalne")
                {
                    klient.DodajHobby(Pasje.sporty_ekstremalne);
                }
                if (cb.IsChecked == true && cb.Name == "rower")
                {
                    klient.DodajHobby(Pasje.rower);
                }
                if (cb.IsChecked == true && cb.Name == "hobby_artystyczne")
                {
                    klient.DodajHobby(Pasje.hobby_artystyczne);
                }
                if (cb.IsChecked == true && cb.Name == "hobby_techniczne")
                {
                    klient.DodajHobby(Pasje.hobby_techniczne);
                }
                if (cb.IsChecked == true && cb.Name == "ksiazki")
                {
                    klient.DodajHobby(Pasje.ksiazki);
                }
                if (cb.IsChecked == true && cb.Name == "gry_komputerowe")
                {
                    klient.DodajHobby(Pasje.gry_komputerowe);
                }
                if (cb.IsChecked == true && cb.Name == "sporty_zimowe")
                {
                    klient.DodajHobby(Pasje.sporty_zimowe);
                }
                if (cb.IsChecked == true && cb.Name == "podrozowanie")
                {
                    klient.DodajHobby(Pasje.podrozowanie);
                }
                if (cb.IsChecked == true && cb.Name == "rekonstrukcje_historyczne")
                {
                    klient.DodajHobby(Pasje.rekonstrukcje_historyczne);
                }
                if (cb.IsChecked == true && cb.Name == "jazda_konna")
                {
                    klient.DodajHobby(Pasje.jazda_konna);
                }
                if (cb.IsChecked == true && cb.Name == "sporty_wodne")
                {
                    klient.DodajHobby(Pasje.sporty_wodne);
                }
                if (cb.IsChecked == true && cb.Name == "sporty_druzynowe")
                {
                    klient.DodajHobby(Pasje.sporty_druzynowe);
                }
                if (cb.IsChecked == true && cb.Name == "lekkoatletyka")
                {
                    klient.DodajHobby(Pasje.lekkoatletyka);
                }
            }

            foreach (Pasje p in klient.Hobbies)
            {
                Console.WriteLine(p);
            }
            PakietWindow okno = new PakietWindow(klient, decyzja);
            okno.Activate();
            this.Close();
        }
    }

}
