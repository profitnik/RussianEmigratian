using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RussianEmigratian
{
    class GamblingGame
    {
        Random rnd = new Random();
        public int RedBlack(int clr,int summ) //Красное черное
        {
            // clr: 0 - красное, 1 - черное
            int result = 0;
            
            int num = rnd.Next(0, 2);

            if (num == 0 && clr == 0)
            {
                result = summ * 2;
                Console.WriteLine("");
                Console.WriteLine($"√ Выпало КРАСНОЕ. Ты выиграл {result/2}");
                Console.WriteLine("");
            }
            if (num == 0 && clr == 1)
            {
                // Ставка вычитается на уровне проверки корретности ввода
                Console.WriteLine("");
                Console.WriteLine($"X Выпало КРАСНОЕ. Ты проиграл {summ}");
                Console.WriteLine("");
            }

            if (num == 1 && clr == 1)
            {
                result = summ * 2;
                Console.WriteLine("");
                Console.WriteLine($"√ Выпало ЧЕРНОЕ. Ты выиграл {result/2}");
                Console.WriteLine("");
            }
            if (num == 1 && clr == 0)
            {
                // Ставка вычитается на уровне проверки корретности ввода
                Console.WriteLine("");
                Console.WriteLine($"X Выпало ЧЕРНОЕ. Ты проиграл {summ}");
                Console.WriteLine("");
            }

            return (result);
        }

        public int FiveSix(int summ)
        {
            int result = 0;
            int numOne = rnd.Next(1, 7);
            int numTwo = rnd.Next(1, 7);

            string one_one = "";
            string one_two = "";
            string one_thr = "";

            if (numOne == 1)
            {
                one_one = "+++++";
                one_two = "++о++";
                one_thr = "+++++";
            }
            if (numOne == 2)
            {
                one_one = "+++++";
                one_two = "+о+о+";
                one_thr = "+++++";
            }
            if (numOne == 3)
            {
                one_one = "++++о";
                one_two = "++о++";
                one_thr = "о++++";
            }
            if (numOne == 4)
            {
                one_one = "+о+о+";
                one_two = "+++++";
                one_thr = "+о+о+";
            }
            if (numOne == 5)
            {
                one_one = "+о+о+";
                one_two = "++о++";
                one_thr = "+о+о+";
            }
            if (numOne == 6)
            {
                one_one = "+о+о+";
                one_two = "+о+о+";
                one_thr = "+о+о+";
            }

            string two_one = "";
            string two_two = "";
            string two_thr = "";

            if (numTwo == 1)
            {
                two_one = "+++++";
                two_two = "++о++";
                two_thr = "+++++";
            }
            if (numTwo == 2)
            {
                two_one = "+++++";
                two_two = "+о+о+";
                two_thr = "+++++";
            }
            if (numTwo == 3)
            {
                two_one = "++++о";
                two_two = "++о++";
                two_thr = "о++++";
            }
            if (numTwo == 4)
            {
                two_one = "+о+о+";
                two_two = "+++++";
                two_thr = "+о+о+";
            }
            if (numTwo == 5)
            {
                two_one = "+о+о+";
                two_two = "++о++";
                two_thr = "+о+о+";
            }
            if (numTwo == 6)
            {
                two_one = "+о+о+";
                two_two = "+о+о+";
                two_thr = "+о+о+";
            }

            string final_one;
            string final_two;
            string final_thr;

            final_one = one_one + "  " + two_one;
            final_two = one_two + "  " + two_two;
            final_thr = one_thr + "  " + two_thr;

            Console.WriteLine("");
            Console.WriteLine(final_one);
            Console.WriteLine(final_two);
            Console.WriteLine(final_thr);
            Console.WriteLine("");

            if (numOne == 5 || numTwo == 5 || numOne == 6 || numTwo == 6)
            {
                // Ставка вычитается на уровне проверки корретности ввода
                Console.WriteLine("X Ты проиграл");
                Console.WriteLine("");
            }
            else
            {
                result = summ * 2;
                Console.WriteLine("√ Ты выиграл");
                Console.WriteLine("");
            }

            return (result);
        }
        public int UpDown(int number, int summ) //Красное черное
        {
            // number: 1 - ниже, 2 - выше
            int result = 0;
            int num = 0;
            Random rnd_two = new Random();
            if (rnd_two.Next(0, 2) == 0)
            {
                num = rnd.Next(0, 49);
            } else num = rnd.Next(52, 101);



            if (num < 49 && number == 1)
            {
                result = summ * 2;
                Console.WriteLine("");
                Console.WriteLine($"√ Выпало число {num}. Ты выиграл {result / 2}");
                Console.WriteLine("");
            }
            if (num < 49 && number == 2)
            {
                // Ставка вычитается на уровне проверки корретности ввода
                Console.WriteLine("");
                Console.WriteLine($"X Выпало число {num}. Ты проиграл {summ}");
                Console.WriteLine("");
            }

            if (num > 51 && number == 2)
            {
                result = summ * 2;
                Console.WriteLine("");
                Console.WriteLine($"√ Выпало число {num}. Ты выиграл {result / 2}");
                Console.WriteLine("");
            }
            if (num > 51 && number == 1)
            {
                // Ставка вычитается на уровне проверки корретности ввода
                Console.WriteLine("");
                Console.WriteLine($"X Выпало число {num}. Ты проиграл {summ}");
                Console.WriteLine("");
            }
            if(num > 48 && num < 52)
            {
                result = summ;
                Console.WriteLine("");
                Console.WriteLine($"X Выпало число {num}. Ставка в {summ} была возращена");
                Console.WriteLine("");
            }

            return (result);
        }
    }
}
