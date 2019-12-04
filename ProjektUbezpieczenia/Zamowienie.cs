using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace ProjektUbezpieczenia
{
    [Serializable]
    public class Zamowienie
    {
        bool efekt; //FALSE-NO DEAL, TRUE - DEAL
        int id;
        PakietKoncowy pakietKoncowy;

        public bool Efekt { get => efekt; set => efekt = value; }
        public int Id { get => id; set => id = value; }
        public PakietKoncowy PakietKoncowy { get => pakietKoncowy; set => pakietKoncowy = value; }

        public Zamowienie()
        {
            efekt = false;
            id = 0;
            pakietKoncowy = new PakietKoncowy();
        }

        public Zamowienie(bool efekt, int id, PakietKoncowy pakietKoncowy)
        {
            this.efekt = efekt;
            this.id = id;
            this.pakietKoncowy = pakietKoncowy;
        }


        public void ZapiszXML()
        {
            using (Stream s = File.Create("Zamowienie.xml"))
            {
                XmlSerializer oSerializer = new XmlSerializer(typeof(Zamowienie));
                oSerializer.Serialize(s, this);
            }
        }
        public static Zamowienie OdczytajXML(string nazwaPliku)
        {
            try
            {
                FileStream fstream = new FileStream(nazwaPliku, FileMode.Open);
                XmlSerializer oSerializer = new XmlSerializer(typeof(Zamowienie));
                fstream.Position = 0;
                Zamowienie lk = (Zamowienie)oSerializer.Deserialize(fstream);
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
