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

        public override string ToString()
        {
            string s = "wiek:" + wiek;
            return s;
        }
    }
}
