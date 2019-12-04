using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.IO;

namespace ProjektUbezpieczenia
{
    [Serializable]
    public class ListaKlientow

    {
        public int id;
        public List<Klient> klienci;

        public int Id { get => id; set => id = value; }
        public List<Klient> Klienci { get => klienci; set => klienci = value; }

        public ListaKlientow()
        {
            id = '0';
            klienci = new List<Klient>();
        }

        public ListaKlientow(int id)
        {
            this.id = id;
        }

        public void DodajKlienta(Klient k)
        {
            klienci.Add(k);
        }

        public void UsunKlienta(string imie, string nazwisko)
        {
            foreach (Klient i in klienci)
            {
                if (i.Imie == imie && i.Nazwisko == nazwisko)
                {
                    klienci.Remove(i);
                    return;
                }
            }
        }
        public void ZapiszXML()
        {
            using (Stream s = File.Create("ListaKlientow.xml"))
            {
                XmlSerializer oSerializer = new XmlSerializer(typeof(ListaKlientow));
                oSerializer.Serialize(s, this);
            }
        }

        public static ListaKlientow OdczytajXML(string nazwaPliku)
        {
            try
            {
                /*
                XmlSerializer oSerializer = new XmlSerializer(typeof(ListaKlientow));
                using (Stream s = File.OpenRead(nazwaPliku))
                    ListaKlientow lk = (ListaKlientow)oSerializer.Deserialize(fstream);
                return ListaKlientow;
                */

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
        }


    }
}
