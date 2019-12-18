using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.IO;

namespace ProjektUbezpieczenia
{
    [Serializable]
    class ListaAgentow
    {
        int id;
        List<Agent> agenci;

        public int Id { get => id; set => id = value; }
        public List<Agent> Agenci { get => agenci; set => agenci = value; }

        public ListaAgentow()
        {
            id = '0';
            agenci = new List<Agent>();
        }

        public ListaAgentow(int id)
        {
            this.id = id;
        }

        public void DodajAgenta(Agent a)
        {
            agenci.Add(a);
        }

        public void UsunAgenta(string imie, string nazwisko)
        {
            foreach (Agent i in agenci)
            {
                if (i.Imie == imie && i.Nazwisko == nazwisko)
                {
                    agenci.Remove(i);
                    return;
                }
            }
        }


        public void ZapiszXML()
        {
            using (Stream s = File.Create("ListaAgentow.xml"))
            {
                XmlSerializer oSerializer = new XmlSerializer(typeof(ListaAgentow));
                oSerializer.Serialize(s, this);
            }
        }

        public static ListaKlientow OdczytajXML(string nazwaPliku)
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
        }
    }
}
