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
    /// Logika interakcji dla klasy AgentLogowanieWindow.xaml
    /// </summary>
    public partial class AgentLogowanieWindow : Window
    {
        public string login = "agent";
        public string haslo = "agent";

        public AgentLogowanieWindow()
        {
            InitializeComponent();
        }

        private void Cofnij_Click(object sender, RoutedEventArgs e)
        {
            MainWindow okno = new MainWindow();
            this.Close();
            okno.ShowDialog();
        }

        private void Zaloguj_Click(object sender, RoutedEventArgs e)
        {
            if ((login == TextBox_LoginAgent.Text))
            {
                if (haslo == PasswordBox_HasloAgent.Password)
                {
                    AgentWindow okno = new AgentWindow();
                    this.Close();
                    okno.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Złe hasło lub login");
                return;
            }
        }
    }
}
