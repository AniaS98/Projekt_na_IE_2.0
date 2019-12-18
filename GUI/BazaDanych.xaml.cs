using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ProjektUbezpieczenia;
using System.Data.OleDb;
using System.Data;
using System.Text.RegularExpressions;

namespace GUI
{
    /// <summary>
    /// Logika interakcji dla klasy BazaDanych.xaml
    /// </summary>
    public partial class BazaDanych : Window
    {
        public BazaDanych()
        {
            InitializeComponent();
        }
      
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string PathConn = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + "Klienci_dane.xls" + "; Extended Properties=\"Excel 8.0;HDR=Yes;\";";
            OleDbConnection conn = new OleDbConnection(PathConn);

            OleDbDataAdapter myDataAdapter = new OleDbDataAdapter("Select Imię,Nazwisko,Wiek,Dzieci,Ubezpieczeni,Typ,Składka,Telefon,Początek,Koniec,id from ["+ "Sheet1" + "$]", conn);
            DataSet dt = new DataSet();

            myDataAdapter.Fill(dt,"Sheet1");

            DataGridView.ItemsSource = dt.Tables["Sheet1"].DefaultView;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AdminWindow okno = new AdminWindow();
            this.Close();
            okno.ShowDialog();
        }
    }
}
