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
        bool decyzja;
        int czas;
        public Klient2Window(Klient klient, bool d, int c)
        {
            
            czas = c;
            decyzja = d;
            InitializeComponent();
            Console.WriteLine(klient.Zawod.ToString());
            klient.FunkcjaPakietDodatkowy(czas, klient);
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
            for(int i=0;i<lista.Count;i++)
            {
                sb.Append(lista[i].Nazwa.ToString());
                sb.Append("\n");
            }
            TextBox_Pakiety.Text = sb.ToString();
            Suma.Text = klient.historia[k].PakietKoncowy.Skladka.ToString();
            kosztKoncowy.Text = klient.historia[k].PakietKoncowy.KosztKoncowy.ToString();
        }

        private void Kontakt_Click(object sender, RoutedEventArgs e)
        {
            KontaktWindow okno = new KontaktWindow();
            this.Close();
            okno.ShowDialog();
        }

        private void Powrot_Click(object sender, RoutedEventArgs e)
        {
            MainWindow okno = new MainWindow();
            this.Close();
            okno.ShowDialog();
        }
        //Klient.results;

    }
}
