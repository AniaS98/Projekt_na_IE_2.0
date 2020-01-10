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
        Zamowienie zamowienie;
        int count = 0;

        public RodzinnyWindow()
        {
            InitializeComponent();
        }

        public void DodajDziecko_Click(object sender, RoutedEventArgs e)
        {
            DodawanieDzieckaWindow okno = new DodawanieDzieckaWindow(klient, decyzja, czas, count);
            this.Close();
            okno.ShowDialog();  
        }

        private void Cofnij_Click(object sender, RoutedEventArgs e)
        {
            PakietWindow okno = new PakietWindow(klient, decyzja, zamowienie);
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
                    //dodawanie
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

        public RodzinnyWindow(Klient klient, bool de, int c, Zamowienie z, int co) : this()
        {
            czas = c;
            decyzja = de;
            count = co;
            this.klient = klient;
            z = zamowienie;
            TextBox_LiczbaDzieci.Text = count.ToString();

            //deklaracja malzonka
            /*if (klient.Malzonek == true)
            {
                CheckBox_Malzonek.IsChecked = true;
            }           
            else if (klient.Malzonek == false)
            {
                CheckBox_Malzonek.IsChecked = false;            
            }*/
        }

    }
}