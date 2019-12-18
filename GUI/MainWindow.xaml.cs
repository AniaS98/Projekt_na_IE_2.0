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

namespace GUI
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Klient_Click(object sender, RoutedEventArgs e)
        {
            KlientWindow okno = new KlientWindow();
            this.Close();
            okno.ShowDialog();
        }

        private void Przedstawiciel_Click(object sender, RoutedEventArgs e)
        {
            AgentLogowanieWindow okno = new AgentLogowanieWindow();
            this.Close();
            okno.ShowDialog();
        }

        private void Administrator_Click(object sender, RoutedEventArgs e)
        {
            AdminLogowanieWindow okno = new AdminLogowanieWindow();
            this.Close();
            okno.ShowDialog();
        }
    }
}
