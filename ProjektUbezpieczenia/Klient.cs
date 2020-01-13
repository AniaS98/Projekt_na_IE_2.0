using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;
using System.Text;
using System.Data.OleDb;
using System.Data;

namespace ProjektUbezpieczenia
{
    [Serializable]
    public enum Plcie
    {
        M, K
    }

    [Serializable]
    public enum Zawody
    {
        gornik,
        zolnierz,
        rybak,
        pilot_samolotu,
        policjant,
        strazak,
        budowlaniec,
        pracownik_przemysłu_ciezkiego,
        osoba_pracujaca_na_wysokosci,
        pracownik_biurowy,
        nauczyciel,
        lekarz,
        prawnik,
        student,
        bezrobotny
    }

    [Serializable]
    public enum Pasje
    {
        sporty_ekstremalne,
        wspinaczka_gorska,
        rower,
        hobby_artystyczne,
        hobby_techniczne,
        ksiazki,
        gry_komputerowe,
        sporty_zimowe,
        podrozowanie,
        rekonstrukcje_historyczne,
        jazda_konna,
        sporty_wodne,
        sporty_druzynowe,
        lekkoatletyka
    }

    public enum Choroby
    {
        brak,
        nowotwory,
        stwardnienie_rozsiane,
        choroby_ukladu_krazenia,
        choroby_wiencowe,
        epilepsja,
        cukrzyca,
        astma,
        nadcisnienie,
        silne_alergie,
        przewlekle_choroby_ukladu_oddechowego,
        choroba_Alzheimera,
        zespol_Parkinsona,
        osteoporoza,
        niedoczynnosc_tarczycy
    }

    [Serializable]
    public class Klient : Osoba
    {
        string PESEL;
        int wiek;
        Plcie plec;
        string numerTelefonu;
        bool malzonek;
        public List<CzlonekRodziny> rodzina=new List<CzlonekRodziny>();
        Zawody zawod;
        Pasje hobby;
        public List<Zamowienie> historia = new List<Zamowienie>();
        Choroby choroba;
        List<Choroby> chorobies = new List<Choroby>();
        List<Pasje> hobbies =new List<Pasje>();


        /*
        public string PESEL1
        {
            get
            {
                return PESEL;
            }

            set
            {
                if (value.Length != 11)
                {
                    Console.WriteLine("Niepoprawna długość numeru PESEL!");
                    throw new WrongPESELException();
                }
                PESEL = value;
            }
        }
        */

        public string PESEL1 { get => PESEL; set => PESEL = value; }
        public int Wiek { get => wiek; set => wiek = value; }
        public Plcie Plec { get => plec; set => plec = value; }
        public string NumerTelefonu { get => numerTelefonu; set => numerTelefonu = value; }
        public bool Malzonek { get => malzonek; set => malzonek = value; }
        public Zawody Zawod { get => zawod; set => zawod = value; }
        public Pasje Hobby { get => hobby; set => hobby = value; }//Same jak z chorobami
        public List<Zamowienie> Historia { get => historia; set => historia = value; }
        public List<CzlonekRodziny> Rodzina { get => rodzina; set => rodzina = value; }
        public Choroby Choroba { get => choroba; set => choroba = value; } //Nie wiem, czy to jest w sumie potrzebne, ale na wszelki wypdaek to zostawiam
        public List<Choroby> Chorobies { get => chorobies; set => chorobies = value; }
        public List<Pasje> Hobbies { get => hobbies; set => hobbies = value; }

        public Klient()
        {
            PESEL = "00000000000";
            wiek = 0;
            numerTelefonu = new string('0', 9);
            malzonek = false;
            rodzina = new List<CzlonekRodziny>();
            historia = new List<Zamowienie>();
            chorobies = new List<Choroby>();
            hobbies = new List<Pasje>();
            zawod = new Zawody();
        }

        public Klient(int wiek, Plcie plec, Zawody zawod)
        {
            this.wiek = wiek;
            this.plec = plec;
            this.zawod = zawod;
        }


        public Klient(string imie, string nazwisko, string PESEL, int wiek, Plcie plec, string numerTelefonu, bool malzonek, Zawody zawod) : base(imie, nazwisko)
        {
            this.PESEL = PESEL;
            this.wiek = wiek;
            this.plec = plec;
            this.numerTelefonu = numerTelefonu;
            this.malzonek = malzonek;
            this.zawod = zawod;
        }

        public void DodajCzlonkaRodziny(CzlonekRodziny c)
        {
            rodzina.Add(c);
        }

