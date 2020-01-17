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

namespace GUI
{
    /// <summary>
    /// Logika interakcji dla klasy AgentStatystyki.xaml
    /// </summary>
    public partial class AgentStatystyki : Window
    {
        Agent agent;
        public AgentStatystyki(Agent a)
        {
            InitializeComponent();
            agent = a;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AgentStatystykiPlec okno = new AgentStatystykiPlec(agent);
            this.Close();
            okno.ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AgentStatystykiWiek okno = new AgentStatystykiWiek(agent);
            this.Close();
            okno.ShowDialog();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            AgentWindow okno = new AgentWindow(agent);
            this.Close();
            okno.ShowDialog();
        }
    }
}
