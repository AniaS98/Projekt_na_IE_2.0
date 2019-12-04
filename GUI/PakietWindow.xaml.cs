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
    /// Logika interakcji dla klasy PakietWindow.xaml
    /// </summary>
    public partial class PakietWindow : Window
    {
        Klient klient;
        public PakietWindow()
        {
            klient = new Klient();
            InitializeComponent();
        }

        private void Powrot_Click(object sender, RoutedEventArgs e)
        {
            KlientWindow okno = new KlientWindow();
            this.Close();
            okno.ShowDialog();

        }

        private void Dalej_Click(object sender, RoutedEventArgs e)
        {
            if (ComboBox_Plec.Text == "" || ComboBox_Zawod.Text == "" || TextBox_Wiek.Text == "")
            {
                MessageBox.Show("Uzupełnij wszystkie dane!!!");
                return;
            }
            Choroby choroba;
            List<Pasje> hobbies;
            Plcie plec;
            if (ComboBox_Plec.Text == "kobieta")
                plec = Plcie.K;
            else
                plec = Plcie.M;
            /*
            RodzinnyWindow okno = new RodzinnyWindow();
            this.Close();
            okno.ShowDialog();
            */
        }

        public PakietWindow(Klient klient) : this()
        {
            this.klient = klient;
            //TextBox_Wiek.Text = klient.Wiek;
            if (klient.Plec == Plcie.K)
                ComboBox_Plec.Text = "kobieta";
            else
                ComboBox_Plec.Text = "mężczyzna";
        }

    }
}
