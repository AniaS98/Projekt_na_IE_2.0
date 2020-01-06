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
    /// Logika interakcji dla klasy KontaktWindow.xaml
    /// </summary>
    public partial class KontaktWindow : Window
    {
        Klient klient;
        public KontaktWindow(Klient klient)
        {
            this.klient = klient;
            InitializeComponent();
            TextBox_Imie.Text = klient.Imie;
            TextBox_Nazwisko.Text = klient.Nazwisko;
            TextBox_Telefon.Text = klient.NumerTelefonu;
        }

        private void Akceptuj_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
