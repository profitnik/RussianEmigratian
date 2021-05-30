using System;
using System.Collections.Generic;

namespace RussianEmigratian
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 0; // i счетчик ходов
            int age;   // Возраст пользователя
            string name; // Имя пользователя
            int action = 0; // Хранение действия
            bool gameOver = false; // Отлов окончания игры.


            Random rnd = new Random();
            Condition condition = new Condition();
            Finance finance = new Finance();

            // Код для напоминания работы со словарями
            //Asset str = new Asset();
            //foreach(KeyValuePair<string,int> f in str.asset_store)
            //{
            //    Console.WriteLine(f.Key);
            //}
            //str.Buy("Велосипед");
            //Console.WriteLine("  ");
            //Console.WriteLine("  ");
            //foreach (KeyValuePair<string, int> f in str.asset_store)
            //{
            //    Console.WriteLine(f.Key);
            //}
            //Console.WriteLine("  ");
            //Console.WriteLine("  ");
            //foreach (KeyValuePair<string, int> f in str.asset_person)
            //{
            //    Console.WriteLine(f.Key);
            //}

            Console.WriteLine("Привет, введи свое имя");
            name = Console.ReadLine();
            Console.WriteLine($"Отлично, {name}, а теперь введи свой возраст");

            if (int.TryParse(Console.ReadLine(), out age))
            {

                if (age < 16 || age > 100)
                {
                    gameOver = true;
                    Console.WriteLine("Игра для людей старше 16 лет и... младше 100");
                }

                if (gameOver == false)
                {
                    Console.WriteLine("Хорошо, тогда начнем... жми Enter");
                    Console.ReadLine();
                }
            }
            else
            {
                Console.WriteLine("Это не возраст. У тебя есть еще одна попытка ввести корректное значение"); ;
                if (int.TryParse(Console.ReadLine(), out age))
                {
                    if (age < 16 || age > 100)
                    {
                        gameOver = true;
                        Console.WriteLine("Игра для людей старше 16 лет и... младше 100");
                    }
                    if (gameOver == false)
                    {
                        Console.WriteLine("Хорошо, тогда начнем... жми Enter");
                        Console.ReadLine();
                    }
                }
                else
                {
                    Console.WriteLine("Вновь введен неверный возраст");
                    gameOver = true;
                }

            }

            for (; gameOver == false; i++)
            {
                finance.ChangeBankPercent(); // Автоматический прирост банковского депо на каждом шаге
                finance.ChangeInvestPercent(rnd.Next(-3, 3+1)); // Автоматическое изменение тела инвестиций на каждом шаге

                Console.WriteLine($"Здоровье: {condition.Helth} Энергия: {condition.Energy} Счастье: {condition.Happines}");
                Console.WriteLine($"Деньги: {finance.Money} Банк: {finance.Bank} Инвестиции: {finance.Invest}");
                Console.WriteLine("Твой следующий ход?");
                Console.WriteLine("1 - действие, 2 - финансы, 3 - эмиграция");

                if (int.TryParse(Console.ReadLine(), out action))
                {
                    if (action == 1) // Действие
                    {

                    }
                    if (action == 2) // Финансы
                    {
                        int actionFinance = 0;
                        Console.WriteLine("1 - банк: снять\\внести, 2 - инвестировать: снять\\внести, 3 - имущество");
                        while (!int.TryParse(Console.ReadLine(), out actionFinance) || (actionFinance != 1 && actionFinance != 2 && actionFinance != 3) )
                        {
                            Console.WriteLine("Нет такого действия. Нажми Enter и попробуй еще раз");
                            Console.ReadLine();
                            Console.WriteLine("1 - банк: снять\\внести, 2 - инвестировать: снять\\внести, 3 - имущество");
                        }

                        if (actionFinance == 1) // Банк: снять\\внести
                        {
                            Console.WriteLine("Снятие со знаком '-', внесение со знаком '+'");
                            Console.WriteLine("Введи целое число");
                            int moneyInOut = 0;
                            while (!int.TryParse(Console.ReadLine(), out moneyInOut) || !finance.ChangeBankAction(moneyInOut))
                            {
                                Console.WriteLine("Введите корректную сумму. Нажми Enter и попробуй еще раз");
                                Console.ReadLine();
                                Console.WriteLine("Снятие со знаком '-', внесение со знаком '+'");
                                Console.WriteLine("Сколько? Только целые числа");
                            }
                            finance.ChangeMoney(moneyInOut*(-1));
                        }
                        if (actionFinance == 2) // Инвестировать: снять\\внести
                        {
                            Console.WriteLine("Снятие со знаком '-', внесение со знаком '+'");
                            Console.WriteLine("Введи целое число");
                            int moneyInOut = 0;
                            while (!int.TryParse(Console.ReadLine(), out moneyInOut) || !finance.ChangeInvestAction(moneyInOut))
                            {
                                Console.WriteLine("Введите корректную сумму. Нажми Enter и попробуй еще раз");
                                Console.ReadLine();
                                Console.WriteLine("Снятие со знаком '-', внесение со знаком '+'");
                                Console.WriteLine("Сколько? Только целые числа");
                            }
                            finance.ChangeMoney(moneyInOut * (-1));
                        }
                        if (actionFinance == 3)
                        {
                            Console.WriteLine("Сколько?");
                            Console.ReadLine();
                        }
                    }
                    if (action == 3) // Эмиграция
                    {

                    }
                    if (action != 1 && action != 2 && action != 3)
                    {
                        Console.WriteLine("Нет такого действия. Нажми Enter и попробуй еще раз");
                        Console.ReadLine();
                        continue;
                    }
                }
                else
                {
                    Console.WriteLine("Нет такого действия. Нажми Enter и попробуй еще раз");
                    Console.ReadLine();
                    continue;
                }
            }



            Console.WriteLine($"Игра завершена.\nКоличество ходов {i}");
            Console.ReadLine();
        }
    }
}
