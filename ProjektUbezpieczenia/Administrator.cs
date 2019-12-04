using System;
using System.Collections.Generic;
using System.Text;

namespace ProjektUbezpieczenia
{
    [Serializable]
    class Administrator
    {
        string haslo;
        ListaKlientow lista_klientow;

        public string Haslo { get => haslo; set => haslo = value; }

        public Administrator()
        {
            haslo = "";
            lista_klientow = new ListaKlientow();
        }

        public Administrator(string haslo, ListaKlientow lista_klientow)
        {
            this.haslo = haslo;
            this.lista_klientow = lista_klientow;
        }

        List<double> suma_agenta;
        List<int> sprzedaz_agenta;

        /// <summary>
        /// Opis
        /// </summary>


        public void AnalizaAgentow(ListaAgentow ags)
        {
            suma_agenta = new List<double>();
            sprzedaz_agenta = new List<int>();
            List<Agent> alist = ags.Agenci;

            foreach (Agent a in alist)
            {
                double suma = 0.0;
                List<Klient> klist = a.lista_klientow.klienci;
                foreach (Klient k in klist)
                {


                    //suma = k.historia[k.historia.Count].;


                }


            }







        }









    }
}