        public void UsunCzlonkaRodziny(string imie)
        {
            foreach (CzlonekRodziny i in rodzina)
            {
                if (i.Imie == imie)
                {
                    rodzina.Remove(i);
                    return;
                }
            }
        }

        public void DodajZamowienie(Zamowienie z)
        {
            historia.Add(z);
        }

        public void UsunZamowienie(int id)
        {
            foreach (Zamowienie i in historia)
            {
                if (i.Id == id)
                {
                    historia.Remove(i);
                    return;
                }
            }
        }

        public void DodajChorobe(Choroby c)
        {
            chorobies.Add(c);
        }

        public void UsunChorobe(Choroby c)
        {
            foreach (Choroby i in chorobies)
            {
                if (i == c)
                {
                    chorobies.Remove(i);
                    return;
                }
            }
        }

        public void DodajHobby(Pasje h)
        {
            hobbies.Add(h);
        }

        public void UsunHobby(Pasje c)
        {
            foreach (Pasje i in hobbies)
            {
                if (i == c)
                {
                    hobbies.Remove(i);
                    return;
                }
            }
        }

        public void DodajZamowienie(CzlonekRodziny c)
        {
            rodzina.Add(c);
        }


        public override string ToString()
        { 
            string s = Imie + " " + Nazwisko + " " + PESEL + " " + Wiek + " " + Plec + " " + NumerTelefonu + " " + Malzonek + " " + Zawod;
            if(rodzina!=null)
            {
                foreach (CzlonekRodziny i in rodzina)
                {
                    s = s + "\n" + i.ToString();
                }
            }
            foreach (Pasje i in hobbies)
            {
                s = s + " " + i;
            }
            s = s + "\n";
            foreach (Choroby i in chorobies)
            {
                s = s + " " + i;
            }
            s = s + "\n";

            return s;
        }

        //+++++++++++++++++++++++++++++
        double Skl_Dzieci = 0;
        double Skl_Dorosli = 55.0;
        String[] pakietyOdp = new string[7];
        double[] pakietySum = new double[7];
        double[] pakietyCzas = new double[7];
        int czasdodatkowych = 0;
        double skladkaMiesieczna = 0;
        double skladkaKoncowa = 0;

