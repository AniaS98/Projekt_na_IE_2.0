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
    /// Logika interakcji dla klasy Klient2Window.xaml
    /// </summary>
    public partial class Klient2Window : Window
    {
        Klient klient;
        bool decyzja;
        int czas;
        int liczba_ubezpieczonych;
        public Klient2Window(Klient klient, bool de, int c)
        {
            this.klient = klient;
            czas = c;
            decyzja = de;
            InitializeComponent();
            //Console.WriteLine(klient.Zawod.ToString());
            klient.FunkcjaPakietDodatkowy(czas, klient, liczba_ubezpieczonych,1);//Zamiast 12 ma być podział (składka miesięczna czy roczna)
            if (decyzja == true)
            {
                klient.PakietRodzinny(czas, klient);
            }
            else
            {
                klient.PakietPodstawowyIndywiduany(czas, klient);
            }

            int k = klient.historia.Count - 1;
            List<PakietDodatkowy> lista = klient.historia[k].PakietKoncowy.dodatkowe;
            StringBuilder sb = new StringBuilder();
            List<string> LS = new List<string>();
            for (int i = 0; i < lista.Count; i++)
            {
                LS.Add(lista[i].Nazwa.ToString());
            }
            ListBox_Pakiety.ItemsSource = LS;
            Suma.Text = klient.historia[k].PakietKoncowy.Skladka.ToString();
            kosztKoncowy.Text = klient.historia[k].PakietKoncowy.KosztKoncowy.ToString();
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

        private void DodajPakiet_Click(object sender, RoutedEventArgs e)
        {




            List<string> lista = new List<string>();
            foreach(string s in ListBox_Pakiety.Items)
            {
                lista.Add(s.ToString());
            }

            DodatkowyPakietWindow okno = new DodatkowyPakietWindow(klient, czas, lista);
            this.Close();
            okno.ShowDialog();
        }

        private void UsunPakiet_Click(object sender, RoutedEventArgs e)
        {
            List<string> lista = new List<string>();
            foreach (string s in ListBox_Pakiety.Items)
            {
                lista.Add(s.ToString());
            }
            UsunPakietWindow okno = new UsunPakietWindow(klient, czas, lista);
            this.Close();
            okno.ShowDialog();
        }
    }
}
