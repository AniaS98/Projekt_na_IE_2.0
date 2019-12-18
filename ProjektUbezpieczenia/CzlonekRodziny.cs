using System;
using System.Collections.Generic;
using System.Text;

namespace ProjektUbezpieczenia
{
    [Serializable]
    public class CzlonekRodziny : Osoba
    {
        int wiek;

        public int Wiek { get => wiek; set => wiek = value; }

        public CzlonekRodziny()
        {
            wiek = '0';
        }

        public CzlonekRodziny(int wiek)
        {
            this.wiek = wiek;
        }

        public CzlonekRodziny(string imie, string nazwisko, int wiek) : base(imie, nazwisko)
        {
            this.wiek = wiek;
        }

        public override string ToString()
        {
            string s = Imie + " " + Nazwisko + " " + wiek;
            return s;
        }
    }
}
