using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RussianEmigratian
{
    class GamblingGame
    {
        public int RedBlack(int clr,int summ) //Красное черное
        {
            // clr: 0 - красное, 1 - черное
            int result = 0;
            Random rnd = new Random();

            if(rnd.Next(0,2) == 0 && clr == 0)
            {
                result = summ * 2;
                Console.WriteLine($"Выпало красное. Вы выиграли {result}");
            }
            if (rnd.Next(0, 2) == 0 && clr == 1)
            {
                result = summ * 2*(-1);
                Console.WriteLine($"Выпало красное. Вы проиграли {result}");
            }

            if (rnd.Next(0, 2) == 1 && clr == 1)
            {
                result = summ * 2;
                Console.WriteLine($"Выпало черное. Вы выиграли {result}");
            }
            if (rnd.Next(0, 2) == 1 && clr == 0)
            {
                result = summ * 2 * (-1);
                Console.WriteLine($"Выпало черное. Вы проиграли {result}");
            }

            return (result);
        }
    }
}
