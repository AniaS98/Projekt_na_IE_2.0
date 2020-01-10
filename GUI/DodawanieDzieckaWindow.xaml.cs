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
        public DodawanieDzieckaWindow()
        {
            InitializeComponent(); 
        }

        public void Akceptuj_Click(object sender, RoutedEventArgs e)
        {
            
            for (int d = 1; d <= klient.rodzina.Count; d++)
            {
                Console.WriteLine(klient.rodzina[d].Wiek);
            }
            count++;
            /*if (Convert.ToInt32(TextBox_WiekDziecka.Text) > 18)
            {
                MessageBox.Show("Dziecko nie może mieć powyżej 18 lat.");
            }*/
            Console.WriteLine(count);
            RodzinnyWindow okno = new RodzinnyWindow(klient, decyzja, czas, zamowienie, count);
            /*if (!okno.IsVisible)
            {
                okno.Show();
            }

            if (okno.WindowState == WindowState.Minimized)
            {
                okno.WindowState = WindowState.Normal;
            }*/
            okno.CheckBox_Dzieci.IsChecked=true;
            this.Close();
            okno.ShowDialog();
      }

        public DodawanieDzieckaWindow(Klient klient, bool de, int c, int co) : this()
        {
            decyzja = de;
            czas = c;
            count = co;
            this.klient = klient;
            for (int d = 1; d <= klient.rodzina.Count; d++)
            {
                klient.rodzina[d].Wiek = Convert.ToInt32(TextBox_WiekDziecka);
            }
        }
    }
}