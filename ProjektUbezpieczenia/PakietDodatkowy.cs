using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.IO;

namespace ProjektUbezpieczenia
{
    public enum Edodat
    {
        SportyEkstremalne, Onkolog, Ortopeda, PowazneZachorowanieDziecka, Niezdolnosc, SmiercWK, smiercNW
    }


    [Serializable]
    public class PakietDodatkowy
    {


        string nazwa;
        double koszt;
        int idd;
        int lata;
        double skladka;
        int podzialskl;
        //List<Pakiet> pakiety;

        public string Nazwa { get => nazwa; set => nazwa = value; }
        public double Koszt { get => koszt; set => koszt = value; }
        public int Idd { get => idd; set => idd = value; }
        public int Lata { get => lata; set => lata = value; }
        public double Skladka { get => skladka; set => skladka = value; }
        public int Podzialskl { get => podzialskl; set => podzialskl = value; }
        //public List<Pakiet> Pakiety { get => pakiety; set => pakiety = value; }

        public PakietDodatkowy()
        {
            nazwa = "";
            koszt = 0.0;
            idd = 0;
            lata = 0;
            skladka = 0.0;
            podzialskl = 0;

            //pakiety = new List<Pakiet>();
        }

        public PakietDodatkowy(string nazwa, double koszt, int idd, int lata, double skladka)
        {
            this.nazwa = nazwa;
            this.koszt = koszt;
            this.idd = idd;
            this.lata = lata;
            this.skladka = skladka;
        }

        public PakietDodatkowy(string nazwa, double koszt, int idd, int lata, double skladka, int podzialskl)
        {
            this.nazwa = nazwa;
            this.koszt = koszt;
            this.idd = idd;
            this.lata = lata;
            this.skladka = skladka;
            this.podzialskl = podzialskl;
        }
        /*
        public void DodajPakiet(Pakiet p)
        {
            pakiety.Add(p);
        }

        public void UsunPakiet(string nazwa)
        {
            foreach (Pakiet i in pakiety)
            {
                if (i.Nazwa == nazwa)
                {
                    pakiety.Remove(i);
                    return;
                }
            }
        }*/
        public override string ToString()
        {
            return nazwa + ", koszt: " + koszt + ", id: " + idd + ", czas trwania (w latach): " + lata + ", składka: " + skladka + ", podział składki (miesięczna, kwartalna lub roczna): " + podzialskl;
        }


    }
}
