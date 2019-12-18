using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ProjektUbezpieczenia
{
    [Serializable]
    public class Agent : Osoba
    {
        public int idAgenta;
        public string haslo;
        public ListaKlientow lista_klientow;

        public int IdAgenta { get => idAgenta; set => idAgenta = value; }
        public string Haslo { get => haslo; set => haslo = value; }
        public ListaKlientow Lista_klientow { get => lista_klientow; set => lista_klientow = value; }

        public Agent()
        {
            idAgenta = 0;
            haslo = "";
            lista_klientow = new ListaKlientow();
        }

        public Agent(string imie, string nazwisko, int idAgenta, string haslo, ListaKlientow lista_klientow) : base(imie, nazwisko)
        {
            this.Imie = imie;
            this.Nazwisko = nazwisko;
            this.idAgenta = idAgenta;
            this.haslo = haslo;
            this.lista_klientow = lista_klientow;

        }



    }
}
