using System;
using System.Collections.Generic;
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
            Klient K1 = new Klient("Anna", "Szmit", "12345678910", 21, Plcie.K, "123456798", false, Zawody.pracownik_biurowy, Pasje.gry_komputerowe);
            ListaKlientow listak = new ListaKlientow();
            listak.DodajKlienta(K1);


            // int l = K1.historia.Count;
            // Console.WriteLine(l);
            //K1.historia.Add(new Zamowienie());
            //int podzial = K1.historia[l].PakietKoncowy.Podzialskl;
            //Console.WriteLine(podzial);

            K1.FunkcjaPakietDodatkowy(10, K1);


            listak.ZapiszXML();

            NadpisywanieDanychKlienci(K1);




            Console.WriteLine(K1);

            Console.ReadKey();

        }
        static void NadpisywanieDanychKlienci(Klient k)
        {
            int doros = 1;
            int ldzieci = 0;
            if (k.Rodzina != null)
                ldzieci = k.Rodzina.Count;

            if (k.Malzonek == true)
            {
                ldzieci--;
                doros++;
            }


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
            {
                int index = k.historia.Count - 1;

                dodat.Add("Nie");
                foreach (var w in Enum.GetNames(typeof(Edodat)))
                {
                    List<PakietDodatkowy> plista = k.historia[index].PakietKoncowy.Dodatkowe;
                    foreach (PakietDodatkowy pkd in plista)
                    {
                        if (pkd.Nazwa == w.ToString())
                            dodat[dodat.Count - 1] = "Tak";
                    }
                }
                Console.WriteLine(dodat.Count);
            }





            var wpis = new StringBuilder();
            //var newLine = string.Format("41," + k.Imie + "," + k.Nazwisko.ToString() + "," + k.Wiek.ToString() + "," + k.Plec.ToString() + "," + ldzieci.ToString() + "," + wdzieci[0].ToString() + "," + wdzieci[1].ToString() + "," + wdzieci[2].ToString() + "," + doros.ToString() + "," + (doros + wdzieci[3]).ToString() + "," + dodat[1].ToString() + "," + dodat[2].ToString() + "," + dodat[3].ToString() + "," + dodat[4].ToString() + "," + dodat[5].ToString() + "," + dodat[6].ToString() + "," + dodat[7].ToString() + ",");
            var newLine = string.Format("meh");
            wpis.Append(newLine);
            using (FileStream fs = new FileStream("D:\\adm\\Documents\\Programowanie_C#\\Ubezpieczenia\\Ubezpieczenia\\Ubezpieczenia\\DaneKlienci.csv", FileMode.Append, FileAccess.Write))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.WriteLine(wpis);
                }
            }



        }





    }
}
