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
    /// Logika interakcji dla klasy ChorobyWindow.xaml
    /// </summary>
    public partial class ChorobyWindow : Window
    {
        Klient klient;
        public ChorobyWindow(Klient klient)
        {
            InitializeComponent();
            this.klient = klient;
        }

        private void CheckButton_Choroby(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            string nazwa = checkBox.Content.ToString().ToLower();
            Choroby c = klient.Chorobies.Where(i => i.ToString() == nazwa).FirstOrDefault();
            if (checkBox.IsEnabled)
                if (!klient.Chorobies.Contains(c))
                    klient.Chorobies.Add(c);
                else
                    klient.Chorobies.Remove(c);
        }

        private void Zatwierdz_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
