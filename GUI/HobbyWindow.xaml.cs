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
    /// Logika interakcji dla klasy HobbyWindow.xaml
    /// </summary>
    public partial class HobbyWindow : Window
    {
        Klient klient;
        bool decyzja;
        public HobbyWindow(Klient klient, bool d)
        {
            decyzja = d;
            InitializeComponent();
            this.klient = klient;
        }

        private void CheckButton_Hobby(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            string nazwa = checkBox.Content.ToString().ToLower();
            Pasje p = klient.Hobbies.Where(i => i.ToString() == nazwa).FirstOrDefault();
            if (checkBox.IsEnabled)
                if (!klient.Hobbies.Contains(p))
                    klient.Hobbies.Add(p);
                else
                    klient.Hobbies.Remove(p);
        }

        private void Zatwierdz_Click(object sender, RoutedEventArgs e)
        {
            PakietWindow okno = new PakietWindow(klient, decyzja);
            okno.ShowDialog();
        }
    }
}
