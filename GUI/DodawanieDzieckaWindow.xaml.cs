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

            /*if (Convert.ToInt32(TextBox_WiekDziecka.Text) > 18)
            {
                MessageBox.Show("Dziecko nie może mieć powyżej 18 lat.");
            }*/

            RodzinnyWindow okno = new RodzinnyWindow(klient, decyzja, czas);
            okno.Activate();
            this.Close();
        }

        public DodawanieDzieckaWindow(Klient klient, bool de, int c, int co) : this()
        {
            decyzja = de;
            czas = c;
            count = co;
            /*if(Akceptuj.IsInitialized == false)
            {
                count--;
            }*/
            this.klient = klient;
            for (int d = 1; d <= klient.rodzina.Count; d++)
            {
                TextBox_WiekDziecka.Text = klient.rodzina[d].Wiek.ToString();
            }
        }
    }
}