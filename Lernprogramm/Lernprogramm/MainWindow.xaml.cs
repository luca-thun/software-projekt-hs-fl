﻿using System;
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
using System.Text.RegularExpressions;

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

        char rechenOperator;            // Nimmt entweder '+' oder '-' als Wert an
        int schwierigkeitsgrad;         // Nimmt 1, 2 oder 3 als Wert an
        int aufgabenmenge;              // Nimmt 5, 10 oder 20 als Wert an
        int rechenDurchlauf;

        Random zufall = new Random();

        int zahl1;                      //Wert der oberen Zahl im Rechentableau
        int zahl2;                      //Wert der unteren Zahl im Rechentableau

        int maxZahl2;                   //Nimmt den maximalen Wert an, den die zweite Zahl bekommen darf. Beispiel: Bekommt zahl1 den Wert 92 zufällig zugeteilt, darf zahl2 beim plusrechnen maximal den wert 8 bekommen.

        public void RechenTraining()
        {
            if (rechenOperator == '+')
            {
                Operator.Text = "+";
                PlusTraining();
            }
            else
            {
                Operator.Text = "-";
                MinusTraining();
            }
        }

        public void PlusTraining()
        {
            if (schwierigkeitsgrad == 1)
            {
                zahl1 = zufall.Next(1, 10);
                zahl2 = zufall.Next(1, 10);
            }
            if (schwierigkeitsgrad == 2)
            {
                zahl1 = zufall.Next(10, 100);
                maxZahl2 = 101 - zahl1;                 //maxzahl2 wird für wird für die obere Grenze der Zufallszahl verwendet, da der Wert der oberen Grenze nicht im Wertebereich ist, rechnen wir mit 101, anstatt mit 100
                zahl2 = zufall.Next(1, 10);             //zahl2 bekommt vorerst eine Zahl zwischen eins und neun zugewiesen

                if (zahl2 > maxZahl2)
                {
                    zahl2 = zufall.Next(1, maxZahl2);   //nur wenn das Ergebnis einen Wert über 100 hätte, bekommt zahl2 einen neuen, kleineren wert.
                }
            }
            if (schwierigkeitsgrad == 3)
            {
                zahl1 = zufall.Next(10, 91);             //nur Zahlen bis 90, da beide mindestens den Wert 10 haben sollen
                int maxZahl2 = 101 - zahl1;
                zahl2 = zufall.Next(10, 91);

                if (zahl2 > maxZahl2)
                {
                    zahl2 = zufall.Next(10, maxZahl2);   //nur wenn das Ergebnis einen Wert über 100 hätte, bekommt zahl2 einen neuen, kleineren wert.
                }
            }
            ObereZahl.Text = Convert.ToString(zahl1);
            UntereZahl.Text = Convert.ToString(zahl2);
        }

        public void MinusTraining()
        {

        }

        public void AllesVerstecken()
        {
            GridStartseite.Visibility = Visibility.Hidden;
            GridMenu.Visibility = Visibility.Hidden;
            GridSchwierigkeit.Visibility = Visibility.Hidden;
            GridAufgabenmenge.Visibility = Visibility.Hidden;
            GridRechenprogramm.Visibility = Visibility.Hidden;
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
            rechenOperator = '+';
        }

        private void MinusRechnen_Click(object sender, RoutedEventArgs e)
        {
            Titel.Text = "MINUS RECHNEN";
            AllesVerstecken();
            GridSchwierigkeit.Visibility = Visibility.Visible;

            Menu.Visibility = Visibility.Visible;
            rechenOperator = '-';
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

            schwierigkeitsgrad = 1;
        }

        private void Mittel_Click(object sender, RoutedEventArgs e)
        {
            AllesVerstecken();
            GridAufgabenmenge.Visibility = Visibility.Visible;

            schwierigkeitsgrad = 2;
        }

        private void Schwer_Click(object sender, RoutedEventArgs e)
        {
            AllesVerstecken();
            GridAufgabenmenge.Visibility = Visibility.Visible;

            schwierigkeitsgrad = 3;
        }

        private void Aufgaben5_Click(object sender, RoutedEventArgs e)
        {
            AllesVerstecken();
            GridRechenprogramm.Visibility = Visibility.Visible;

            aufgabenmenge = 5;
            RechenTraining();
        }

        private void Aufgaben10_Click(object sender, RoutedEventArgs e)
        {
            AllesVerstecken();
            GridRechenprogramm.Visibility = Visibility.Visible;

            aufgabenmenge = 15;
            RechenTraining();
        }

        private void Aufgaben20_Click(object sender, RoutedEventArgs e)
        {
            AllesVerstecken();
            GridRechenprogramm.Visibility = Visibility.Visible;

            aufgabenmenge = 20;
            RechenTraining();
        }

        private void ErgebnisEingabe_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void WeiterRechnen_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
