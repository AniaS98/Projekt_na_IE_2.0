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
using ProjektUbezpieczenia;


namespace GUI
{
    /// <summary>
    /// Logika interakcji dla klasy AgentStatystykiWiek.xaml
    /// </summary>
    public partial class AgentStatystykiWiek : Window
    {
        public string agent;
        public AgentStatystykiWiek(string a)
        {
            InitializeComponent();
            agent = a;

            FileStream stream = File.Open("Klienci_dane.xls", FileMode.Open, FileAccess.Read);
            IExcelDataReader reader;
            reader = ExcelDataReader.ExcelReaderFactory.CreateReader(stream);
            DataSet result = reader.AsDataSet();
            DataTable dt = result.Tables["Wykres_agent"];
            string k_1 = dt.Rows[4][0].ToString();
            string k_2 = dt.Rows[4][1].ToString();
            string k_3 = dt.Rows[4][2].ToString();
            string k_4 = dt.Rows[4][3].ToString();
            string k_5 = dt.Rows[4][4].ToString();
            string k_6 = dt.Rows[4][5].ToString();
            string k_7 = dt.Rows[4][6].ToString();

            SeriesCollection = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "<30",
                    Values = new ChartValues<double> { Convert.ToDouble(k_1), Convert.ToDouble(k_2) , Convert.ToDouble(k_3), Convert.ToDouble(k_4), Convert.ToDouble(k_5), Convert.ToDouble(k_6), Convert.ToDouble(k_7) }
                }
            };

            string k_8 = dt.Rows[5][0].ToString();
            string k_9 = dt.Rows[5][1].ToString();
            string k_10 = dt.Rows[5][2].ToString();
            string k_11 = dt.Rows[5][3].ToString();
            string k_12 = dt.Rows[5][4].ToString();
            string k_13 = dt.Rows[5][5].ToString();
            string k_14 = dt.Rows[5][6].ToString();

           
            SeriesCollection.Add(new ColumnSeries
            {
                Title = "30-40",
                Values = new ChartValues<double> { Convert.ToDouble(k_8), Convert.ToDouble(k_9), Convert.ToDouble(k_10), Convert.ToDouble(k_11), Convert.ToDouble(k_12), Convert.ToDouble(k_13), Convert.ToDouble(k_14) }
            });

            string k_15 = dt.Rows[6][0].ToString();
            string k_16 = dt.Rows[6][1].ToString();
            string k_17 = dt.Rows[6][2].ToString();
            string k_18 = dt.Rows[6][3].ToString();
            string k_19 = dt.Rows[6][4].ToString();
            string k_20 = dt.Rows[6][5].ToString();
            string k_21 = dt.Rows[6][6].ToString();


            SeriesCollection.Add(new ColumnSeries
            {
                Title = "40-50",
                Values = new ChartValues<double> { Convert.ToDouble(k_15), Convert.ToDouble(k_16), Convert.ToDouble(k_17), Convert.ToDouble(k_18), Convert.ToDouble(k_19), Convert.ToDouble(k_20), Convert.ToDouble(k_21) }
            });

            string k_22 = dt.Rows[7][0].ToString();
            string k_23= dt.Rows[7][1].ToString();
            string k_24 = dt.Rows[7][2].ToString();
            string k_25 = dt.Rows[7][3].ToString();
            string k_26= dt.Rows[7][4].ToString();
            string k_27 = dt.Rows[7][5].ToString();
            string k_28 = dt.Rows[7][6].ToString();


            SeriesCollection.Add(new ColumnSeries
            {
                Title = "50-60",
                Values = new ChartValues<double> { Convert.ToDouble(k_22), Convert.ToDouble(k_23), Convert.ToDouble(k_24), Convert.ToDouble(k_25), Convert.ToDouble(k_26), Convert.ToDouble(k_27), Convert.ToDouble(k_28) }
            });

            string k_29 = dt.Rows[8][0].ToString();
            string k_30 = dt.Rows[8][1].ToString();
            string k_31 = dt.Rows[8][2].ToString();
            string k_32 = dt.Rows[8][3].ToString();
            string k_33 = dt.Rows[8][4].ToString();
            string k_34 = dt.Rows[8][5].ToString();
            string k_35 = dt.Rows[8][6].ToString();


            SeriesCollection.Add(new ColumnSeries
            {
                Title = ">60",
                Values = new ChartValues<double> { Convert.ToDouble(k_29), Convert.ToDouble(k_30), Convert.ToDouble(k_31), Convert.ToDouble(k_32), Convert.ToDouble(k_33), Convert.ToDouble(k_34), Convert.ToDouble(k_35) }
            });

            string pakiet_1 = dt.Rows[0][0].ToString();
            string pakiet_2 = dt.Rows[0][1].ToString();
            string pakiet_3 = dt.Rows[0][2].ToString();
            string pakiet_4 = dt.Rows[0][3].ToString();
            string pakiet_5 = dt.Rows[0][4].ToString();
            string pakiet_6 = dt.Rows[0][5].ToString();
            string pakiet_7 = dt.Rows[0][6].ToString();


            Labels = new[] { pakiet_1, pakiet_2, pakiet_3, pakiet_4, pakiet_5, pakiet_6, pakiet_7 };
            Formatter = value => value.ToString("N");

            DataContext = this;
            reader.Close();
            stream.Close();
        }

        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public Func<int, string> Formatter { get; set; }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AgentStatystyki okno = new AgentStatystyki(agent);
            
            this.Close();
            okno.ShowDialog();
        }
    }
    }
