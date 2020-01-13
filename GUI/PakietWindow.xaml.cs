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
    public partial class PakietWindow : Window
    {
        List<Choroby> chorobies = new List<Choroby>();
        List<Pasje> hobbies = new List<Pasje>();

        bool decyzja = false;
        Klient klient;
        Zamowienie zamowienie;

        public PakietWindow()
        {
            InitializeComponent();
        }

        private void Powrot_Click(object sender, RoutedEventArgs e)
        {
            KlientWindow okno = new KlientWindow();
            this.Close();
            okno.ShowDialog();

        }
        public PakietWindow(Klient klient, bool de, Zamowienie z) : this()
        {
            zamowienie = z;
            decyzja = de;
            this.klient = klient;
            //klient.Wiek = Convert.ToInt32(TextBox_Wiek.Text);

            if ((klient.Plec) == Plcie.K)
                ComboBox_Plec.Text = "kobieta";
            else if ((klient.Plec) == Plcie.M)
                ComboBox_Plec.Text = "mężczyzna";

            if (klient.Zawod == Zawody.gornik)
                ComboBox_Zawod.Text = "Górnik";
            if (klient.Zawod == Zawody.zolnierz)
                ComboBox_Zawod.Text = "Żołnierz";
            if (klient.Zawod == Zawody.rybak)
                ComboBox_Zawod.Text = "Rybak";
            if (klient.Zawod == Zawody.pilot_samolotu)
                ComboBox_Zawod.Text = "Pilot samolotu";
            if (klient.Zawod == Zawody.policjant)
                ComboBox_Zawod.Text = "Policjant";
            if (klient.Zawod == Zawody.strazak)
                ComboBox_Zawod.Text = "Strażak";
            if (klient.Zawod == Zawody.budowlaniec)
                ComboBox_Zawod.Text = "Budowlaniec";
            if (klient.Zawod == Zawody.pracownik_przemysłu_ciezkiego)
                ComboBox_Zawod.Text = "Pracownik przemysłu ciężkiego";
            if (klient.Zawod == Zawody.osoba_pracujaca_na_wysokosci)
                ComboBox_Zawod.Text = "Osoba pracująca na wysokościach";
            if (klient.Zawod == Zawody.pracownik_biurowy)
                ComboBox_Zawod.Text = "Pracownik biurowy";
            if (klient.Zawod == Zawody.nauczyciel)
                ComboBox_Zawod.Text = "Nauczyciel";
            if (klient.Zawod == Zawody.lekarz)
                ComboBox_Zawod.Text = "Lekarz";
            if (klient.Zawod == Zawody.prawnik)
                ComboBox_Zawod.Text = "Prawnik";
            if (klient.Zawod == Zawody.student)
                ComboBox_Zawod.Text = "Student";
            else if (klient.Zawod == Zawody.bezrobotny)
                ComboBox_Zawod.Text = "Bezrobotny";

            int l = klient.historia.Count;

            if (ComboBox_Typ.Text == "miesięczna")
            {
                z.PakietKoncowy.Podzialskl = 12;
            }
            else if (ComboBox_Typ.Text == "roczna")
            {
                z.PakietKoncowy.Podzialskl = 1;
            }

        }

        public void Dalej_Click(object sender, RoutedEventArgs e)
        {
            if (ComboBox_Plec.Text == "" || TextBox_Wiek.Text == "" || ComboBox_Zawod.Text == "")
            {
                MessageBox.Show("Uzupełnij wszystkie dane!!!");
                return;
            }

            if (ComboBox_Plec.Text == "kobieta")
                klient.Plec = Plcie.K;
            else if (ComboBox_Plec.Text == "mężczyzna")
                klient.Plec = Plcie.M;

            if (ComboBox_Zawod.Text == "Górnik")
                klient.Zawod = Zawody.gornik;
            if (ComboBox_Zawod.Text == "Żołnierz")
                klient.Zawod = Zawody.zolnierz;
            if (ComboBox_Zawod.Text == "Rybak")
                klient.Zawod = Zawody.rybak;
            if (ComboBox_Zawod.Text == "Pilot samolotu")
                klient.Zawod = Zawody.pilot_samolotu;
            if (ComboBox_Zawod.Text == "Policjant")
                klient.Zawod = Zawody.policjant;
            if (ComboBox_Zawod.Text == "Strażak")
                klient.Zawod = Zawody.strazak;
            if (ComboBox_Zawod.Text == "Budowlaniec")
                klient.Zawod = Zawody.budowlaniec;
            if (ComboBox_Zawod.Text == "Pracownik przemysłu ciężkiego")
                klient.Zawod = Zawody.pracownik_przemysłu_ciezkiego;
            if (ComboBox_Zawod.Text == "Osoba pracująca na wysokościach")
                klient.Zawod = Zawody.osoba_pracujaca_na_wysokosci;
            if (ComboBox_Zawod.Text == "Pracownik biurowy")
                klient.Zawod = Zawody.pracownik_biurowy;
            if (ComboBox_Zawod.Text == "Nauczyciel")
                klient.Zawod = Zawody.nauczyciel;
            if (ComboBox_Zawod.Text == "Lekarz")
                klient.Zawod = Zawody.lekarz;
            if (ComboBox_Zawod.Text == "Prawnik")
                klient.Zawod = Zawody.prawnik;
            if (ComboBox_Zawod.Text == "Student")
                klient.Zawod = Zawody.student;
            else if (ComboBox_Zawod.Text == "bezrobotny")
                klient.Zawod = Zawody.bezrobotny;

            int l = klient.historia.Count;

            klient.Wiek = Convert.ToInt32(TextBox_Wiek.Text);

            if (ComboBox_Typ.Text == "miesięczna")
            {
                zamowienie.PakietKoncowy.Podzialskl = 12;
            }
            else if (ComboBox_Typ.Text == "roczna")
            {
                zamowienie.PakietKoncowy.Podzialskl = 1;
            }

            int czas = Convert.ToInt32(TextBox_Czas.Text);


            if (Convert.ToInt32(TextBox_Wiek.Text) >= 18)
            {
                if (decyzja == true)
                {
                    RodzinnyWindow okno = new RodzinnyWindow(klient, decyzja, czas, zamowienie, 0);
                    this.Close();
                    okno.ShowDialog();
                }
                else
                {
                    Klient2Window okno1 = new Klient2Window(klient, decyzja, czas);
                    this.Close();
                    okno1.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Ubezpieczający nie może być młodszy niż 18 lat");
            }

            if (klient.Hobbies == null)
                klient.Hobbies = new List<Pasje>();
            if (klient.Chorobies == null)
                klient.Chorobies = new List<Choroby>();

            //Console.WriteLine(klient.ToString());
            //Console.WriteLine(zamowienie.PakietKoncowy.Podzialskl.ToString());


        }

        public void Hobby_Click(object sender, RoutedEventArgs e)
        {
            HobbyWindow okno = new HobbyWindow(klient, decyzja, zamowienie);
            okno.ShowDialog();
        }

        public void Choroby_Click(object sender, RoutedEventArgs e)
        {
            ChorobyWindow okno = new ChorobyWindow(klient, decyzja, zamowienie);
            okno.ShowDialog();
        }
    }
}