using System;

namespace RussianEmigratian
{
    class Leisure
    {
        int[] conditionChange = new int[4];
        // [0] - здоровье
        // [1] - счастье
        // [2] - энергия
        // [3] - деньги
        GamblingGame gambling = new GamblingGame();

        public int[] Sleep()
        {
            conditionChange[0] = 1;
            conditionChange[1] = 1;
            conditionChange[2] = 1;

            return (conditionChange);
        }
        public int[] Walk()
        {
            conditionChange[0] = 1;
            conditionChange[1] = 1;
            conditionChange[2] = -1;

            return (conditionChange);
        }
        public int[] Sport()
        {
            conditionChange[0] = 2;
            conditionChange[1] = 1;
            conditionChange[2] = -3;

            return (conditionChange);
        }
        public int[] Bar()
        {
            conditionChange[0] = -1;
            conditionChange[1] = 2;
            conditionChange[2] = -1;

            return (conditionChange);
        }
        public int[] VideoGame()
        {
            conditionChange[0] = -1;
            conditionChange[1] = 2;
            conditionChange[2] = -1;

            return (conditionChange);
        }
        public int[] Gambling(int game)
        {
            Console.WriteLine("В какую игру сыграем?");
            Console.WriteLine("1 - Красное\\Черное, 2 - Пять\\Шесть, 3 - Выше\\Ниже");
            int game_select = 0;
            while (!int.TryParse(Console.ReadLine(), out game_select) || game_select < 1 || game_select > 3)
            {
                Console.WriteLine("Нет такого действия. Нажми Enter и попробуй еще раз");
                Console.ReadLine();
                Console.WriteLine("В какую игру сыграем?");
                Console.WriteLine("1 - Красное\\Черное, 2 - Пять\\Шесть, 3 - Выше\\Ниже");
            }
            conditionChange[0] = -1;
            conditionChange[1] = 2;
            conditionChange[2] = -1;

            if (game == 1)
            {
                Console.WriteLine("На что и сколько ставим?");
                Console.WriteLine("Если на черное и ставка 100, то впиши ч100");
                string clr_read = Console.ReadLine();
                int clr_set = -1;
                int bet_set = -1;

                //if (!int.TryParse(clr_read.Substring(0), out bet_set) || )
                //{
                //    if (clr_read.IndexOf("ч") != -1) clr_set = 1;
                //    if (clr_read.IndexOf("к") != -1) clr_set = 0;
                //}



                int game_rb = 0;
                while (!int.TryParse(Console.ReadLine(), out game_rb) || game_rb < 1 || game_rb > 3)
                {
                    Console.WriteLine("Нет такого действия. Нажми Enter и попробуй еще раз");
                    Console.ReadLine();
                    Console.WriteLine("В какую игру сыграем?");
                    Console.WriteLine("1 - Красное\\Черное, 2 - Пять\\Шесть, 3 - Выше\\Ниже");
                }
                // gambling.RedBlack();
            }

            return (conditionChange);
        }
    }
}