        public void ZapisKlientaDoXLSX(Klient k)
        {
            string plik = "DaneDoTestów";
            string PathConn = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + plik + "; Extended Properties=\"Excel 8.0;HDR=Yes;\";";
            OleDbConnection conn = new OleDbConnection(PathConn);
            OleDbDataAdapter myDataAdapter = new OleDbDataAdapter("Select * from [Arkusz1$]", conn);
            OleDbCommandBuilder builder = new OleDbCommandBuilder(myDataAdapter);
            DataTable table = new DataTable();
            DataRow dr;
            myDataAdapter.Fill(table);

            Skl_Dzieci = 0;
            Skl_Dorosli = 55.0;
            pakietyOdp = new string[7];
            pakietySum = new double[7];
            pakietyCzas = new double[7];
            czasdodatkowych = 0;
            skladkaMiesieczna = 0;
            skladkaKoncowa = 0;


            List<double> pomocnik1= new List<double>();
            List<double> pomocnik2 = new List<double>();
            int ldzieci = 0;
            int dzieci_5 = 0;
            int dzieci_12 = 0;
            int dzieci_18 = 0;
            int lUbezpieczonych = 1;
            int ldorosli = 1;
            double DorosliZnizka = 0;
            double DodatkiSum = 0;
            double[] pakietyZnizki = new double[7];
            int id=0;

            String typ = "Roczna";

            for (int i = 0; i < 7; i++)
                pakietyOdp[i] = "Nie";
            /*
            foreach(PakietDodatkowy pd in k.Historia[k.historia.Count - 1].PakietKoncowy.Dodatkowe)
            {
                if (pd.Nazwa == Edodat.SportyEkstremalne.ToString())
                    pakietyOdp[0] = "Tak";
                else if (pd.Nazwa == Edodat.Onkolog.ToString())
                    pakietyOdp[1] = "Tak";
                else if (pd.Nazwa == Edodat.Ortopeda.ToString())
                    pakietyOdp[2] = "Tak";
                else if (pd.Nazwa == Edodat.PowazneZachorowanieDziecka.ToString())
                    pakietyOdp[3] = "Tak";
                else if (pd.Nazwa == Edodat.Niezdolnosc.ToString())
                    pakietyOdp[4] = "Tak";
                else if (pd.Nazwa == Edodat.SmiercWK.ToString())
                    pakietyOdp[5] = "Tak";
                else if (pd.Nazwa == Edodat.smiercNW.ToString())
                    pakietyOdp[6] = "Tak";
            }*/
            if (rodzina != null)
            {
                pomocnik2= PakietRodzinny(k.Historia[k.historia.Count - 1].PakietKoncowy.Lata, k);
                lUbezpieczonych += k.rodzina.Count;
                if (malzonek == false)
                    ldzieci = k.rodzina.Count;
                else
                {
                    ldzieci = k.rodzina.Count - 1;
                    ldorosli++;
                    DorosliZnizka = 5.5;
                }
                foreach (CzlonekRodziny cr in k.Rodzina)
                {
                    if (cr.Wiek < 6)
                    {
                        dzieci_5++;
                    }
                    if (cr.Wiek < 13)
                    {
                        dzieci_12++;
                    }
                    if (cr.Wiek < 19)
                    {
                        dzieci_18++;
                    }
                }
            }
            else
                pomocnik1=PakietPodstawowyIndywiduany(k.Historia[k.historia.Count - 1].PakietKoncowy.Lata, k);

            FunkcjaPakietDodatkowy(k.Historia[k.historia.Count - 1].PakietKoncowy.Lata, k, ldorosli,1);

            if (k.Historia[k.historia.Count - 1].PakietKoncowy.Podzialskl == 12)
                typ = "Miesięczna";

            dr = table.NewRow();
            dr[1] = k.Imie;
            dr[2] = k.Nazwisko;
            dr[3] = k.Wiek;
            dr[4]=k.Plec;
            dr[5] = ldzieci;
            dr[6] = dzieci_5;
            dr[7] = dzieci_12;
            dr[8] = dzieci_18;
            dr[9] = ldorosli;
            dr[10] = lUbezpieczonych;
            for (int i = 0; i < 7; i++)
                dr[11+i]=pakietyOdp[1];
            dr[18] = typ;
            dr[19] = Skl_Dzieci;
            dr[20] = Skl_Dorosli;
            dr[21] = k.Historia[k.historia.Count - 1].PakietKoncowy.Lata;
            dr[22] = (Skl_Dorosli + Skl_Dzieci);
            dr[23] = DorosliZnizka;
            dr[24] = (Skl_Dorosli + Skl_Dzieci-DorosliZnizka);
            for (int i = 0; i < 7; i++)
            {
                dr[25+i] = pakietySum[i];
                DodatkiSum += pakietySum[i];
            }
            dr[33] = DodatkiSum;
            for (int i = 0; i < 7; i++)
            {
                pakietyCzas[i] = pakietySum[i] * k.Historia[k.historia.Count - 1].PakietKoncowy.Lata;
                dr[34+i] = pakietyCzas[i];
                if (czasdodatkowych > 5)
                    pakietyZnizki[i] = pakietySum[i] * 0.2 * (czasdodatkowych - 5) + pakietySum[i];
                else
                    pakietyZnizki[i]= pakietySum[i];
            }
            for (int i = 0; i < 7; i++)
            {
                dr[42+i] = pakietyZnizki[i];

            }
            dr[50] = skladkaMiesieczna;
            dr[51] = skladkaKoncowa;
            ListaAgentow LA = ListaAgentow.OdczytajXML("ListaAgentow.xml");
            foreach(Agent a in LA.Agenci)
            {
                if (a.Lista_klientow.Klienci.Contains(k))
                    id = a.idAgenta;
            }
            dr[52] = id;
            DataRow[] dataRows = new DataRow[1];
            dataRows[0] = dr;
            myDataAdapter.UpdateCommand = builder.GetUpdateCommand();
            myDataAdapter.Update(dataRows);

            //File.WriteAllText("TestyKlientow.csv", csv.ToString());
        }



