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
    /// Logika interakcji dla klasy AgentStatystykiPlec.xaml
    /// </summary>
    public partial class AgentStatystykiPlec : Window
    {
        Agent agent;
        public AgentStatystykiPlec(Agent a)
        {
            InitializeComponent();
            agent = a;


            FileStream stream = File.Open("Klienci_dane.xls", FileMode.Open, FileAccess.Read);
            IExcelDataReader reader;
            reader = ExcelDataReader.ExcelReaderFactory.CreateReader(stream);
            DataSet result = reader.AsDataSet();
            DataTable dt = result.Tables["Wykres_agent"];
            string k_1 = dt.Rows[1][0].ToString();
            string k_2 = dt.Rows[1][1].ToString();
            string k_3 = dt.Rows[1][2].ToString();
            string k_4 = dt.Rows[1][3].ToString();
            string k_5 = dt.Rows[1][4].ToString();
            string k_6 = dt.Rows[1][5].ToString();
            string k_7 = dt.Rows[1][6].ToString();

            SeriesCollection = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Kobiety",
                    Values = new ChartValues<double> { Convert.ToDouble(k_1), Convert.ToDouble(k_2) , Convert.ToDouble(k_3), Convert.ToDouble(k_4), Convert.ToDouble(k_5), Convert.ToDouble(k_6), Convert.ToDouble(k_7) }
                }
            };

            string m_1 = dt.Rows[2][0].ToString();
            string m_2 = dt.Rows[2][1].ToString();
            string m_3 = dt.Rows[2][2].ToString();
            string m_4 = dt.Rows[2][3].ToString();
            string m_5 = dt.Rows[2][4].ToString();
            string m_6 = dt.Rows[2][5].ToString();
            string m_7 = dt.Rows[2][6].ToString();
            //adding series will update and animate the chart automatically
            SeriesCollection.Add(new ColumnSeries
            {
                Title = "Mężczyźni",
                Values = new ChartValues<double> { Convert.ToDouble(m_1), Convert.ToDouble(m_2), Convert.ToDouble(m_3), Convert.ToDouble(m_4), Convert.ToDouble(m_5), Convert.ToDouble(m_6), Convert.ToDouble(m_7) }
            });

            //also adding values updates and animates the chart automatically

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

