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
    /// Logika interakcji dla klasy AdminLogowanieWindow.xaml
    /// </summary>
    public partial class AdminLogowanieWindow : Window
    {
        public string login = "admin";
        public string haslo = "admin";

        public AdminLogowanieWindow()
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
            if ((login == TextBox_LoginAdmin.Text))
            {
                if (haslo == PasswordBox_HasloAdmin.Password)
                {
                    AdminWindow okno = new AdminWindow();
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
