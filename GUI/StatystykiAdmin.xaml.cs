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



            FileStream stream = File.Open("Klienci_dane.xls", FileMode.Open, FileAccess.Read);
            IExcelDataReader reader;
            reader = ExcelDataReader.ExcelReaderFactory.CreateReader(stream);
            DataSet result = reader.AsDataSet();
            DataTable dt = result.Tables["Wykres_admin"];
            string polisa_1 = dt.Rows[0][0].ToString();
            string polisa_2 = dt.Rows[1][0].ToString();
            string polisa_3 = dt.Rows[2][0].ToString();
            string dod_1 = dt.Rows[0][2].ToString();
            string dod_2 = dt.Rows[1][2].ToString();
            string dod_3 = dt.Rows[2][2].ToString();

            FileStream stream1 = File.Open("DanePrzedstawiciele.xls", FileMode.Open, FileAccess.Read);
            IExcelDataReader reader1;
            reader1 = ExcelDataReader.ExcelReaderFactory.CreateReader(stream1);
            DataSet result1 = reader1.AsDataSet();
            DataTable dt1 = result1.Tables["Arkusz1"];
            string p_1 = dt1.Rows[1][2].ToString();
            string p_2 = dt1.Rows[2][2].ToString();
            string p_3 = dt1.Rows[3][2].ToString();
            // Define the label that will appear over the piece of the chart
            // in this case we'll show the given value and the percentage e.g 123 (8%)
            Func<ChartPoint, string> labelPoint = chartPoint => string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);

            
             pieChart1.Series = new SeriesCollection
             {
                 new PieSeries
                 {
                     Title = p_1,
                     Values = new ChartValues<double> {Convert.ToDouble(polisa_1)},
                     DataLabels = true,
                     LabelPoint = labelPoint,

                 },
                 new PieSeries
                 {
                     Title = p_2,
                     Values = new ChartValues<double> {Convert.ToDouble(polisa_2)},
                     DataLabels = true,
                     LabelPoint = labelPoint
                 },
                 new PieSeries
                 {
                     Title =p_3,
                     Values = new ChartValues<double> {Convert.ToDouble(polisa_3)},
                     DataLabels = true,
                     LabelPoint = labelPoint
                 },
             };
             pieChart1.LegendLocation = LegendLocation.Bottom;
             

            pieChart2.Series = new SeriesCollection
            {
                new PieSeries
                {
                    Title = p_1,
                    Values = new ChartValues<double> {Convert.ToDouble(dod_1)},
                    DataLabels = true,
                    LabelPoint = labelPoint,

                },
                new PieSeries
                {
                    Title = p_2,
                    Values = new ChartValues<double> {Convert.ToDouble(dod_2)},
                    DataLabels = true,
                    LabelPoint = labelPoint
                },
                new PieSeries
                {
                    Title = p_3,
                    Values = new ChartValues<double> {Convert.ToDouble(dod_3)},
                    DataLabels = true,
                    LabelPoint = labelPoint
                },
            };

            pieChart2.LegendLocation = LegendLocation.Bottom;

            reader.Close();
            stream.Close();
            reader1.Close();
            stream1.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AdminWindow okno = new AdminWindow();
            this.Close();
            okno.ShowDialog();
        }


    }
} 


