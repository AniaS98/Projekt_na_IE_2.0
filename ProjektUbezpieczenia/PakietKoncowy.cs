using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.IO;

namespace ProjektUbezpieczenia
{
    [Serializable]
    public class PakietKoncowy
    {
        List<PakietDodatkowy> dodatkowe = new List<PakietDodatkowy>();
        int id;
        double znizka;
        double skladka;
        int podzialskl;
        double kosztKoncowy;
        //Pakiet pakiet; //hmmm
        //List<Pakiet> pakiety; //hmmm

        public int Id { get => id; set => id = value; }
        public double Znizka { get => znizka; set => znizka = value; }
        public double Skladka { get => skladka; set => skladka = value; }
        public int Podzialskl { get => podzialskl; set => podzialskl = value; }
        public double KosztKoncowy { get => kosztKoncowy; set => kosztKoncowy = value; }
        internal List<PakietDodatkowy> Dodatkowe { get => dodatkowe; set => dodatkowe = value; }
        //public Pakiet Pakiet { get => pakiet; set => pakiet = value; }
        //public List<Pakiet> Pakiety { get => pakiety; set => pakiety = value; }

        public PakietKoncowy()
        {
            dodatkowe = new List<PakietDodatkowy>();
            id = 0;
            znizka = 0.0;
            skladka = 0.0;
            podzialskl = 0;
            kosztKoncowy = 0.0;
            // pakiet = new Pakiet();
            // pakiety = new List<Pakiet>();
        }

        public PakietKoncowy(int id, double znizka, double skladka, int podzialskl, double kosztKoncowy)
        {
            this.id = id;
            this.znizka = znizka;
            this.skladka = skladka;
            this.podzialskl = podzialskl;
            this.kosztKoncowy = kosztKoncowy;
        }

        /*public PakietKoncowy(int id, double znizka, double skladka, int podzialskl,double kosztKoncowy)     {
            this.id = id;
            this.znizka = znizka;
            this.skladka = skladka;
            this.podzialskl = podzialskl;
            this.kosztKoncowy = kosztKoncowy;
            //this.pakiet = pakiet;
        }*/

        /*public void DodajPakiet(Pakiet p)
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

        public void DodajPakiet2(PakietDodatkowy p)
        {

            dodatkowe.Add(p);
        }

        public void UsunPakiet2(string nazwa)
        {
            foreach (PakietDodatkowy i in dodatkowe)
            {
                if (i.Nazwa == nazwa)
                {
                    dodatkowe.Remove(i);
                    return;
                }
            }
        }

        public void ZapiszXML()
        {
            using (Stream s = File.Create("PakietKoncowy.xml"))
            {
                XmlSerializer oSerializer = new XmlSerializer(typeof(PakietKoncowy));
                oSerializer.Serialize(s, this);
            }
        }
        public static PakietKoncowy OdczytajXML(string nazwaPliku)
        {
            try
            {
                FileStream fstream = new FileStream(nazwaPliku, FileMode.Open);
                XmlSerializer oSerializer = new XmlSerializer(typeof(PakietKoncowy));
                fstream.Position = 0;
                PakietKoncowy lk = (PakietKoncowy)oSerializer.Deserialize(fstream);
                fstream.Close();
                return lk;
            }
            catch (FileNotFoundException)
            {
                SystemException.ReferenceEquals(nazwaPliku, nazwaPliku);
                Console.WriteLine("Plik o padanej nazwie ({0}) nie istnieje", nazwaPliku);
            }
            return null;
        }

        /*public static ListaKlientow OdczytajXML(string nazwaPliku)
        {
            try
            {
                FileStream fstream = new FileStream(nazwaPliku, FileMode.Open);
                XmlSerializer oSerializer = new XmlSerializer(typeof(ListaKlientow));
                fstream.Position = 0;
                ListaKlientow lk = (ListaKlientow)oSerializer.Deserialize(fstream);
                fstream.Close();
                return lk;
            }
            catch (FileNotFoundException)
            {
                SystemException.ReferenceEquals(nazwaPliku, nazwaPliku);
                Console.WriteLine("Plik o padanej nazwie ({0}) nie istnieje", nazwaPliku);
            }
            return null;
        }*/
    }
}
