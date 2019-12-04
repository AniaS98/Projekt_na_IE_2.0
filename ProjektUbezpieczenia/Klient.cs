using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;
using System.Text;

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
        public List<CzlonekRodziny> rodzina;
        Zawody zawod;
        Pasje hobby;
        public List<Zamowienie> historia = new List<Zamowienie>();
        Choroby choroba;
        List<Choroby> chorobies = new List<Choroby>();
        List<Pasje> hobbies;


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


        public Klient(string imie, string nazwisko, string PESEL, int wiek, Plcie plec, string numerTelefonu, bool malzonek, Zawody zawod, Pasje gry_komputerowe) : base(imie, nazwisko)
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
            string s = Imie + " " + Nazwisko + " " + PESEL + " " + Wiek + " " + Plec + " " + NumerTelefonu + " " + Malzonek + " " + Zawod + " " + Hobby + "\n";
            /*foreach (Osoba i in rodzina) 
            {
                s = s + "\n" + i;
            }
            foreach (Zamowienie i in Historia)
            {
                s = s + "\n" + i;
            }*/
            return s;
        }

        List<double> planSkladek = new List<double>();


        /// <summary>
        /// Funkcja, która zwraca listę pakietów dodatkowych oraz oblicza składkę roczną ubezpieczenia za dodatkowe pakiety
        /// WEJŚCIE: Klient oraz czas ubezpieczenia
        /// Zawsze brane są pod uwagę pakiety dotyczące śmierci, a reszta jest podyktowana zawodem lub pasją
        /// W warunkach dodawane są pakiety dodatkowe
        /// W funkcji po raz pierwszy wspomniane będą takie klasy jak PakietKoncowy, PakietDodatkowy oraz Zamówienie, dlatego tu obiekty te zostaną stworzone oraz przypisane klientowi za pomocą argumentu historia.
        /// 
        /// WYJŚCIE: przekazane przez referencje zamówienie, lista pokazująca plan składek
        /// </summary>

        //PakietKoncowy(int id, double znizka, double skladka, int podzialskl, double kosztKoncowy)
        public List<double> FunkcjaPakietDodatkowy(int czas, Klient k)
        {
            //to SAMO ZE SKLADKA, BO NA RAZIE NIE MA POWIAZANIA Z RODZAJEM UBEZPIECZENIA
            int l = k.historia.Count;
            k.DodajZamowienie(new Zamowienie());
            int podzial = k.historia[l].PakietKoncowy.Podzialskl;
            PakietKoncowy pk = new PakietKoncowy(0, k.historia[l].PakietKoncowy.Skladka, 0, 0, 0);
            PakietDodatkowy pd = new PakietDodatkowy();
            double wskladka = 0.0;

            //PakietDodatkowy(string nazwa, double koszt, int idd, int lata, double skladka)

            if (k.Hobby == Pasje.sporty_ekstremalne)
            {
                pd = new PakietDodatkowy(Edodat.SportyEkstremalne.ToString(), 5000.0, 1, 5, 60.0);
                pk.DodajPakiet2(pd);
                wskladka += 60.0;
            }

            //górnik (rak płuc, oskrzeli, itp), pilot (promieniowanie kosmiczne)
            if (k.Chorobies.Contains(Choroby.nowotwory) || k.Zawod == Zawody.gornik || k.Zawod == Zawody.pilot_samolotu)
            {
                pd = new PakietDodatkowy(Edodat.Onkolog.ToString(), 20000.0, 2, 5, 120.0);
                pk.DodajPakiet2(pd);
                wskladka += 120.0;
            }

            if (k.Chorobies.Contains(Choroby.osteoporoza) || k.Wiek > 60 || k.Hobby == Pasje.wspinaczka_gorska || k.Hobby == Pasje.rower || k.Hobby == Pasje.sporty_zimowe || k.Hobby == Pasje.lekkoatletyka)
            {
                pd = new PakietDodatkowy(Edodat.Ortopeda.ToString(), 10000.0, 3, 5, 96.0);
                pk.DodajPakiet2(pd);
                wskladka += 96.0;
            }
            if (k.Rodzina != null)
            {
                pd = new PakietDodatkowy(Edodat.PowazneZachorowanieDziecka.ToString(), 20000.0, 4, 5, 120.0);
                pk.DodajPakiet2(pd);
                wskladka += 120.0;
            }
            if (k.Zawod == Zawody.gornik || k.Zawod == Zawody.zolnierz || k.Zawod == Zawody.rybak || k.Zawod == Zawody.pilot_samolotu || k.Zawod == Zawody.policjant || k.Zawod == Zawody.strazak || k.Zawod == Zawody.budowlaniec || k.Zawod == Zawody.pracownik_przemysłu_ciezkiego || k.Zawod == Zawody.osoba_pracujaca_na_wysokosci || k.Zawod == Zawody.lekarz)
            {
                pd = new PakietDodatkowy(Edodat.Niezdolnosc.ToString(), 50000.0, 5, 5, 120.0);
                pk.DodajPakiet2(pd);
                wskladka += 120.0;
            }
            //W proponowanych zawsze będą Śmierci, chyba że wymyślimy jakieś warunki :D
            pd = new PakietDodatkowy(Edodat.SmiercWK.ToString(), 100000.0, 6, 5, 60.0);
            pk.DodajPakiet2(pd);
            wskladka += 60.0;

            pd = new PakietDodatkowy(Edodat.smiercNW.ToString(), 50000.0, 7, 5, 144.0);
            pk.DodajPakiet2(pd);
            wskladka += 144.0;

            if (podzial == 12)
                wskladka = wskladka / 12;
            pk.Skladka = wskladka;

            if (czas > 10)
            {
                if (podzial == 12)
                    wskladka = wskladka / 12;
                int len = planSkladek.Count;
                for (int licznik = 0; licznik <= len; licznik++)
                {
                    if (czas > 10)
                        planSkladek[licznik] += wskladka * 0.2;
                    else
                        planSkladek[licznik] += wskladka;

                    licznik++;
                }
            }

            Zamowienie z = new Zamowienie(false, l, pk);
            k.DodajZamowienie(z);
            z.ZapiszXML();

            return planSkladek;
        }

        /// <summary>
        /// Funkcja obliczająca sładkę roczną/miesięczną dla indywidualnego ubezpieczenia oraz plan przyszłych składek
        /// WEJŚCIE: Klient oraz czas ubezpieczenia
        /// WYJŚCIE: składka roczna/miesięczna (podana przez odwołanie do pakietukoncowego) oraz lista zawierajaca plan składek (wynik funkcji)
        /// </summary>
        //Justyna, tutaj trzeba dać jakiś warunek w GUI, żeby się wyświetlał teskt: 
        //"Plan ubezpieczenia dla składek rocznych: (roczny koszt)" i tu wypisana ta lista planSkladek, albo
        //"Plan ubezpieczenia dla składek miesięcznych: (miesięczny koszt)" i tu znowu ta lista planSkladek
        public List<double> PakietPodstawowyIndywiduany(int czas, Klient k)
        {
            int l = k.historia.Count;
            int podzial = k.historia[l].PakietKoncowy.Podzialskl;
            double wynik = 480.0;


            if (czas > 10)
            {
                for (int i = 1; i <= 10; i++)
                {
                    if (podzial == 1)
                        planSkladek.Add(wynik);
                    else
                        planSkladek.Add(wynik / 12);

                }
                for (int i = 11; i <= czas; i++)
                {
                    wynik = 480.0 * 0.2;
                    if (podzial == 1)
                        planSkladek.Add(wynik);
                    else
                        planSkladek.Add(wynik / 12);
                }
            }
            else if (czas <= 10)
            {
                for (int i = 10; i <= czas; i++)
                {
                    if (podzial == 1)
                        planSkladek.Add(wynik);
                    else
                        planSkladek.Add(wynik / 12);
                }
            }

            wynik = 480.0;
            if (wynik == 12)
                wynik = wynik / 12;
            k.historia[l].PakietKoncowy.Skladka = wynik;
            return planSkladek;

        }

        /// <summary>
        /// Funkcja obliczająca sumę składek miesięcznych/rocznych dla pakietu rodzinnego
        /// WEJŚCIE: Klient oraz długość ubezpieczenia
        /// Na początku powstaje pętla dodająca do ogólnej składki opłaty za kolejne dzieci
        /// Potem wprowadzana jest zmienna, wskazującą na istnienie małżonka.
        /// Do obliczonej sumy dodane jest opłata za ubezpieczonego oraz za jej/jego małżonka
        /// Na końcu liczone są kolejne składki dla każdego roku trwania ubezpieczenia
        /// WYJŚCIE: Suma składek przekazana przez referencje oraz lista pokazująca plan składek
        /// </summary>
        //PROMOCJE I PODZIAŁ
        public List<double> PakietRodzinny(int czas, Klient k)
        {
            double czyMalzonek = 0.0;
            int l = k.historia.Count;
            int podzial = k.historia[l].PakietKoncowy.Podzialskl; //te szalone odwołania XD

            double wskladka = 0.0;



            for (int d = 0; d <= k.rodzina.Count; d++)
            {
                if (d == 0 && k.malzonek == true)
                    d++;

                if (k.rodzina[d].Wiek <= 5)
                    wskladka += 15.0;
                else if (k.rodzina[d].Wiek <= 12)
                    wskladka += 20.0;
                else
                    wskladka += 30.0;
            }

            if (k.malzonek == true)
                czyMalzonek = 1.0;

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
                for (int i = 1; i <= 10; i++)
                    planSkladek.Add(wskladka);
                for (int i = 11; i <= czas; i++)
                    planSkladek.Add(wskladka * 0.2);
            }
            else
            {
                for (int i = 1; i <= czas; i++)
                    planSkladek.Add(wskladka);
            }

            return planSkladek;

        }


    }
}
//133