using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ProjektUbezpieczenia;
using System.Data.OleDb;
using System.Data;
using System.Windows.Forms;
using System.Threading;

namespace GUI
{
    /// <summary>
    /// Logika interakcji dla klasy AgentWindow.xaml
    /// </summary>
    public partial class AgentWindow : Window
    {
        public string przedstawiciel;
        public AgentWindow(string a)
        {
            InitializeComponent();
            przedstawiciel= a;
        }
        string plik = "D:\\!!!_PULPET_D\\Studia\\V semestr\\IE\\Klienci_dane.xls";

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string PathConn = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + plik + "; Extended Properties=\"Excel 8.0;HDR=Yes;\";";
            OleDbConnection conn = new OleDbConnection(PathConn);

            OleDbDataAdapter myDataAdapter = new OleDbDataAdapter("Select * from [" + przedstawiciel+ "$]", conn);
            DataSet dt = new DataSet();
            DataSet ds = new DataSet();
            DataTable dataTab = new DataTable();
            myDataAdapter.Fill(dt, przedstawiciel);
            dataGridView.ItemsSource = dt.Tables[przedstawiciel].DefaultView;

            /*
            //foreach(DataRow row in dt.Tables[przedstawiciel].Rows)
            //{
            //int d = 1;
            foreach (DataRow dr in dt.Tables[przedstawiciel].Rows)
            {
                if (!dr.ToString().Equals(""))
                {
                    Monitor.Enter(this);
                    try
                    {
                        DataRow drow = dataTab.NewRow();
                        for (int i = 0; i <= 29; i++)
                        {
                            drow[i] = dr[i];
                        }
                        dataTab.Rows.Add(drow);
                    }
                    finally
                    {
                        Monitor.Exit(this);
                    }
                    

                }
            }
            ds.Tables.Add(dataTab);


            /*
                int n = dt.Tables[przedstawiciel].Rows.Count-1;
                for (int i=1;i<=n;i++)
                {
                    if(!dt.Tables[przedstawiciel].Rows[i][0].ToString().Equals(""))
                    {
                    for (int j = 1; j <= n; j++)
                    {
                        dataTab.Rows[d][j] = dt.Tables[przedstawiciel].Rows[i][j].ToString();
                    }
                    d++;
                    }
                    

                        
                }
            ds=dataTab.DataSet;
            
           
            for (int i=1;i<dt.Tables[przedstawiciel].Rows.Count ;i++)
            {
                DataRow row = dt.Tables[przedstawiciel].Rows[i];
                if(row[0].Equals(""))
                {
                    dt.Tables[przedstawiciel].Rows.RemoveAt(i);
                }
            }
            dataGridView.ItemsSource = dt.Tables[przedstawiciel].DefaultView;

            
            int index = 0;
             foreach (DataRow row in dt.Tables[przedstawiciel].Rows)
                {
                object o = row.ItemArray;
                if (String.IsNullOrEmpty(row.ToString()))
                {
                    dt.Tables[przedstawiciel].Rows.RemoveAt(index);
                }
                index++;
                }

            dataGridView.ItemsSource = dt.Tables[przedstawiciel].DefaultView;
           foreach (DataRow row in dt.Tables[przedstawiciel].Rows)
           {
               bool IsEmpty = false;
               foreach (object obj in row.ItemArray)
               {
                   if (String.IsNullOrEmpty(obj.ToString()))
                   {
                       IsEmpty = true;
                   }
                   else
                   {
                       IsEmpty = false;
                   }
              }
               if (IsEmpty)
               {
                   dt.Tables[przedstawiciel].Rows.Remove(row);
               }
           }*/

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string PathConn = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + plik + "; Extended Properties=\"Excel 8.0;HDR=Yes;\";";
            OleDbConnection conn = new OleDbConnection(PathConn);

            OleDbDataAdapter myDataAdapter = new OleDbDataAdapter("Select * from [" + przedstawiciel+"_koniec" + "$]", conn);
            DataSet dt = new DataSet();

            myDataAdapter.Fill(dt, przedstawiciel + "_koniec");

            dataGridView.ItemsSource = dt.Tables[przedstawiciel + "_koniec"].DefaultView;
        }
    }
}
