using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp3Test3A
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Pytanie> ListaPytan { get; set; }
        public int NumerPytanie {get; set; }
        public int LiczbaPunktow { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            odczytajPytania();
            NumerPytanie = 0;
            LiczbaPunktow = 0;
            trescpytania_textblock.Text = ListaPytan[0].Tresc;
        }

        private void odczytajPytania()
        {
            ListaPytan = new List<Pytanie>();
            StreamReader plik = new StreamReader("pytania.txt");
            string tresc = plik.ReadLine();
            string odp = plik.ReadLine();
            Pytanie pytanie;
            while (tresc != null)
            {
                if (odp == "true")
                {
                    pytanie = new Pytanie(tresc, true);
                }
                else
                {
                    pytanie = new Pytanie(tresc, false);
                }
                ListaPytan.Add(pytanie);
                tresc = plik.ReadLine();
                odp = plik.ReadLine();
            }
        }

        private void takButton_Click(object sender, RoutedEventArgs e)
        {   sprawdzPunkty(NumerPytanie,true);
            NumerPytanie++;
            sprawdzenie(NumerPytanie);
            
            
        }
        private void sprawdzenie(int i)
        {
            if (i == ListaPytan.Count)
            {
                MessageBox.Show("Test został zakończony twój wynik: " + LiczbaPunktow.ToString());
                Close();
                return;
            }
            else
            {
                trescpytania_textblock.Text = ListaPytan[NumerPytanie].Tresc;
            }
        }
        private void nieButton_Click(object sender, RoutedEventArgs e)
        { sprawdzPunkty(NumerPytanie,false);
            NumerPytanie++;
            sprawdzenie(NumerPytanie);
            
           
        }
        private void sprawdzPunkty(int i,bool odp)
        {
            if(odp == ListaPytan[i].Odpowiedz)
            {
                LiczbaPunktow++;
            }
        }
    }
}
