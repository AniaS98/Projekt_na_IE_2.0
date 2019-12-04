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
    }
}
