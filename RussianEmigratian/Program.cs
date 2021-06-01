using System;
using System.Collections.Generic;
using System.Linq;

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
            int[] coditionEffect = new int[4]; // Хранение значений, которые влияют на состояние через действия досуга


            Random rnd = new Random();
            Condition condition = new Condition();
            Finance finance = new Finance();
            Asset asset = new Asset();
            Leisure leisure = new Leisure();
            GamblingGame gambling = new GamblingGame();

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
                finance.ChangeInvestPercent(rnd.Next(-3, 3 + 1)); // Автоматическое изменение тела инвестиций на каждом шаге

                Console.WriteLine($"Здоровье: {condition.Helth} Энергия: {condition.Energy} Счастье: {condition.Happines}");
                Console.WriteLine($"Деньги: {finance.Money} Банк: {finance.Bank} Инвестиции: {finance.Invest}");
                Console.WriteLine("Твой следующий ход?");
                Console.WriteLine("1 - действие, 2 - финансы, 3 - эмиграция");

                if (int.TryParse(Console.ReadLine(), out action))
                {
                    if (action == 1) // ДЕЙСТВИЕ
                    {
                        int actionFree = 0;
                        Console.WriteLine("1 - досуг, 2 - работа, 3 - покупки");
                        while (!int.TryParse(Console.ReadLine(), out actionFree) || (actionFree != 1 && actionFree != 2 && actionFree != 3))
                        {
                            Console.WriteLine("Нет такого действия. Нажми Enter и попробуй еще раз");
                            Console.ReadLine();
                            Console.WriteLine("1 - досуг, 2 - работа, 3 - покупки");
                        }
                        if (actionFree == 1) // Досуг
                        {
                            int actionLeisure = 0;
                            Console.WriteLine("1 - сон, 2 - прогулка, 3 - спорт, 4 - бар, 5 - видеоигры, 6 - азартные игры");
                            while (!int.TryParse(Console.ReadLine(), out actionLeisure) || actionLeisure < 1 || actionLeisure > 6)
                            {
                                Console.WriteLine("Нет такого действия. Нажми Enter и попробуй еще раз");
                                Console.ReadLine();
                                Console.WriteLine("1 - сон, 2 - прогулка, 3 - спорт, 4 - бар, 5 - видеоигры, 6 - азартные игры");
                            }

                            switch(actionLeisure)
                            {
                                case 1:
                                    coditionEffect = leisure.Sleep();
                                    condition.SetHelth(coditionEffect[0]);
                                    condition.SetHappines(coditionEffect[1]);
                                    condition.SetEnergy(coditionEffect[2]);
                                    break;
                                case 2:
                                    coditionEffect = leisure.Walk();
                                    condition.SetHelth(coditionEffect[0]);
                                    condition.SetHappines(coditionEffect[1]);
                                    condition.SetEnergy(coditionEffect[2]);
                                    break;
                                case 3:
                                    coditionEffect = leisure.Sport();
                                    condition.SetHelth(coditionEffect[0]);
                                    condition.SetHappines(coditionEffect[1]);
                                    condition.SetEnergy(coditionEffect[2]);
                                    break;
                                case 4:
                                    coditionEffect = leisure.Bar();
                                    condition.SetHelth(coditionEffect[0]);
                                    condition.SetHappines(coditionEffect[1]);
                                    condition.SetEnergy(coditionEffect[2]);
                                    break;
                                case 5:
                                    coditionEffect = leisure.VideoGame();
                                    condition.SetHelth(coditionEffect[0]);
                                    condition.SetHappines(coditionEffect[1]);
                                    condition.SetEnergy(coditionEffect[2]);
                                    break;
                                case 6:
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

                                    if(game_select == 1)
                                    {
                                        Console.WriteLine("На что и сколько ставим?");
                                        Console.WriteLine("Если на черное и ставка 100, то впиши ч100");
                                        string bet = Console.ReadLine();
                                        int clr_set = -1;
                                        int summ_set = -1;

                                        if (bet.IndexOf("ч") != -1 || bet.IndexOf("Ч") != -1) clr_set = 1;
                                        if (bet.IndexOf("к") != -1 || bet.IndexOf("К") != -1) clr_set = 0;
                                        //string pf = bet.Substring(1,bet.Length-1);
                                        //Console.WriteLine(pf);
                                        //while (!int.TryParse(bet.Substring(0,1), out summ_set) || clr_set == -1 || finance.ChangeMoney(summ_set*(-1)) == false)
                                        //{
                                            
                                        //    Console.WriteLine("Некорретный ввод.");
                                        //    Console.WriteLine("Если хочешь поставить 100 на черное, просто впиши ч100, на красное - к100");
                                        //    Console.WriteLine("Введи ставку еще раз прямо сейчас");
                                        //    bet = Console.ReadLine();
                                        //    if (bet.IndexOf("ч") != -1 || bet.IndexOf("Ч") != -1) clr_set = 1;
                                        //    if (bet.IndexOf("к") != -1 || bet.IndexOf("К") != -1) clr_set = 0;

                                        //}
                                        //finance.ChangeMoney(gambling.RedBlack(clr_set, summ_set));
                                        
                                    }
                                    break;
                                
                            }
                            
                        }//------------------
                        if (actionFree == 2) // Работа
                        {

                        }
                        if (actionFree == 3) // Покупки
                        {
                            int actionFreeBuy = 0;
                            Console.WriteLine("1 - обучение, 2 - имущество");
                            while (!int.TryParse(Console.ReadLine(), out actionFreeBuy) || (actionFreeBuy != 1 && actionFreeBuy != 2))
                            {
                                Console.WriteLine("Нет такого действия. Нажми Enter и попробуй еще раз");
                                Console.ReadLine();
                                Console.WriteLine("1 - обучение, 2 - имущество");
                            }

                            if (actionFreeBuy == 1)
                            {

                            }
                            if (actionFreeBuy == 2) // Покупка имущества
                            {
                                if (asset.asset_store.Count() != 0)
                                {
                                    int k = 0;
                                    Console.WriteLine("0 - Ничего не покупать");
                                    foreach (KeyValuePair<string, int> item in asset.asset_store)
                                    {
                                        k++;
                                        Console.WriteLine(k.ToString() + " - " + item.Key + " " + item.Value);

                                    }
                                    int buyAsset = 0;
                                    while (!int.TryParse(Console.ReadLine(), out buyAsset) || buyAsset < 0 || buyAsset > k)
                                    {
                                        Console.WriteLine(k.ToString() + "  " + buyAsset.ToString());
                                        Console.WriteLine("Нет такого действия. Нажми Enter и попробуй еще раз");
                                        Console.ReadLine();
                                        k = 0;
                                        Console.WriteLine("0 - Ничего не покупать");
                                        foreach (KeyValuePair<string, int> item in asset.asset_store)
                                        {
                                            k++;
                                            Console.WriteLine(k.ToString() + " - " + item.Key + " " + item.Value);
                                        }
                                    }
                                    if (buyAsset != 0)
                                    {
                                        if (finance.ChangeMoney((asset.asset_store.ElementAt(buyAsset - 1).Value) * (-1)))
                                        {
                                            string asker = asset.asset_store.ElementAt(buyAsset - 1).Key;
                                            asset.Buy(asker);
                                        }
                                    }
                                    else continue;
                                }
                                else
                                {
                                    Console.WriteLine("Уже все куплено. Жми Enter");
                                    Console.ReadLine();
                                    continue;
                                }
                            }
                        }
                    }
                    if (action == 2) // ФИНАНСЫ
                    {
                        int actionFinance = 0;
                        Console.WriteLine("1 - банк: снять\\внести, 2 - инвестировать: снять\\внести, 3 - имущество");
                        while (!int.TryParse(Console.ReadLine(), out actionFinance) || (actionFinance != 1 && actionFinance != 2 && actionFinance != 3))
                        {
                            Console.WriteLine("Нет такого действия. Нажми Enter и попробуй еще раз");
                            Console.ReadLine();
                            Console.WriteLine("1 - банк: снять\\внести, 2 - инвестировать: снять\\внести, 3 - продать имущество");
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
                            finance.ChangeMoney(moneyInOut * (-1));
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
                        if (actionFinance == 3) // Продать имущество
                        {
                            if (asset.asset_person.Count() != 0)
                            {
                                int k = 0;
                                Console.WriteLine("0 - Ничего не продавать");
                                foreach (KeyValuePair<string, int> item in asset.asset_person)
                                {
                                    k++;
                                    Console.WriteLine(k.ToString() + " - " + item.Key + " " + Convert.ToInt32(item.Value).ToString());
                                }
                                int sellAsset = 0;
                                while (!int.TryParse(Console.ReadLine(), out sellAsset) || sellAsset < 0 || sellAsset > k)
                                {
                                    Console.WriteLine(k.ToString() + "  " + sellAsset.ToString());
                                    Console.WriteLine("Нет такого действия. Нажми Enter и попробуй еще раз");
                                    Console.ReadLine();
                                    k = 0;
                                    Console.WriteLine("0 - Ничего не покупать");
                                    foreach (KeyValuePair<string, int> item in asset.asset_store)
                                    {
                                        k++;
                                        Console.WriteLine(k.ToString() + " - " + item.Key + " " + Convert.ToInt32(item.Value).ToString());
                                    }
                                }
                                if (sellAsset != 0)
                                {
                                    finance.ChangeMoney(asset.asset_person.ElementAt(sellAsset - 1).Value);
                                    string asker = asset.asset_person.ElementAt(sellAsset - 1).Key;
                                    asset.Sell(asker);
                                }
                                else continue;
                            }
                            else
                            {
                                Console.WriteLine("Нет имущества. Жми Enter");
                                Console.ReadLine();
                                continue;
                            }
                        }
                    }
                    if (action == 3) // ЭМИГРАЦИЯ
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
