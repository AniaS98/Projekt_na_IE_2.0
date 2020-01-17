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
    /// Logika interakcji dla klasy KlientWindow.xaml
    /// </summary>
    public partial class KlientWindow : Window
    {
        bool decyzja = false;//false tzn. indywidualny

        //public bool decyzja;
        PakietKoncowy pk;
        Klient klient;
        Zamowienie z;
        public KlientWindow()
        {
            klient = new Klient();
            z = new Zamowienie();
            klient.historia.Add(z);
            InitializeComponent();

            //Testowanie
            //ListaKlientow lk = ListaKlientow.OdczytajXML("ListaKlientówDoKontaktu.xml");
            //Console.WriteLine(lk.klienci[0].ToString());

        }

        private void Cofnij_Click(object sender, RoutedEventArgs e)
        {
            MainWindow okno = new MainWindow();
            this.Close();
            okno.ShowDialog();
        }


        public void Rodzinny_Click(object sender, RoutedEventArgs e)
        {
            decyzja = true;
            PakietWindow okno = new PakietWindow(klient, decyzja, z);//jeżeli decyzja jest true to jest to pakiet rodzinny i trzeba będzie go tak przekazywać aż do okna w którym będzie trzeba wybrać którą funkcję wczytać z klas
            this.Close();
            okno.ShowDialog();
            
        }

        public void Indywidualny_Click(object sender, RoutedEventArgs e)
        {
            PakietWindow okno = new PakietWindow(klient, decyzja, z);//jeżeli decyzja jest false to jest to pakiet indywidualny i trzeba będzie go tak przekazywać aż do okna w którym będzie trzeba wybrać którą funkcję wczytać z klas
            this.Close();
            okno.ShowDialog();

        }
    }
}
