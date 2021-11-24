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
        int rechenDurchlauf;            // Zählt mit wie viele Aufgaben schon gerechnet wurden
        int richtigGelöst;              // Zählt mit wie viele Aufgaben davon richtig gelöst wurden

        Random zufall = new Random();

        int zahl1;                      //Wert der oberen Zahl im Rechentableau
        int zahl2;                      //Wert der unteren Zahl im Rechentableau
        int maxZahl2;                   //Nimmt den maximalen Wert an, den die zweite Zahl bekommen darf. Beispiel: Bekommt zahl1 den Wert 92 zufällig zugeteilt, darf zahl2 beim plusrechnen maximal den wert 8 bekommen.
        int[] falschGerechnet1 = new int[20];
        int array1Zähler;
        int[] falschGerechnet2 = new int[20];
        int array2Zähler;

        int zahlenSortieren1;
        int zahlenSortieren2;
        int zahlenSortieren3;
        int zahlenSortieren4;
        int zahlenSortieren5;
        int zahlenSortieren6;
        int zahlenSortieren7;
        int zahlenSortieren8;
        int zahlenSortieren9;
        int zahlenSortieren10;

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
            GridLeistungsübersicht.Visibility = Visibility.Hidden;
            GridMinispiel.Visibility = Visibility.Hidden;
            GridZahlenSortieren.Visibility = Visibility.Hidden;
        }

        public void VariablenZurücksetzen()
        {
            rechenOperator = '+';
            schwierigkeitsgrad = 0;
            aufgabenmenge = 0;
            rechenDurchlauf = 0;
            richtigGelöst = 0;
            zahl1 = 0;
            zahl2 = 0;
            maxZahl2 = 0;
            zahlenSortieren1 = 0;
            zahlenSortieren2 = 0;
            zahlenSortieren3 = 0;
            zahlenSortieren4 = 0;
            zahlenSortieren5 = 0;
            zahlenSortieren6 = 0;
            zahlenSortieren7 = 0;
            zahlenSortieren8 = 0;
            zahlenSortieren9 = 0;
            zahlenSortieren10 = 0;
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            Titel.Text = "STARTSEITE";
            AllesVerstecken();
            GridStartseite.Visibility = Visibility.Visible;

            Start.Visibility = Visibility.Hidden;
            Menu.Visibility = Visibility.Hidden;

            VariablenZurücksetzen();
        }
        private void Menu_Click(object sender, RoutedEventArgs e)
        {
            Titel.Text = "MENÜ";
            AllesVerstecken();
            GridMenu.Visibility = Visibility.Visible;

            Start.Visibility = Visibility.Visible;
            Menu.Visibility = Visibility.Hidden;

            VariablenZurücksetzen();
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
            GridZahlenSortieren.Visibility = Visibility.Visible;
            zahlenSortierenGenerieren();

            Menu.Visibility = Visibility.Visible;
        }

        public void zahlenSortierenGenerieren()
        {
            zahlenSortieren1 = zufall.Next(1, 101);

            while (zahlenSortieren2 == 0 || zahlenSortieren2 == zahlenSortieren1)
                zahlenSortieren2 = zufall.Next(1, 101);
            while (zahlenSortieren3 == 0 || zahlenSortieren3 == zahlenSortieren1 || zahlenSortieren3 == zahlenSortieren2)
                zahlenSortieren3 = zufall.Next(1, 101);
            while (zahlenSortieren4 == 0 || zahlenSortieren4 == zahlenSortieren1 || zahlenSortieren4 == zahlenSortieren2 || zahlenSortieren4 == zahlenSortieren3)
                zahlenSortieren4 = zufall.Next(1, 101);
            while (zahlenSortieren5 == 0 || zahlenSortieren5 == zahlenSortieren1 || zahlenSortieren5 == zahlenSortieren2 || zahlenSortieren5 == zahlenSortieren3 || zahlenSortieren5 == zahlenSortieren4)
                zahlenSortieren5 = zufall.Next(1, 101);
            while (zahlenSortieren6 == 0 || zahlenSortieren6 == zahlenSortieren1 || zahlenSortieren6 == zahlenSortieren2 || zahlenSortieren6 == zahlenSortieren3 || zahlenSortieren6 == zahlenSortieren4 || zahlenSortieren6 == zahlenSortieren5)
                zahlenSortieren6 = zufall.Next(1, 101);
            while (zahlenSortieren7 == 0 || zahlenSortieren7 == zahlenSortieren1 || zahlenSortieren7 == zahlenSortieren2 || zahlenSortieren7 == zahlenSortieren3 || zahlenSortieren7 == zahlenSortieren4 || zahlenSortieren7 == zahlenSortieren5 || zahlenSortieren7 == zahlenSortieren6)
                zahlenSortieren7 = zufall.Next(1, 101);
            while (zahlenSortieren8 == 0 || zahlenSortieren8 == zahlenSortieren1 || zahlenSortieren8 == zahlenSortieren2 || zahlenSortieren8 == zahlenSortieren3 || zahlenSortieren8 == zahlenSortieren4 || zahlenSortieren8 == zahlenSortieren5 || zahlenSortieren8 == zahlenSortieren6 || zahlenSortieren8 == zahlenSortieren7)
                zahlenSortieren8 = zufall.Next(1, 101);
            while (zahlenSortieren9 == 0 || zahlenSortieren9 == zahlenSortieren1 || zahlenSortieren9 == zahlenSortieren2 || zahlenSortieren9 == zahlenSortieren3 || zahlenSortieren9 == zahlenSortieren4 || zahlenSortieren9 == zahlenSortieren5 || zahlenSortieren9 == zahlenSortieren6 || zahlenSortieren9 == zahlenSortieren7 || zahlenSortieren9 == zahlenSortieren8)
                zahlenSortieren9 = zufall.Next(1, 101);
            while (zahlenSortieren10 == 0 || zahlenSortieren10 == zahlenSortieren1 || zahlenSortieren10 == zahlenSortieren2 || zahlenSortieren10 == zahlenSortieren3 || zahlenSortieren10 == zahlenSortieren4 || zahlenSortieren10 == zahlenSortieren5 || zahlenSortieren10 == zahlenSortieren6 || zahlenSortieren10 == zahlenSortieren7 || zahlenSortieren10 == zahlenSortieren8 || zahlenSortieren10 == zahlenSortieren9)
                zahlenSortieren10 = zufall.Next(1, 101);

            Sortieren1.Content = Convert.ToString(zahlenSortieren1);
            Sortieren2.Content = Convert.ToString(zahlenSortieren2);
            Sortieren3.Content = Convert.ToString(zahlenSortieren3);
            Sortieren4.Content = Convert.ToString(zahlenSortieren4);
            Sortieren5.Content = Convert.ToString(zahlenSortieren5);
            Sortieren6.Content = Convert.ToString(zahlenSortieren6);
            Sortieren7.Content = Convert.ToString(zahlenSortieren7);
            Sortieren8.Content = Convert.ToString(zahlenSortieren8);
            Sortieren9.Content = Convert.ToString(zahlenSortieren9);
            Sortieren10.Content = Convert.ToString(zahlenSortieren10);
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
            if (rechenOperator == '+' && rechenDurchlauf < aufgabenmenge)       //Das passiert beim Plusrechenen
            {
                if (Convert.ToString(zahl1 + zahl2) == ErgebnisEingabe.Text)
                {
                    LobTextRechnen.Visibility = Visibility.Visible;
                    LobText.Text = "Richtig!";
                    ErgebnisEingabe.Text = "";

                    richtigGelöst++;
                    rechenDurchlauf++;

                    RechenTraining();
                }
                else
                {
                    LobTextRechnen.Visibility = Visibility.Visible;
                    LobText.Text = "Leider nicht richtig!";
                    ErgebnisEingabe.Text = "";

                    falschGerechnet1[array1Zähler] = zahl1;
                    array1Zähler++;
                    falschGerechnet2[array2Zähler] = zahl2;
                    array1Zähler++;

                    rechenDurchlauf++;

                    RechenTraining();
                }
            }

            if (rechenOperator == '-' && rechenDurchlauf < aufgabenmenge)       //Das passiert beim Minusrechnen
            {
                if (Convert.ToString(zahl1 - zahl2) == ErgebnisEingabe.Text)
                {
                    LobTextRechnen.Visibility = Visibility.Visible;
                    LobText.Text = "Richtig!";
                    ErgebnisEingabe.Text = "";

                    richtigGelöst++;
                    rechenDurchlauf++;

                    RechenTraining();
                }
                else
                {
                    LobTextRechnen.Visibility = Visibility.Visible;
                    LobText.Text = "Leider nicht richtig!";
                    ErgebnisEingabe.Text = "";

                    falschGerechnet1[array1Zähler] = zahl1;
                    array1Zähler++;
                    falschGerechnet2[array2Zähler] = zahl2;
                    array1Zähler++;

                    rechenDurchlauf++;

                    RechenTraining();
                }
            }

            if (rechenDurchlauf == aufgabenmenge && falschGerechnet1[0] != 0)
            {
                ObereZahl.Text = Convert.ToString(falschGerechnet1[0]);
                UntereZahl.Text = Convert.ToString(falschGerechnet2[0]);
            }

            if (rechenDurchlauf == aufgabenmenge && falschGerechnet1[0] == 0)
            {
                Titel.Text = "LEISTUNGSÜBERSICHT";
                AllesVerstecken();
                GridLeistungsübersicht.Visibility = Visibility.Visible;
                LeistungText.Text = "Du hast " + richtigGelöst + " von " + aufgabenmenge + " Aufgaben richtig gelöst";
            }
        }

        private void ButtonMinispiel_Click(object sender, RoutedEventArgs e)
        {
            Titel.Text = "MINISPIEL";
            AllesVerstecken();

            GridMinispiel.Visibility = Visibility.Visible;
        }

        private void Weg1_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Weg2_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Weg3_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Sortieren1_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Sortieren2_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Sortieren3_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Sortieren4_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Sortieren5_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Sortieren6_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Sortieren7_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Sortieren8_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Sortieren9_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Sortieren10_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