        /// <summary>
        /// Funkcja, która zwraca listę pakietów dodatkowych oraz oblicza składkę ubezpieczenia za dodatkowe pakiety
        /// WEJŚCIE: Klient oraz czas ubezpieczenia
        /// Zawsze brane są pod uwagę pakiety dotyczące śmierci, a reszta jest podyktowana zawodem lub pasją
        /// W warunkach dodawane są pakiety dodatkowe
        /// W funkcji po raz pierwszy wspomniane będą takie klasy jak PakietKoncowy, PakietDodatkowy oraz Zamówienie, dlatego tu obiekty te zostaną stworzone oraz przypisane klientowi za pomocą argumentu historia.
        /// WYJŚCIE: przekazane przez referencje zamówienie
        /// </summary>
        public void FunkcjaPakietDodatkowy(int czas, Klient k, int LiczbaUbezpieczonych,int podzial)
        {
            czasdodatkowych = czas;
            //to SAMO ZE SKLADKA, BO NA RAZIE NIE MA POWIAZANIA Z RODZAJEM UBEZPIECZENIA
            int l = k.historia.Count;
            k.DodajZamowienie(new Zamowienie());
            PakietKoncowy pk = new PakietKoncowy(0, k.historia[l].PakietKoncowy.Skladka, 0, 0, 0,czas);
            PakietDodatkowy pd = new PakietDodatkowy();
            double wskladka = 0.0;

            //PakietDodatkowy(string nazwa, double koszt, int idd, int lata, double skladka)

            if (k.Hobbies.Contains(Pasje.sporty_ekstremalne))
            {
                pakietyOdp[0] = "Tak";
                pakietySum[0] = 5.0* LiczbaUbezpieczonych;
                pd = new PakietDodatkowy(Edodat.SportyEkstremalne.ToString(), 5000.0, 1, 5, 60.0* LiczbaUbezpieczonych);
                pk.DodajPakiet2(pd);
                wskladka += 60.0;
                Console.WriteLine(1);
            }
            

            //górnik (rak płuc, oskrzeli, itp), pilot (promieniowanie kosmiczne)
            if (k.Chorobies.Contains(Choroby.nowotwory) || k.Zawod == Zawody.gornik || k.Zawod == Zawody.pilot_samolotu)
            {
                pakietyOdp[1] = "Tak";
                pakietySum[1] = 10.0 * LiczbaUbezpieczonych;
                pd = new PakietDodatkowy(Edodat.Onkolog.ToString(), 20000.0, 2, 5, 120.0* LiczbaUbezpieczonych);
                pk.DodajPakiet2(pd);
                wskladka += 120.0;
                Console.WriteLine(2);
            }

            if (k.Chorobies.Contains(Choroby.osteoporoza) || k.Wiek > 60 || k.Hobbies.Contains(Pasje.wspinaczka_gorska) || k.Hobbies.Contains(Pasje.rower) || k.Hobbies.Contains(Pasje.sporty_zimowe) || k.Hobbies.Contains(Pasje.lekkoatletyka))
            {
                pakietyOdp[2] = "Tak";
                pakietySum[2] = 8.0 * LiczbaUbezpieczonych;
                pd = new PakietDodatkowy(Edodat.Ortopeda.ToString(), 10000.0, 3, 5, 96.0 * LiczbaUbezpieczonych);
                pk.DodajPakiet2(pd);
                wskladka += 96.0;
                Console.WriteLine(3);
            }
            if ((k.malzonek==false && k.Rodzina.Count!=0) || (k.malzonek == true && k.Rodzina.Count != 1))
            {
                pakietyOdp[3] = "Tak";
                pakietySum[3] = 10.0 * LiczbaUbezpieczonych;
                pd = new PakietDodatkowy(Edodat.PowazneZachorowanieDziecka.ToString(), 20000.0, 4, 5, 120.0 * LiczbaUbezpieczonych);
                pk.DodajPakiet2(pd);
                wskladka += 120.0;
                Console.WriteLine(4);
            }
            if (k.Zawod == Zawody.gornik || k.Zawod == Zawody.zolnierz || k.Zawod == Zawody.rybak || k.Zawod == Zawody.pilot_samolotu || k.Zawod == Zawody.policjant || k.Zawod == Zawody.strazak || k.Zawod == Zawody.budowlaniec || k.Zawod == Zawody.pracownik_przemysłu_ciezkiego || k.Zawod == Zawody.osoba_pracujaca_na_wysokosci || k.Zawod == Zawody.lekarz)
            {
                pakietyOdp[4] = "Tak";
                pakietySum[4] = 10.0 * LiczbaUbezpieczonych;
                pd = new PakietDodatkowy(Edodat.Niezdolnosc.ToString(), 50000.0, 5, 5, 120.0 * LiczbaUbezpieczonych);
                pk.DodajPakiet2(pd);
                wskladka += 120.0;
                Console.WriteLine(5);
            }
            //W proponowanych zawsze będą Śmierci, chyba że wymyślimy jakieś warunki :D
            pd = new PakietDodatkowy(Edodat.SmiercWK.ToString(), 100000.0, 6, 5, 60.0 * LiczbaUbezpieczonych);
            pk.DodajPakiet2(pd);
            wskladka += 60.0;
            pakietyOdp[5] = "Tak";
            pakietySum[5] = 5.0 * LiczbaUbezpieczonych;
            Console.WriteLine(6);

            pd = new PakietDodatkowy(Edodat.smiercNW.ToString(), 50000.0, 7, 5, 144.0 * LiczbaUbezpieczonych);
            pk.DodajPakiet2(pd);
            wskladka += 144.0;
            pakietyOdp[6] = "Tak";
            pakietySum[6] = 12.0 * LiczbaUbezpieczonych;
            Console.WriteLine(7);

            Console.WriteLine("Pakiety Dodatkowe - składka roczna {0}", wskladka);


            if (czas > 5)
            {
                double roznica = (double)czas-5.0;
                wskladka = ((wskladka * roznica * 0.2) / roznica) + wskladka;
            }

            if (podzial == 12)
            {
                wskladka = wskladka / 12;
                Console.WriteLine("Pakiety Dodatkowe - składka miesięczna {0}", wskladka);
            }     
            pk.Skladka += wskladka;




            Zamowienie z = new Zamowienie(false, l, pk);
            z.PakietKoncowy.Skladka = wskladka;

            k.DodajZamowienie(z);
            z.ZapiszXML();
        }

