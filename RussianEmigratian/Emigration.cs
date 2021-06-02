using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RussianEmigratian
{
    
    class Emigration
    {
        public void SetDiagrammeLanguage(int language)
        {
            Console.WriteLine("");
            int part = language / 5;
            if (part == 20)
            {
                Console.Write("√ Язык.\n" +
                    "Уровень " + language + "\\100  ");
                
            }

            if (part < 20)
            {
                Console.Write("X Язык.\n" +
                    "Уровень " + language + "\\100  ");
            }

            string loading = "█ ";
            for (int k = 0; k < part; k++)
            {
                Console.Write(loading);
                Thread.Sleep(50);
            }
            Console.WriteLine();
        }

        public void SetDiagrammeMoney(int money)
        {
            Console.WriteLine("");
            int part = 0;
            if (money <= 1000000)
            {
                part = money / 50000;
            }
            else part = 20;

            if (part == 20)
            {
                Console.Write("√ Деньги\n" +
                    "" + money + "\\1 млн.   ");
                
            }

            if (part < 20)
            {
                Console.Write("X Деньги\n" +
                    "" + money + "\\1 млн.  ");
            }

            string loading = "█ ";
            for (int k = 0; k < part; k++)
            {
                Console.Write(loading);
                Thread.Sleep(50);
            }
            Console.WriteLine();
            Console.WriteLine();
        }

        public bool GetStatus(int language, int money)
        {
            if (language == 100 && money == 1000000)
            {
                return true;
            }
            else return false;
        }
    }
}
