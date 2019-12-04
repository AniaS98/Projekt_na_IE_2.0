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
        //public bool decyzja;
        public KlientWindow()
        {
            InitializeComponent();
        }

        private void Cofnij_Click(object sender, RoutedEventArgs e)
        {
            MainWindow okno = new MainWindow();
            this.Close();
            okno.ShowDialog();
        }
        
        private void Rodzinny_Click(object sender, RoutedEventArgs e)
        {
            
            //decyzja = true;

            PakietWindow okno = new PakietWindow();//jeżeli decyzja jest true to jest to pakiet rodzinny i trzeba będzie go tak przekazywać aż do okna w którym będzie trzeba wybrać którą funkcję wczytać z klas
            this.Close();
            okno.ShowDialog();
            
        }

        private void Indywidualny_Click(object sender, RoutedEventArgs e)
        {
            //decyzja = false;

            PakietWindow okno = new PakietWindow();//jeżeli decyzja jest false to jest to pakiet indywidualny i trzeba będzie go tak przekazywać aż do okna w którym będzie trzeba wybrać którą funkcję wczytać z klas
            this.Close();
            okno.ShowDialog();

        }
    }
}
