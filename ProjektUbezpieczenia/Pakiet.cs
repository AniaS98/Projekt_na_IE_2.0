using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.IO;

namespace ProjektUbezpieczenia
{
    [Serializable]
    public class Pakiet
    {
        string nazwa;
        double koszt;
        int id;

        public string Nazwa { get => nazwa; set => nazwa = value; }
        public double Koszt { get => koszt; set => koszt = value; }
        public int Id { get => id; set => id = value; }

        public Pakiet()
        {
            nazwa = "";
            koszt = 0.0;
            id = '0';
        }

        public Pakiet(string nazwa, double koszt, int id)
        {
            this.nazwa = nazwa;
            this.koszt = koszt;
            this.id = id;
        }

        public override string ToString()
        {
            return nazwa + ", koszt: " + koszt + ", ID: " + id;
        }

        /*
        /// <summary>
        /// Funkcja, która zwraca listę pakietów dodatkowych oraz oblicza składkę roczną ubezpieczenia za dodatkowe pakiety
        /// WEJŚCIE: Klient
        /// Zawsze brane są pod uwagę pakiety dotyczące śmierci, a reszta jest podyktowana zawodem lub pasją
        /// 
        /// 
        /// WYJŚCIE: pakiety dodatkowe (przekazywane przez ID Klienta do ID zamówienia, w którym jest pakiet końcowy, a w nim lista pakietów dodatkowych. W zamówieniu będzie składka roczna
        /// </summary>

        //PakietKoncowy(int id, double znizka, double skladka, int podzialskl, double kosztKoncowy)



        public void FunkcjaPakietDodatkowy(Klient k)
        {
            //ZNIZKA NA RAZIE WYNOSI ZERO, BO NIE ROBILAM DO TEGO JESZCZE FUNKCJI, TO SAMO ZE SKLADKA, BO NA RAZIE NIE MA POWIAZANIA Z RODZAJEM UBEZPIECZENIA
            PakietKoncowy pk = new PakietKoncowy(0, 0, 0, 0, 0);
            int l = k.historia.Count;  
            PakietDodatkowy pd = new PakietDodatkowy();

            //PakietDodatkowy(string nazwa, double koszt, int idd, int lata, double skladka)

            if (k.Hobby==Pasje.sporty_ekstremalne)
            {
                pd = new PakietDodatkowy("SportyEkstremalne", 5000.0, 1, 5, 60.0);
                pk.DodajPakiet2(pd);
                pk.Skladka += 60.0;
            }

            //górnik (rak płuc, oskrzeli, itp), pilot (promieniowanie kosmiczne)
            if (k.Chorobies.Contains(Choroby.nowotwory) || k.Zawod==Zawody.gornik || k.Zawod==Zawody.pilot_samolotu)
            {
                pd = new PakietDodatkowy("Onkolog", 20000.0, 2, 5, 120.0);
                pk.DodajPakiet2(pd);
                pk.Skladka += 120.0;
            }   

            if (k.Chorobies.Contains(Choroby.osteoporoza) || k.Wiek > 60 || k.Hobby == Pasje.wspinaczka_gorska || k.Hobby == Pasje.rower || k.Hobby == Pasje.sporty_zimowe || k.Hobby == Pasje.lekkoatletyka)
            {
                pd = new PakietDodatkowy("Ortopeda", 10000.0, 3, 5, 96.0);
                pk.DodajPakiet2(pd);
                pk.Skladka += 96.0;
            }
            if(k.Rodzina!=null)
            {
                pd = new PakietDodatkowy("PowazneZachorowanieDziecka", 20000.0, 4, 5, 120.0);
                pk.DodajPakiet2(pd);
                pk.Skladka += 120.0;
            }
            if (k.Zawod==Zawody.gornik || k.Zawod==Zawody.zolnierz || k.Zawod==Zawody.rybak || k.Zawod==Zawody.pilot_samolotu || k.Zawod==Zawody.policjant ||   k.Zawod==Zawody.strazak ||  k.Zawod==Zawody.budowlaniec || k.Zawod==Zawody.pracownik_przemysłu_ciezkiego || k.Zawod==Zawody.osoba_pracujaca_na_wysokosci || k.Zawod==Zawody.lekarz)
            {
                pd = new PakietDodatkowy("Niezdolnosc", 50000.0, 5, 5, 120.0);
                pk.DodajPakiet2(pd);
                pk.Skladka += 120.0;
            }
            //W proponowanych zawsze będą Śmierci, chyba że wymyślimy jakieś warunki :D
            pd = new PakietDodatkowy("SmiercWK", 100000.0, 6, 5, 60.0);
            pk.DodajPakiet2(pd);
            pk.Skladka += 60.0;

            pd = new PakietDodatkowy("smiercNW", 50000.0, 7, 5, 144.0);
            pk.DodajPakiet2(pd);
            pk.Skladka += 144.0;


            Zamowienie z = new Zamowienie(false, l, pk);
            k.DodajZamowienie(z);

        }

        //Poprawić dokumentację
        /// <summary>
        /// Funkcja, która decyduje jak będą wykonywane obliczenia i podaje ich wyniki
        /// WEJŚCIE: Bool (false-pakiet indywidualny,true-pakiet rodzinny)
        /// WYJŚCIE: Gotowe wyniki, które powstaną poprzez przekierowanie do innych funkcji wewnątrz tej funkcji
        /// </summary>
        public double PakietPodstawowyIndywiduany(int czas,int wiek, Plcie plec)
        {
            double suma = 100000;
            double oprocentowanie = (1/1.05);


            return 480;
        }

        */


    }
}//38
