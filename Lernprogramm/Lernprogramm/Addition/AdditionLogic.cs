using Lernprogramm.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lernprogramm.Addition
{
    public static class AdditionLogic
    {
        public static string OperatorText => "+";

        public static int Number1;

        public static int Number2;

        public static int DifficultyLvl;

        public static int Quantity;

        public static int CorrectCount;

        public static int WrongCount;

        public static bool LoadNextTask()
        {
            return (WrongCount + CorrectCount) < Quantity ? true : false;
        }

        public static void GenerateAdditionNumbers()
        {       
            int[] numbers = new int[2] {0,0};

            // Zahlen ziehen nach Schwierigkeitsgrad
            var rnd = new RandomNumber();
            switch (DifficultyLvl)
            {
                // Leicht: Bis max. 10
                case 1:
                    numbers[0] = rnd.GetRandomNumber(1);
                    numbers[1] = rnd.GetRandomNumber(1);
                    break;
                // Mittel: Zahl 1 bis 10, Zahl 2 größer 10 bis max. 100
                case 2:
                    numbers[0] = rnd.GetRandomNumber(1);
                    numbers[1] = rnd.GetRandomNumber(2);
                    break;
                // Schwer: Zahl 1 größer 10, Zahl 2 größer 10 bis max. 100
                case 3:
                    numbers[0] = rnd.GetRandomNumber(2,91);
                    numbers[1] = rnd.GetRandomNumber(2);
                    break;
            }

            // 100er Grenze nicht überschreiten
            if (numbers[0] + numbers[1] > 100)
            {
                // Obere Grenze für Addition bis 100
                int maxValue = 101 - numbers[0];    
                numbers[1] = rnd.GetRandomNumber(2, maxValue);
            }

            Number1 = numbers[0];
            Number2 = numbers[1];
        }

        /// <summary>
        /// Überprüft, ob das eingegebene Ergebnis der Addition korrekt ist.
        /// </summary>
        /// <param name="inputResult">Zu überprüfendes Ergebnis</param>
        /// <returns>TRUE, wenn das Ergebnis korrekt ist</returns>
        public static bool CheckAddition(int inputResult)
        {
            return inputResult == (Number1 + Number2);
        }
    }
}
