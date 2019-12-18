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
    /// Logika interakcji dla klasy ChorobyWindow.xaml
    /// </summary>
    public partial class ChorobyWindow : Window
    {
        Klient klient;
        bool decyzja;
        public ChorobyWindow(Klient klient, bool d)
        {
            decyzja = d;
            InitializeComponent();
            this.klient = klient;
        }

        private void Zatwierdz_Click(object sender, RoutedEventArgs e)
        {
            foreach (CheckBox cb in ListBox_Choroby.Items)
            {
                if (cb.IsChecked == true && cb.Name == "brak")
                {
                    klient.DodajChorobe(Choroby.brak);
                }
                if (cb.IsChecked == true && cb.Name == "nowotwory")
                {
                    klient.DodajChorobe(Choroby.nowotwory);
                }
                if (cb.IsChecked == true && cb.Name == "stwardnienie_rozsiane")
                {
                    klient.DodajChorobe(Choroby.stwardnienie_rozsiane);
                }
                if (cb.IsChecked == true && cb.Name == "choroby_ukladu_krazenia")
                {
                    klient.DodajChorobe(Choroby.choroby_ukladu_krazenia);
                }
                if (cb.IsChecked == true && cb.Name == "choroby_wiencowe")
                {
                    klient.DodajChorobe(Choroby.choroby_wiencowe);
                }
                if (cb.IsChecked == true && cb.Name == "epilepsja")
                {
                    klient.DodajChorobe(Choroby.epilepsja);
                }
                if (cb.IsChecked == true && cb.Name == "cukrzyca")
                {
                    klient.DodajChorobe(Choroby.cukrzyca);
                }
                if (cb.IsChecked == true && cb.Name == "astma")
                {
                    klient.DodajChorobe(Choroby.astma);
                }
                if (cb.IsChecked == true && cb.Name == "nadcisnienie")
                {
                    klient.DodajChorobe(Choroby.nadcisnienie);
                }
                if (cb.IsChecked == true && cb.Name == "silne_alergie")
                {
                    klient.DodajChorobe(Choroby.silne_alergie); ;
                }
                if (cb.IsChecked == true && cb.Name == "przewlekle_choroby_ukladu_oddechowego")
                {
                    klient.DodajChorobe(Choroby.przewlekle_choroby_ukladu_oddechowego);
                }
                if (cb.IsChecked == true && cb.Name == "choroba_Alzheimera")
                {
                    klient.DodajChorobe(Choroby.choroba_Alzheimera);
                }
                if (cb.IsChecked == true && cb.Name == "zespol_Parkinsona")
                {
                    klient.DodajChorobe(Choroby.zespol_Parkinsona);
                }
                if (cb.IsChecked == true && cb.Name == "osteoporoza")
                {
                    klient.DodajChorobe(Choroby.osteoporoza);
                }
                if (cb.IsChecked == true && cb.Name == "niedoczynnosc_tarczycy")
                {
                    klient.DodajChorobe(Choroby.niedoczynnosc_tarczycy);
                }
            }
            foreach (Choroby c in klient.Chorobies)
            {
                Console.WriteLine(c);
            }
            PakietWindow okno = new PakietWindow(klient, decyzja);
            okno.Activate();
            this.Close();
        }
    }

}

