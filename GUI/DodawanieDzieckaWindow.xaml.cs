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
        int dzieci = 0;
        bool decyzja;
        int czas;
        Klient klient;
        public DodawanieDzieckaWindow(Klient klient, bool d, int c, int dz)
        {
            decyzja = d;
            dzieci = dz;
            czas = c;
            InitializeComponent();
            this.klient = klient;
        }

        private void Akceptuj_Click(object sender, RoutedEventArgs e)
        {
            CzlonekRodziny dziecko = new CzlonekRodziny();
            if (Convert.ToInt32(TextBox_WiekDziecka.Text) > 18)
            {
                MessageBox.Show("Dziecko nie może mieć powyżej 18 lat.");
            }
            TextBox_WiekDziecka.Text = dziecko.Wiek.ToString();
            RodzinnyWindow okno = new RodzinnyWindow(klient, decyzja, czas, dzieci);
            okno.Activate();
            Console.WriteLine(dziecko.Wiek.ToString());

        }
    }
}