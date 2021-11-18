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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lernprogramm
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public void AllesVerstecken()
        {
            GridStartseite.Visibility = Visibility.Hidden;
            GridMenu.Visibility = Visibility.Hidden;
            GridSchwierigkeit.Visibility = Visibility.Hidden;
            GridAufgabenmenge.Visibility = Visibility.Hidden;
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            Titel.Text = "STARTSEITE";
            AllesVerstecken();
            GridStartseite.Visibility = Visibility.Visible;

            Start.Visibility = Visibility.Hidden;
            Menu.Visibility = Visibility.Hidden;
        }
        private void Menu_Click(object sender, RoutedEventArgs e)
        {
            Titel.Text = "MENÜ";
            AllesVerstecken();
            GridMenu.Visibility = Visibility.Visible;

            Start.Visibility = Visibility.Visible;
            Menu.Visibility = Visibility.Hidden;
        }

        private void ButtonStartseite_Click(object sender, RoutedEventArgs e)
        {
            Titel.Text = "MENÜ";
            AllesVerstecken();
            GridMenu.Visibility = Visibility.Visible;

            Start.Visibility = Visibility.Visible;
            Menu.Visibility = Visibility.Hidden;
        }

        private void PlusRechnen_Click(object sender, RoutedEventArgs e)
        {
            Titel.Text = "PLUS RECHNEN";
            AllesVerstecken();
            GridSchwierigkeit.Visibility = Visibility.Visible;

            Menu.Visibility = Visibility.Visible;
        }

        private void MinusRechnen_Click(object sender, RoutedEventArgs e)
        {
            Titel.Text = "MINUS RECHNEN";
            AllesVerstecken();
            GridSchwierigkeit.Visibility = Visibility.Visible;

            Menu.Visibility = Visibility.Visible;
        }

        private void ZahlenSortieren_Click(object sender, RoutedEventArgs e)
        {
            Titel.Text = "ZAHLEN SORTIEREN";
            AllesVerstecken();

            Menu.Visibility = Visibility.Visible;
        }

        private void Einfach_Click(object sender, RoutedEventArgs e)
        {
            AllesVerstecken();
            GridAufgabenmenge.Visibility = Visibility.Visible;
        }

        private void Mittel_Click(object sender, RoutedEventArgs e)
        {
            AllesVerstecken();
            GridAufgabenmenge.Visibility = Visibility.Visible;
        }

        private void Schwer_Click(object sender, RoutedEventArgs e)
        {
            AllesVerstecken();
            GridAufgabenmenge.Visibility = Visibility.Visible;
        }

        private void Aufgaben5_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Aufgaben10_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Aufgaben20_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
