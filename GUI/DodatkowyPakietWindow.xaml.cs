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
    /// Logika interakcji dla klasy DodatkowyPakietWindow.xaml
    /// </summary>
    public partial class DodatkowyPakietWindow : Window
    {
        Klient klient;
        bool decyzja;
        int czas;
        PakietDodatkowy pd;
        public DodatkowyPakietWindow(Klient klient, bool de, int c)
        {
            this.klient = klient;
            czas = c;
            decyzja = de;
            InitializeComponent();

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
            for (int i = 0; i < lista.Count; i++)
            {
                sb.Append(lista[i].Nazwa.ToString());
                sb.Append("\n");
            }
            
            /*if(lista.Contains.Onkolog == false)
            {
                sb.Add(Onkolog);
            }*/
            //TextBox_Pakiety.Text = sb.ToString();
        }
    }
}
