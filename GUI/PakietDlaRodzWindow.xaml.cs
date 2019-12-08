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
using System.Web.UI.DataVisualization;
using System.Web.UI.WebControls;
using ProjektUbezpieczenia;


namespace GUI
{
    /// <summary>
    /// Logika interakcji dla klasy PakietWindow.xaml
    /// </summary>
    public partial class PakietDlaRodzWindow : Window
    {
        Klient klient;
        public PakietDlaRodzWindow(Klient klient)
        { 
            InitializeComponent();
            this.klient = klient;
        }

        private void Powrot_Click(object sender, RoutedEventArgs e)
        {
            KlientWindow okno = new KlientWindow();
            this.Close();
            okno.ShowDialog();

        }

        private void Dalej_Click(object sender, RoutedEventArgs e)
        {
            if (ComboBox_Plec.Text == "" || TextBox_Wiek.Text == "" || ComboBox_Zawod.Text == "")
            {
                MessageBox.Show("Uzupełnij wszystkie dane!!!");
                return;
            }

            Plcie plec;
            if (ComboBox_Plec.Text == "kobieta")
                plec = Plcie.K;
            else
                plec = Plcie.M;

            Zawody zawod;
            if (ComboBox_Zawod.Text == "Górnik")
                zawod = Zawody.gornik;
            if (ComboBox_Zawod.Text == "Żołnierz")
                zawod = Zawody.zolnierz;
            if (ComboBox_Zawod.Text == "Rybak")
                zawod = Zawody.rybak;
            if (ComboBox_Zawod.Text == "Pilot samolotu")
                zawod = Zawody.pilot_samolotu;
            if (ComboBox_Zawod.Text == "Policjant")
                zawod = Zawody.policjant;
            if (ComboBox_Zawod.Text == "Strażak")
                zawod = Zawody.strazak;
            if (ComboBox_Zawod.Text == "Budowlaniec")
                zawod = Zawody.budowlaniec;
            if (ComboBox_Zawod.Text == "Pracownik przemysłu ciężkiego")
                zawod = Zawody.pracownik_przemysłu_ciezkiego;
            if (ComboBox_Zawod.Text == "Osoba pracująca na wysokościach")
                zawod = Zawody.osoba_pracujaca_na_wysokosci;
            if (ComboBox_Zawod.Text == "Pracownik biurowy")
                zawod = Zawody.pracownik_biurowy;
            if (ComboBox_Zawod.Text == "Nauczyciel")
                zawod = Zawody.nauczyciel;
            if (ComboBox_Zawod.Text == "Lekarz")
                zawod = Zawody.lekarz;
            if (ComboBox_Zawod.Text == "Prawnik")
                zawod = Zawody.prawnik;
            if (ComboBox_Zawod.Text == "Student")
                zawod = Zawody.student;
            else
                zawod = Zawody.bezrobotny;


            int czas = Convert.ToInt32(this.TextBox_Czas.Text);
            klient = new Klient(Convert.ToInt32(this.TextBox_Wiek.Text), plec, zawod);

            RodzinnyWindow okno = new RodzinnyWindow(klient);
            this.Close();
            okno.ShowDialog();

        }

        private void Hobby_Click(object sender, RoutedEventArgs e)
        {
            HobbyWindow okno = new HobbyWindow(klient);
            okno.ShowDialog();
        }

        private void Choroby_Click(object sender, RoutedEventArgs e)
        {
            ChorobyWindow okno = new ChorobyWindow(klient);
            okno.ShowDialog();
        }
    }
}
