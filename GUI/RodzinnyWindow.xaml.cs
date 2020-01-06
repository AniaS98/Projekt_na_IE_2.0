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
    /// Logika interakcji dla klasy RodzinnyWindow.xaml
    /// </summary>
    public partial class RodzinnyWindow : Window
    {
        int czas;
        bool decyzja = true;
        Klient klient;
        //CzlonekRodziny dziecko;
        int count = 0;

        public RodzinnyWindow()
        {
            InitializeComponent();
        }

        public void DodajDziecko_Click(object sender, RoutedEventArgs e)
        {
            DodawanieDzieckaWindow okno = new DodawanieDzieckaWindow(klient, decyzja, czas, count);
            okno.ShowDialog();
            count++;
            TextBox_LiczbaDzieci.Text = count.ToString();
        }

        private void Cofnij_Click(object sender, RoutedEventArgs e)
        {
            PakietWindow okno = new PakietWindow(klient, decyzja);
            this.Close();
            okno.ShowDialog();
        }

        public void Akceptuj_Click(object sender, RoutedEventArgs e)
        {
            if (CheckBox_Dzieci.IsChecked == true)
            {
                for (int d = 1; d <= klient.rodzina.Count; d++)
                {
                    DodawanieDzieckaWindow dodawanie = new DodawanieDzieckaWindow(klient, decyzja, czas, count);
                    //dodawanie.
                }

            }
            else if (CheckBox_Dzieci.IsChecked == false)
            {
                int d = klient.rodzina.Count;
                d = 0;
            }

            if (CheckBox_Malzonek.IsChecked == true)
            {
                klient.Malzonek = true;
            }
            else if (CheckBox_Malzonek.IsChecked == false)
            {
                klient.Malzonek = false;
            }

            Klient2Window okno = new Klient2Window(klient, decyzja, czas);
            this.Close();
            okno.ShowDialog();
        }

        public RodzinnyWindow(Klient klient, bool de, int c) : this()
        {
            czas = c;
            decyzja = de;
            this.klient = klient;
        }

    }
}