        List<double> results = new List<double>();

        /// <summary>
        /// Funkcja obliczająca sładkę roczną/miesięczną dla indywidualnego ubezpieczenia
        /// WEJŚCIE: Klient oraz czas ubezpieczenia
        /// WYJŚCIE: składka roczna/miesięczna (podana przez odwołanie do pakietukoncowego)
        /// </summary>

        public List<double> PakietPodstawowyIndywiduany(int czas, Klient k)
        {
            int l = k.historia.Count-1;
            int podzial = k.historia[l].PakietKoncowy.Podzialskl;
            double wynik = 480.0;


            if (czas > 10)
            {
                double roznica = (double)czas - 5.0;
                wynik = ((wynik * roznica * 0.2) / roznica) + wynik;
                Console.WriteLine("Pakiet Indywidualny - składka roczna {0}", wynik);
            }

            //wynik = 480.0;
            if (wynik == 12)
                wynik = wynik / 12;
            k.historia[l].PakietKoncowy.Skladka += wynik;
            results.Add(wynik);//Składka
            results.Add(100000.0);//Suma

            return results;
        }


                                  

        /// <summary>
        /// Funkcja obliczająca sumę składek miesięcznych/rocznych dla pakietu rodzinnego
        /// WEJŚCIE: Klient oraz długość ubezpieczenia
        /// Na początku powstaje pętla dodająca do ogólnej składki opłaty za kolejne dzieci
        /// Potem wprowadzana jest zmienna, wskazującą na istnienie małżonka.
        /// Do obliczonej sumy dodane jest opłata za ubezpieczonego oraz za jej/jego małżonka
        /// Na końcu liczona jest skladka miesieczna/roczna
        /// WYJŚCIE: Suma składek przekazana przez referencje
        /// </summary>
        //PROMOCJE I PODZIAŁ
        public List<double> PakietRodzinny(int czas, Klient k)
        {
            double czyMalzonek = 0.0;
            int l = k.historia.Count-1;
            int podzial = k.historia[l].PakietKoncowy.Podzialskl; //te szalone odwołania XD

            double wskladka = 0.0;

            for (int d = 1; d < k.rodzina.Count; d++)
            {
                if (d == 0 && k.malzonek == true)
                    d++;

                if (k.rodzina[d].Wiek <= 5)
                {
                    wskladka += 15.0;
                    Skl_Dzieci += 15.0;
                }
                else if (k.rodzina[d].Wiek <= 12)
                {
                    Skl_Dzieci += 20.0;
                    wskladka += 20.0;
                }
                else
                {
                    Skl_Dzieci += 30.0;
                    wskladka += 30.0;
                }
            }
            results.Add(wskladka);

            results.Add(55.0);
            if (k.malzonek == true)
            {
                czyMalzonek = 1.0;
                results[1] += 55.0;
                Skl_Dorosli += 55.0;
            }
                

            if (podzial == 1)
            {
                wskladka = (wskladka * 12.0 + 660.0 + 660 * 0.9 * czyMalzonek) * 0.95;
            }
            else
            {

                wskladka = wskladka + 55.0 + 55.0 * 0.9 * czyMalzonek;
            }

            //Podział na długość ubezpieczenia
            if (czas > 10)
            {
                double roznica = (double)czas - 5.0;
                wskladka = ((wskladka * roznica * 0.2) / roznica) + wskladka;
            }
            if (podzial == 12)
                wskladka = wskladka / 12;

            k.historia[l].PakietKoncowy.KosztKoncowy += wskladka;


            return results;
        }


    }
}