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
using LiveCharts;
using LiveCharts.Wpf;
using System.Data;
using System.IO;
using ExcelDataReader;
using System.Text.RegularExpressions;

namespace GUI
{
    /// <summary>
    /// Logika interakcji dla klasy StatystykiAdmin.xaml
    /// </summary>
    public partial class StatystykiAdmin : Window
    {

        public StatystykiAdmin()
        {
            InitializeComponent();

            FileStream stream = File.Open("Klienci_dane.xls ", FileMode.Open, FileAccess.Read);
            IExcelDataReader reader;
            reader = ExcelDataReader.ExcelReaderFactory.CreateReader(stream);
            DataSet result = reader.AsDataSet();
            DataTable dt = result.Tables["Wykres_admin"];
            string polisy_1 = dt.Rows[0][0].ToString();
            string polisy_2 = dt.Rows[1][0].ToString();
            string polisy_3 = dt.Rows[2][0].ToString();

            FileStream stream2 = File.Open("DanePrzedstawiciele.xls", FileMode.Open, FileAccess.Read);
            IExcelDataReader reader2;
            reader2 = ExcelDataReader.ExcelReaderFactory.CreateReader(stream2);
            DataSet result2 = reader2.AsDataSet();
            DataTable dt2 = result2.Tables["Arkusz1"];
            string przedstawiciel_1 = dt2.Rows[1][2].ToString();
            string przedstawiciel_2 = dt2.Rows[2][2].ToString();
            string przedstawiciel_3 = dt2.Rows[3][2].ToString();
            /*
            Func<ChartPoint, string> labelPoint = chartPoint =>
            string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);

            pieChart1.Series = new SeriesCollection();
            //Series - Each Slice of the pie. 
            PieSeries pie = new PieSeries();
            pie.Title = "Blue";
            pie.Values = new ChartValues<double> { Convert.ToDouble(10) };
            pie.DataLabels = true;
            pie.LabelPoint = labelPoint;
            pieChart1.Series.Add(pie);
            //Series - Each Slice of the pie. 
            PieSeries pie1 = new PieSeries();
            pie1.Title = "Red";
            pie1.Values = new ChartValues<double> { Convert.ToDouble(50) };
            pie1.DataLabels = true;
            pie1.LabelPoint = labelPoint;
            pieChart1.Series.Add(pie1);
            //Series - Each Slice of the pie. 
            PieSeries pie2 = new PieSeries();
            pie2.Title = "Yellow";
            pie2.Values = new ChartValues<double> { Convert.ToDouble(40) };
            pie2.DataLabels = true;
            pie2.LabelPoint = labelPoint;
            pieChart1.Series.Add(pie2);
            pieChart1.LegendLocation = LegendLocation.Top;
        }
        
        SeriesCollection = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Polisy",
                    Values = new ChartValues<double> { Convert.ToDouble(polisy_1), Convert.ToDouble(polisy_2), Convert.ToDouble(polisy_3) }
                }
            };
            
            string dod_1 = dt.Rows[0][2].ToString();
            string dod_2 = dt.Rows[1][2].ToString();
            string dod_3 = dt.Rows[2][2].ToString();

            //adding series will update and animate the chart automatically
            SeriesCollection.Add(new ColumnSeries
            {
                Title = "Pakiety dod.",
                Values = new ChartValues<double> { Convert.ToDouble(dod_1), Convert.ToDouble(dod_2), Convert.ToDouble(dod_3) }
            }); 
            

            FileStream stream2 = File.Open("DanePrzedstawiciele.xls", FileMode.Open, FileAccess.Read);
            IExcelDataReader reader2;
            reader2 = ExcelDataReader.ExcelReaderFactory.CreateReader(stream2);
            DataSet result2 = reader2.AsDataSet();
            DataTable dt2 = result2.Tables["Arkusz1"];
            string przedstawiciel_1 = dt2.Rows[1][2].ToString();
            string przedstawiciel_2 = dt2.Rows[2][2].ToString();
            string przedstawiciel_3 = dt2.Rows[3][2].ToString();


            Labels = new[] { przedstawiciel_1, przedstawiciel_2, przedstawiciel_3 };
            Formatter = value => value.ToString("N");

            DataContext = this;
            reader.Close();
            stream.Close();
        }
        
        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public Func<int, string> Formatter { get; set; }

    */

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AdminWindow okno = new AdminWindow();
            this.Close();
            okno.ShowDialog();
        }
    }
}

