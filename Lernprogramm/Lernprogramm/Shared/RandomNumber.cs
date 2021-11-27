using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lernprogramm.Shared
{
    public class RandomNumber
    {
        public int GetRandomNumber(int difficulty, int maxValue = 100)
        {
            Random rnd = new Random();
            switch (difficulty)
            {
                case 1:
                    maxValue = 10;
                    return rnd.Next(1, maxValue);
                case 2:
                    maxValue = 100;
                    return rnd.Next(10, maxValue);
                case 3:
                    maxValue = 100;
                    return rnd.Next(10, maxValue);
                default:
                    return 0;
            }
        }
    }
}
