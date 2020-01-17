using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
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
    /// Logika interakcji dla klasy AgentLogowanieWindow.xaml
    /// </summary>
    public partial class AgentLogowanieWindow : Window
    {
                public string login; //= "agent";
        public string haslo; //= "agent";
 
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
            ListaAgentow listaA= ListaAgentow.OdczytajXML("ListaAgentow.xml");
            Console.WriteLine(listaA.agenci.Count);
            bool dostep = false;
            foreach(Agent a in listaA.agenci)
            {
                if(a.haslo==PasswordBox_HasloAgent.Password)
                {
                    dostep = true;
                    AgentWindow okno = new AgentWindow(a);
                    this.Close();
                    okno.ShowDialog();
                }

            }
            if(dostep==false)
            {
                MessageBox.Show("Złe hasło lub login");
                return;
            }


            /*
            if ((login == TextBox_LoginAgent.Text))
            {
                if (haslo == PasswordBox_HasloAgent.Password)
                {
                    AgentWindow okno = new AgentWindow(login);
                    this.Close();
                    okno.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Złe hasło lub login");
                return;
            }*/
        }

    }
}
