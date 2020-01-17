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
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace GUI
{
    /// <summary>
    /// Logika interakcji dla klasy KontaktWindow.xaml
    /// </summary>
    public partial class KontaktWindow : Window
    {
        Klient klient;
        public KontaktWindow(Klient k)
        {
            klient = k;
            InitializeComponent();
        }
        //W panelu agenta powinna być listbox z info z ListaKlientówDoKontaktu.XML i tam agent będzie mógł się skontktować z klientami i zapisać wynik rozmowy
        private void Akceptuj_Click(object sender, RoutedEventArgs e)
        {
            if (TextBox_Imie.Text == "" || TextBox_Nazwisko.Text == "" || TextBox_Telefon.Text.Length != 9)
            {
                MessageBox.Show("Proszę poprawnie uzupełnić dane!\n Numer telefonu powinien zawierać 9 cyfr.");
                return;
            }

            klient.Imie = TextBox_Imie.Text;
            klient.Nazwisko = TextBox_Nazwisko.Text;
            klient.NumerTelefonu = TextBox_Telefon.Text;
            ListaKlientow ListaKlientowDoKontaktu = ListaKlientow.OdczytajXML("ListaKlientówDoKontaktu.xml");

            ListaKlientowDoKontaktu.DodajKlienta(klient);

            ListaKlientowDoKontaktu.ZapiszXML("ListaKlientówDoKontaktu");
            //this.Close();
        }

    }
}
