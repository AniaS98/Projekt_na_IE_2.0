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
    /// Logika interakcji dla klasy AgentOczekujacyNaKontakt.xaml
    /// </summary>
    public partial class AgentOczekujacyNaKontakt : Window
    {
        public string agent;
        public AgentOczekujacyNaKontakt(string a)
        {
            InitializeComponent();
            agent = a;

            ListaKlientow lista = ListaKlientow.OdczytajXML("ListaKlientówDoKontaktu.xml");
            StringBuilder sb = new StringBuilder();
            foreach(Klient k in lista.klienci)
            {
                sb.Append(k.ToString());
                sb.Append("\n");
            }
            //ListBox = sb.ToString();


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AgentWindow okno = new AgentWindow(agent);
            this.Close();
            okno.ShowDialog();
        }
    }
}
