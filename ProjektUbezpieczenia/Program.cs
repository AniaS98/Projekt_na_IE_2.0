using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektUbezpieczenia
{
    class Program
    {
        static void Main(string[] args)
        {
            Klient K1 = new Klient("Anna", "Szmit", "12345678910", 21, Plcie.K, "123456798", false, Zawody.pracownik_biurowy);
            K1.DodajHobby(Pasje.gry_komputerowe);
            ListaKlientow listak = new ListaKlientow();
            //listak.DodajKlienta(K1);

            DodawanieAgentowdobazy();
            // int l = K1.historia.Count;
            // Console.WriteLine(l);
            //K1.historia.Add(new Zamowienie());
            //int podzial = K1.historia[l].PakietKoncowy.Podzialskl;
            //Console.WriteLine(podzial);

            //K1.FunkcjaPakietDodatkowy(10, K1,1);
            
            //K1.historia[K1.historia.Count - 1].PakietKoncowy.Podzialskl = 1;
            //K1.PakietPodstawowyIndywiduany(10, K1);

            listak.ZapiszXML("ListaKlientow");

            //NadpisywanieDanychKlienci(K1);

            //ListaKlientow ListaDoKontaktu = new ListaKlientow();
            //ListaDoKontaktu.ZapiszXML("ListaKlientówDoKontaktu");
            


            Console.WriteLine(K1);

            Console.ReadKey();

        }
        

        static void DodawanieAgentowdobazy()
        {
            string PathConn = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + "DanePrzedstawiciele.xls" + "; Extended Properties=\"Excel 8.0;HDR=Yes;\";";
            OleDbConnection conn = new OleDbConnection(PathConn);

            OleDbDataAdapter myDataAdapter = new OleDbDataAdapter("Select * From [Arkusz1$]", conn);
            DataSet dt = new DataSet();

            myDataAdapter.Fill(dt, "Arkusz1");


            int rozmiar = dt.Tables["Arkusz1"].Rows.Count;
            //(string imie, string nazwisko, int idAgenta, string haslo, ListaKlientow lista_klientow) : base(imie, nazwisko)
            Agent[] A = new Agent[rozmiar];
            ListaAgentow la = new ListaAgentow();
            for(int i=0;i<rozmiar;i++)
            {
                int zmienna;
                Int32.TryParse(dt.Tables["Arkusz1"].Rows[i][0].ToString(),out zmienna);
                A[i] = new Agent(dt.Tables["Arkusz1"].Rows[i][1].ToString(), dt.Tables["Arkusz1"].Rows[i][2].ToString(), zmienna, dt.Tables["Arkusz1"].Rows[i][4].ToString());

                la.DodajAgenta(A[i]);
            }

            la.ZapiszXML();
        }



    }
}
