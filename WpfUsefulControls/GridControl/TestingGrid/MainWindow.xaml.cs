using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DynamicGridsColumns;

namespace TestingGrid
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Kontrolka_Loaded(object sender, RoutedEventArgs e)
        {
            Grupa g = new Grupa()
                          {
                              Pytania = new List<Pytanie>(),
                              Odpowiedzi = new List<List<Odpowiedz>>()
                          };

            Pytanie p1 = new Pytanie()
                             {
                                 Tresc = "Tresc Pytania 1",
                                 Odpowiedzi = new List<Odpowiedz>()
                                                  {
                                                      new Odpowiedz() {Tresc = "Tresc 11", Inne = "Inne11"},
                                                      new Odpowiedz() {Tresc = "Tresc 12", Inne = "Inne12"},
                                                      new Odpowiedz() {Tresc = "Tresc 13", Inne = "Inne13"},
                                                      new Odpowiedz() {Tresc = "Tresc 14", Inne = "Inne14"}
                                                  }
                             };


            Pytanie p2 = new Pytanie()
            {
                Tresc = "Tresc Pytania 2",
                Odpowiedzi = new List<Odpowiedz>()
                                                  {
                                                      new Odpowiedz() {Tresc = "Tresc 21", Inne = "Inne21"},
                                                      new Odpowiedz() {Tresc = "Tresc 22", Inne = "Inne22"},
                                                      new Odpowiedz() {Tresc = "Tresc 23", Inne = "Inne23"},
                                                      new Odpowiedz() {Tresc = "Tresc 24", Inne = "Inne24"},
                                                      new Odpowiedz() {Tresc = "Tresc 25", Inne = "Inne25"}
                                                  }
            };

            Pytanie p3 = new Pytanie()
            {
                Tresc = "Tresc Pytania 3",
                Odpowiedzi = new List<Odpowiedz>()
                                                  {
                                                      new Odpowiedz() {Tresc = "Tresc 31", Inne = "Inne31"},
                                                      new Odpowiedz() {Tresc = "Tresc 32", Inne = "Inne32"}
                                                  }
            };

            g.Pytania.Add(p1);
            g.Odpowiedzi.Add(p1.Odpowiedzi);
            
            g.Pytania.Add(p2);
            g.Odpowiedzi.Add(p2.Odpowiedzi);
            
            g.Pytania.Add(p3);
            g.Odpowiedzi.Add(p3.Odpowiedzi);

            var mainControl = sender as MainControl;

            if (mainControl != null)
            {
                mainControl.DataContext = g;
            } else
            {
                MessageBox.Show("Błąd przypisania dataContext");
            }
        }
    }
}
