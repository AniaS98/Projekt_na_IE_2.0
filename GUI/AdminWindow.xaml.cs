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
    /// Logika interakcji dla klasy AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        public AdminWindow()
        {
            InitializeComponent();
        }

        private void Button_ListaKlientow_Click(object sender, RoutedEventArgs e)
        {
           BazaDanych okno = new BazaDanych ("D:\\!!!_PULPET_D\\Studia\\V semestr\\IE\\Klienci_dane.xls");
           this.Close();
           okno.ShowDialog();
        }

        private void Button_ListaAgentow_Click(object sender, RoutedEventArgs e)
        {
            Dane_przedstawiciele okno = new Dane_przedstawiciele("D:\\!!!_PULPET_D\\Studia\\V semestr\\IE\\DanePrzedstawiciele.xls");
            this.Close();
            okno.ShowDialog();
        }

        private void Cofnij_Click(object sender, RoutedEventArgs e)
        {
            MainWindow okno = new MainWindow();
            this.Close();
            okno.ShowDialog();
        }
    }
}
