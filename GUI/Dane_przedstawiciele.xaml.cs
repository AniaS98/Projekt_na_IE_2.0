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
using System.Data.OleDb;
using System.Data;
using ProjektUbezpieczenia;

namespace GUI
{
    /// <summary>
    /// Logika interakcji dla klasy Dane_przedstawiciele.xaml
    /// </summary>
    public partial class Dane_przedstawiciele : Window
    {
        string dane;
        public Dane_przedstawiciele(string p)
        {
            InitializeComponent();
            dane = p;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string PathConn = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + dane + "; Extended Properties=\"Excel 8.0;HDR=Yes;\";";
            OleDbConnection conn = new OleDbConnection(PathConn);

            OleDbDataAdapter myDataAdapter = new OleDbDataAdapter("Select * From [" + "Arkusz1" + "$]", conn);
            DataSet dt = new DataSet();

            myDataAdapter.Fill(dt,"Arkusz1");

            DataGridView.ItemsSource = dt.Tables["Arkusz1"].DefaultView;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AdminWindow okno = new AdminWindow();
            this.Close();
            okno.ShowDialog();
        }
    }
}
