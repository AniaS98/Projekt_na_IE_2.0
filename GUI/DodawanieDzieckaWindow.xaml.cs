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
    /// Logika interakcji dla klasy DodawanieDzieckaWindow.xaml
    /// </summary>
    public partial class DodawanieDzieckaWindow : Window
    {

        bool decyzja;
        int czas;
        int count;
        Klient klient;
        Zamowienie zamowienie;
        int podzial;
        public DodawanieDzieckaWindow()
        {
            InitializeComponent(); 
        }

        public void Akceptuj_Click(object sender, RoutedEventArgs e)
        {

            CzlonekRodziny dziecko = new CzlonekRodziny();
            dziecko.Wiek =Convert.ToInt32( TextBox_WiekDziecka.Text);
            klient.DodajCzlonkaRodziny(dziecko);
            count++;
            if (Convert.ToInt32(TextBox_WiekDziecka.Text) > 18)
            {
                MessageBox.Show("Dziecko nie może mieć powyżej 18 lat.");
                return;
            }
            Console.WriteLine(count);
            RodzinnyWindow okno = new RodzinnyWindow(klient, decyzja, czas, zamowienie, count,podzial);

            okno.CheckBox_Dzieci.IsChecked=true;
            this.Close();
            okno.ShowDialog();
        }

        public DodawanieDzieckaWindow(Klient klient, bool de, int c, int co,int podzial) : this()
        {
            this.podzial = podzial;
            decyzja = de;
            czas = c;
            count = co;
            this.klient = klient;
            //klient.rodzina[d].Wiek = Convert.ToInt32(TextBox_WiekDziecka);
        }
    }
}