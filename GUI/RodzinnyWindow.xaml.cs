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
        public RodzinnyWindow(Klient klient, bool d, int c)
        {
            czas = c;
            decyzja = d;
            InitializeComponent();
            this.klient = klient;
        }




        private void Cofnij_Click(object sender, RoutedEventArgs e)
        {
            PakietWindow okno = new PakietWindow(klient, decyzja);
            this.Close();
            okno.ShowDialog();
        }

        private void Akceptuj_Click(object sender, RoutedEventArgs e)
        {
            Klient2Window okno = new Klient2Window(klient, decyzja, czas);
            this.Close();
            okno.ShowDialog();
        }

        private void DodajDziecko_Click(object sender, RoutedEventArgs e)
        {
            int liczba;
            liczba = Convert.ToInt32(TextBox_LiczbaDzieci.Text);
            DodawanieDzieckaWindow okno = new DodawanieDzieckaWindow();
            okno.ShowDialog();
        }
    }
}
