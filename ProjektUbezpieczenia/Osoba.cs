using System;
using System.Collections.Generic;
using System.Text;

namespace ProjektUbezpieczenia
{
    [Serializable]
    public class Osoba
    {
        string imie;
        string nazwisko;

        public string Imie { get => imie; set => imie = value; }
        public string Nazwisko { get => nazwisko; set => nazwisko = value; }

        public Osoba()
        {
            imie = "";
            nazwisko = "";
        }

        public Osoba(string imie, string nazwisko)
        {
            this.imie = imie;
            this.nazwisko = nazwisko;
        }

        public override string ToString()
        {
            return imie + " " + nazwisko;
        }
    }
}
