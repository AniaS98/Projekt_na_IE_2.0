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
            listak.DodajKlienta(K1);

            DodawanieAgentowdobazy();
            // int l = K1.historia.Count;
            // Console.WriteLine(l);
            //K1.historia.Add(new Zamowienie());
            //int podzial = K1.historia[l].PakietKoncowy.Podzialskl;
            //Console.WriteLine(podzial);

            K1.FunkcjaPakietDodatkowy(10, K1);
            
            K1.historia[K1.historia.Count - 1].PakietKoncowy.Podzialskl = 1;
            K1.PakietPodstawowyIndywiduany(10, K1);

            listak.ZapiszXML();

            //NadpisywanieDanychKlienci(K1);




            Console.WriteLine(K1);

            Console.ReadKey();

        }
        static void NadpisywanieDanychKlienci(Klient k)
        {
            List<double> results = new List<double>();
            int doros = 1;
            int ldzieci = 0;
            if (k.Rodzina != null)
                ldzieci = k.Rodzina.Count;

            if (k.Malzonek == true)
            {
                ldzieci--;
                doros++;
                results = k.PakietRodzinny(10, k);
            }
            else
                results = k.PakietPodstawowyIndywiduany(10, k);

            int[] wdzieci = new int[4];
            wdzieci[0] = 0;
            wdzieci[1] = 0;
            wdzieci[2] = 0;
            wdzieci[3] = 0;

            if (k.rodzina != null)
            {
                foreach (CzlonekRodziny c in k.rodzina)
                {
                    wdzieci[3]++;
                    if (c.Wiek <= 5)
                        wdzieci[0]++;
                    else if (c.Wiek <= 12)
                        wdzieci[1]++;
                    else
                        wdzieci[2]++;
                }
            }

            //SpE,Onk,Ort,PZD,NDZ,SWK,SNNW
            List<String> dodat = new List<string>();
            int index = k.historia.Count - 1;
            foreach (var w in Enum.GetNames(typeof(Edodat)))
            {  
                dodat.Add("Nie");
                List<PakietDodatkowy> plista = k.historia[index].PakietKoncowy.Dodatkowe;
                foreach (PakietDodatkowy pkd in plista)
                {
                        if (pkd.Nazwa == w.ToString())
                        dodat[dodat.Count-1] = "Tak";
                }
            }
            Console.WriteLine(dodat.Count);

            string pod;
            if (k.historia[index].PakietKoncowy.Podzialskl == 12)
                pod = "Miesięczna";
            else
                pod = "Roczna";


            Console.WriteLine(k.historia[index].PakietKoncowy.Lata);

            var wpis = new StringBuilder();
            var newLine = string.Format("41," + k.Imie + "," + k.Nazwisko.ToString() + "," + k.Wiek.ToString() + "," + k.Plec.ToString() + "," +
                ldzieci.ToString() + "," + wdzieci[0].ToString() + "," + wdzieci[1].ToString() + "," + wdzieci[2].ToString() + "," + doros.ToString() + "," + 
                (doros + wdzieci[3]).ToString() + "," + dodat[0].ToString() + "," + dodat[1].ToString() + "," + dodat[2].ToString() + "," + dodat[3].ToString() + 
                "," + dodat[4].ToString() + "," + dodat[5].ToString() + "," + dodat[6].ToString() + ","+pod + "," + results[0] + "," + results[1] + "," + 
                k.historia[index].PakietKoncowy.Lata);
            wpis.Append(newLine);
            /*using (FileStream fs = new FileStream("D:\\adm\\Documents\\Programowanie_C#\\ProjektUbezpieczenia\\ProjektUbezpieczenia\\DaneKlienci.csv", FileMode.Append, FileAccess.Write))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.WriteLine(wpis);
                }
            }*/


            



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
            Console.WriteLine("Dziala");
        }



    }
}
