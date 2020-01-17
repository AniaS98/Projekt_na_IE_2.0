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
using System.IO;
using ExcelDataReader;

namespace GUI
{
    /// <summary>
    /// Logika interakcji dla klasy AgentWindow.xaml
    /// </summary>
    public partial class AgentWindow : Window
    {
        Agent przedstawiciel;
        public AgentWindow(Agent a)
        {
            InitializeComponent();
            przedstawiciel= a;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        { 
          
             string PathConn = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + "Klienci_dane.xls" + "; Extended Properties=\"Excel 8.0;HDR=Yes;\";";
             OleDbConnection conn = new OleDbConnection(PathConn);

             OleDbDataAdapter myDataAdapter = new OleDbDataAdapter("Select * from [" +"Sheet1"+ "$]", conn);
             DataSet dt = new DataSet();
             myDataAdapter.Fill(dt, "Sheet1");


            dataGridView.ItemsSource= ((dt.Tables["Sheet1"].DefaultView).RowFilter = string.Format("id = '{0}'", przedstawiciel.Nazwisko.ToString()));
            dataGridView.ItemsSource = dt.Tables["Sheet1"].DefaultView;
       

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
            string PathConn = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + "Klienci_dane.xls" + "; Extended Properties=\"Excel 8.0;HDR=Yes;\";";
            OleDbConnection conn = new OleDbConnection(PathConn);

            OleDbDataAdapter myDataAdapter = new OleDbDataAdapter("Select * from [" + "Sheet1" + "$]", conn);
            DataSet dt = new DataSet();

            myDataAdapter.Fill(dt, "Sheet1");

            DateTime dateT = DateTime.Now.AddMonths(1);
            dataGridView.ItemsSource = ((dt.Tables["Sheet1"].DefaultView).RowFilter = string.Format("Koniec<= '{0}' AND id = '{1}'", dateT.ToString("yyyy-MM-dd"), przedstawiciel.Nazwisko.ToString()));


           dataGridView.ItemsSource = dt.Tables["Sheet1"].DefaultView;
        }

        private void Statystyki_button_Click(object sender, RoutedEventArgs e)
        {
            AgentStatystyki okno = new AgentStatystyki(przedstawiciel);
            this.Close();
            okno.ShowDialog();
        }

        private void Cofnij_Click(object sender, RoutedEventArgs e)
        {
            MainWindow okno = new MainWindow();
            this.Close();
            okno.ShowDialog();
        }

        private void Wyjdz_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            AgentOczekujacyNaKontakt okno = new AgentOczekujacyNaKontakt(przedstawiciel);
            this.Close();
            okno.ShowDialog();
        }
    }
}
