using System;
using System.Collections.Generic;
using System.Linq;

namespace RussianEmigratian
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 1; // i счетчик ходов
            int age;   // Возраст пользователя
            string name; // Имя пользователя
            int action = 0; // Хранение действия
            bool gameOver = false; // Отлов окончания игры.
            int[] conditionEffect = new int[3]; // Хранение значений, которые влияют на состояние через действия досуга
            int[] conditionEffectWork = new int[4]; // Хранение значений, которые влияют на состояние через действия работы
            int mandoryPayments = -1000; // Обязательные платежи буду списываться каждый день (ход). Число выбрано исходя из общих месячных
                                         // платеже в размере 20 000 рублей. 20 000 / 31 = 645
            int minusHappines = -1; // Вычитание счастья на каждом ходу

            Random rnd = new Random();
            Condition condition = new Condition();
            Finance finance = new Finance();
            Asset asset = new Asset();
            Leisure leisure = new Leisure();
            GamblingGame gambling = new GamblingGame();
            Emigration emigration = new Emigration();
            Education skill = new Education();
            Work work = new Work();

            Console.WriteLine("Привет, введи свое имя и нажми Enter");
            name = Console.ReadLine();
            Console.WriteLine($"Отлично, {name}, а теперь введи свой возраст и нажми Enter");

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
                        Console.WriteLine("Хорошо, тогда начнем...");

                    }
                }
                else
                {
                    Console.WriteLine("Вновь введен неверный возраст");
                    gameOver = true;
                }

            }

            if (gameOver == false)
            {
                int rules;
                Console.WriteLine("Посмотришь правила? Выбери один из пунктов, указав его цифру, а затем нажми Enter");
                Console.WriteLine("1 - инструкции для слабаков, 2 - хочу узнать механику игры");
                while (!int.TryParse(Console.ReadLine(), out rules) || (rules != 1 && rules != 2))
                {
                    Console.WriteLine("Действие невозможно. Нажми Enter и попробуй еще раз");
                    Console.ReadLine();
                    Console.WriteLine("Посмотришь правила?");
                    Console.WriteLine("1 - инструкции для слабаков, 2 - хочу узнать немного истории");
                }
                if (rules == 1)
                {
                    Console.WriteLine("Окей. Начали.");
                }
                if (rules == 2)
                {

                    Console.WriteLine("------------------------");
                    Console.WriteLine("Итак...сегодня " + DateTime.Today.ToShortDateString() +
                         "\nТы работаешь курьером и снимаешь квартиру.\n" +
                        "Ничем особо не выделяешься: никаких навыков, никакого имущества - только 30 000 наличкой.\n" +
                        "Каждый ход с тебя снимается 1000. Это проживание и еда.\n" +
                        "Если твои карманы будут пусты - игра закончится.\n \n" +
                        "Также внимательно следи за уровнем здоровья, счастья и энергии.\n" +
                        "Если уронишь их до нуля - игра тоже подойдет к логичному концу.\n" +
                        "Каждый ход с тебя снимается 1 очко счастья. Такова жизнь, сынок \n \n" +
                        "К чему все это? Ты хочешь свалить за бугор.\n" +
                        "Для этого нужно изучить язык на 100% и накопить 1 000 000. \n" +
                        "Чем быстрее это сделаешь, тем больше тебе респекта.\n" +
                        "Работай, учись, трать свободное время с пользой, и ты больше не увидишь этих \"панелек\".Fvbym"); ;
                    Console.WriteLine("------------------------");
                    Console.WriteLine("Жми Enter и повоюем");
                    Console.ReadLine();
                }


            }

            // Основной цикл игры
            for (; gameOver == false; i++)
            {

                finance.ChangeBankPercent(); // Автоматический прирост банковского депо на каждом шаге

                int minInvest = 0;
                int maxInvest = 0;
                // Диапазон доходности по инвестициям в зависимости от навыка "инвестор"
                if (skill.InvestorSkill <= 20)
                {
                    minInvest = -4;
                    maxInvest = 5;
                }
                if (skill.InvestorSkill > 20 && skill.InvestorSkill <= 40)
                {
                    minInvest = -3;
                    maxInvest = 5;
                }
                if (skill.InvestorSkill > 40 && skill.InvestorSkill <= 60)
                {
                    minInvest = -2;
                    maxInvest = 5;
                }
                if (skill.InvestorSkill > 60 && skill.InvestorSkill <= 80)
                {
                    minInvest = -1;
                    maxInvest = 5;
                }
                if (skill.InvestorSkill > 80 && skill.InvestorSkill <= 100)
                {
                    minInvest = 0;
                    maxInvest = 5;
                }
                finance.ChangeInvestPercent(rnd.Next(minInvest, maxInvest)); // Автоматическое изменение тела инвестиций на каждом шаге

                int ratioGambling = 0;
                // Выиграш ставки в азартных играх в зависимости от навыка "игрок"
                if (skill.GamblingSkill <= 50)
                {
                    ratioGambling = 2;
                }
                if (skill.InvestorSkill > 50)
                {
                    ratioGambling = 3;
                }


                Console.WriteLine("");
                Console.WriteLine($"Номер хода: {i}");
                Console.WriteLine("----------------------------------------");
                Console.WriteLine($"Здоровье: {condition.Helth} Энергия: {condition.Energy} Счастье: {condition.Happines}");
                Console.WriteLine($"Деньги: {finance.Money} Банк: {finance.Bank} Инвестиции: {finance.Invest}");
                Console.WriteLine("----------------------------------------");
                Console.WriteLine("");
                Console.WriteLine("Твой следующий ход?");
                Console.WriteLine("1 - действие, 2 - финансы, 3 - эмиграция");

                while (!int.TryParse(Console.ReadLine(), out action) || action < 1 || action > 3)
                {
                    Console.WriteLine("Действие невозможно. Нажми Enter и попробуй еще раз");
                    Console.ReadLine();
                    Console.WriteLine("");
                    Console.WriteLine("----------------------------------------");
                    Console.WriteLine($"Здоровье: {condition.Helth} Энергия: {condition.Energy} Счастье: {condition.Happines}");
                    Console.WriteLine($"Деньги: {finance.Money} Банк: {finance.Bank} Инвестиции: {finance.Invest}");
                    Console.WriteLine("----------------------------------------");
                    Console.WriteLine("");
                    Console.WriteLine("Твой следующий ход?");
                    Console.WriteLine("1 - действие, 2 - финансы, 3 - эмиграция");

                }

                if (action == 1) // ДЕЙСТВИЕ
                {
                    Console.WriteLine("");
                    int actionFree = 0;
                    Console.WriteLine("1 - досуг, 2 - работа, 3 - покупки");
                    while (!int.TryParse(Console.ReadLine(), out actionFree) || (actionFree != 1 && actionFree != 2 && actionFree != 3))
                    {
                        Console.WriteLine("Действие невозможно. Нажми Enter и попробуй еще раз");
                        Console.ReadLine();
                        Console.WriteLine("1 - досуг, 2 - работа, 3 - покупки");
                    }
                    if (actionFree == 1) // Досуг
                    {
                        Console.WriteLine("");
                        int actionLeisure = 0;
                        Console.WriteLine("1 - сон\n" +
                                        "2 - прогулка\n" +
                                        "3 - спорт\n" +
                                        "4 - бар\n" +
                                        "5 - видеоигры\n" +
                                        "6 - азартные игры");
                        while (!int.TryParse(Console.ReadLine(), out actionLeisure) || actionLeisure < 1 || actionLeisure > 6)
                        {
                            Console.WriteLine("Действие невозможно. Нажми Enter и попробуй еще раз");
                            Console.ReadLine();
                            Console.WriteLine("1 - сон\n" +
                                "2 - прогулка\n"+
                                "3 - спорт\n" +
                                "4 - бар\n" +
                                "5 - видеоигры\n" +
                                "6 - азартные игры");
                        }

                        switch (actionLeisure)
                        {
                            case 1:
                                conditionEffect = leisure.Sleep();
                                if (asset.asset_person.ContainsKey("Удобная кровать"))
                                {
                                    condition.SetHelth(conditionEffect[0] + 2);
                                    condition.SetHappines(conditionEffect[1] + 2);
                                    condition.SetEnergy(conditionEffect[2] + 2);
                                    Console.WriteLine("");
                                    Console.WriteLine($"Здоровье: {conditionEffect[0] + 2}");
                                    Console.WriteLine($"Счастье: {conditionEffect[1] + 2}");
                                    Console.WriteLine($"Энергия: {conditionEffect[2] + 2}");
                                    Console.WriteLine("");
                                }
                                else
                                {
                                    condition.SetHelth(conditionEffect[0]);
                                    condition.SetHappines(conditionEffect[1]);
                                    condition.SetEnergy(conditionEffect[2]);
                                    Console.WriteLine("");
                                    Console.WriteLine($"Здоровье: {conditionEffect[0]}");
                                    Console.WriteLine($"Счастье: {conditionEffect[1]}");
                                    Console.WriteLine($"Энергия: {conditionEffect[2]}");
                                    Console.WriteLine("");
                                }

                                Console.WriteLine("Жизнь и сновидения – страницы одной и той же книги");
                                Console.WriteLine("Жми Enter и продолжим");
                                Console.ReadLine();
                                break;
                            case 2:
                                conditionEffect = leisure.Walk();
                                condition.SetHelth(conditionEffect[0]);
                                condition.SetHappines(conditionEffect[1]);
                                condition.SetEnergy(conditionEffect[2]);
                                Console.WriteLine("");
                                Console.WriteLine($"Здоровье: {conditionEffect[0]}");
                                Console.WriteLine($"Счастье: {conditionEffect[1]}");
                                Console.WriteLine($"Энергия: {conditionEffect[2]}");
                                Console.WriteLine("");
                                Console.WriteLine("Если гуляешь безо всякой цели, гуляй там, где красиво");
                                Console.WriteLine("Жми Enter и продолжим");
                                Console.ReadLine();
                                break;
                            case 3:
                                conditionEffect = leisure.Sport();
                                condition.SetHelth(conditionEffect[0]);
                                condition.SetHappines(conditionEffect[1]);
                                condition.SetEnergy(conditionEffect[2]);
                                Console.WriteLine("");
                                Console.WriteLine($"Здоровье: {conditionEffect[0]}");
                                Console.WriteLine($"Счастье: {conditionEffect[1]}");
                                Console.WriteLine($"Энергия: {conditionEffect[2]}");
                                Console.WriteLine("");
                                Console.WriteLine("Спорт – лекарство от плохого настроения и депрессий");
                                Console.WriteLine("Жми Enter и продолжим");
                                Console.ReadLine();
                                break;
                            case 4:
                                if (finance.Money > 1000)
                                {
                                    conditionEffect = leisure.Bar();
                                    condition.SetHelth(conditionEffect[0]);
                                    condition.SetHappines(conditionEffect[1]);
                                    condition.SetEnergy(conditionEffect[2]);
                                    Console.WriteLine("");
                                    Console.WriteLine($"Здоровье: {conditionEffect[0]}");
                                    Console.WriteLine($"Счастье: {conditionEffect[1]}");
                                    Console.WriteLine($"Энергия: {conditionEffect[2]}");
                                    Console.WriteLine("");
                                    Console.WriteLine("Ты круто провел время, но не бесплатно. Потрачено 1000");
                                    finance.ChangeMoney(-1000);
                                    Console.WriteLine("Жми Enter и продолжим");
                                    Console.ReadLine();
                                }
                                else
                                {
                                    Console.WriteLine("Не хватает денег, чтобы погулять. Требуется 1000");
                                    Console.WriteLine("Жми Enter и продолжим");
                                }
                                break;
                            case 5:
                                if (asset.asset_person.ContainsKey("Playstation") == true)
                                {
                                    conditionEffect = leisure.VideoGame();
                                    condition.SetHelth(conditionEffect[0]);
                                    condition.SetHappines(conditionEffect[1]);
                                    condition.SetEnergy(conditionEffect[2]);
                                    Console.WriteLine("");
                                    Console.WriteLine($"Здоровье: {conditionEffect[0]}");
                                    Console.WriteLine($"Счастье: {conditionEffect[1]}");
                                    Console.WriteLine($"Энергия: {conditionEffect[2]}");
                                    Console.WriteLine("");
                                    Console.WriteLine("Я уже говорил тебе, что такое безумие? Безумие — это...");
                                    Console.WriteLine("Жми Enter и продолжим");
                                }
                                else
                                {
                                    Console.WriteLine("Сначала купи Playstation. Жми Enter и отправляйся в магазин");
                                    Console.ReadLine();
                                }
                                break;
                            case 6:
                                Console.WriteLine("");
                                Console.WriteLine("В какую игру сыграем?");
                                Console.WriteLine("1 - Красное\\Черное, 2 - Пять\\Шесть, 3 - Выше\\Ниже");
                                int game_select = 0;
                                while (!int.TryParse(Console.ReadLine(), out game_select) || game_select < 1 || game_select > 3)
                                {
                                    Console.WriteLine("Действие невозможно. Нажми Enter и попробуй еще раз");
                                    Console.ReadLine();
                                    Console.WriteLine("В какую игру сыграем?");
                                    Console.WriteLine("1 - Красное\\Черное, 2 - Пять\\Шесть, 3 - Выше\\Ниже");
                                }

                                if (game_select == 1)
                                {

                                    while (true)
                                    {
                                        conditionEffect = leisure.Gambling();
                                        condition.SetHelth(conditionEffect[0]);
                                        condition.SetHappines(conditionEffect[1]);
                                        condition.SetEnergy(conditionEffect[2]);

                                        Console.WriteLine("Правила игры: тебе предлагается поставить на какой-либо цвет - красный или черный.\n" +
                                            "Просто выбирай цвет и размер ставки. Затем генератор случайных чисел генерирует цвет.\n" +
                                            "Если он совпал с выбранным тобой, получаешь свой выигрыш.\n" +
                                            "Все как на рулетке.");
                                        Console.WriteLine("");
                                        Console.WriteLine("так... на что и сколько ставим?");
                                        Console.WriteLine("Если на черное и ставка 100, то впиши ч100");
                                        string bet = Console.ReadLine();
                                        int clr_set = -1;
                                        int summ_set = -1;

                                        if (bet.IndexOf("ч") != -1 || bet.IndexOf("Ч") != -1) clr_set = 1;
                                        if (bet.IndexOf("к") != -1 || bet.IndexOf("К") != -1) clr_set = 0;
                                        //Console.WriteLine(bet.IndexOf("к") + "  " + clr_set);
                                        while (!int.TryParse(bet.Substring(1, bet.Length - 1), out summ_set) || clr_set == -1 || !finance.ChangeMoney(summ_set * (-1)))
                                        {
                                            Console.WriteLine("Некорретный ввод.");
                                            Console.WriteLine("Если хочешь поставить 100 на черное, просто впиши ч100, на красное - к100");
                                            Console.WriteLine("Введи ставку еще раз прямо сейчас");
                                            bet = Console.ReadLine();
                                            if (bet.IndexOf("ч") != -1 || bet.IndexOf("Ч") != -1) clr_set = 1;
                                            if (bet.IndexOf("к") != -1 || bet.IndexOf("К") != -1) clr_set = 0;

                                        }
                                        finance.ChangeMoney(gambling.RedBlack(clr_set, summ_set, ratioGambling));
                                        if (finance.Money > 1)
                                        {
                                            int again;
                                            Console.WriteLine("Сыграем еще раз?");
                                            Console.WriteLine("1 - да, 2  - нет");
                                            while (!int.TryParse(Console.ReadLine(), out again) || (again != 1 && again != 2))
                                            {
                                                Console.WriteLine("Действие невозможно. Нажми Enter и попробуй еще раз");
                                                Console.ReadLine();
                                                Console.WriteLine("Сыграем еще раз?");
                                                Console.WriteLine("1 - да, 2  - нет");
                                            }
                                            if (again == 2) break;
                                        }
                                        else
                                        {
                                            Console.WriteLine("Твои карманы пусты. Иди, заработай");
                                            Console.WriteLine("");
                                            break;
                                        }
                                    }
                                }
                                if (game_select == 2)
                                {
                                    while (true)
                                    {
                                        conditionEffect = leisure.Gambling();
                                        condition.SetHelth(conditionEffect[0]);
                                        condition.SetHappines(conditionEffect[1]);
                                        condition.SetEnergy(conditionEffect[2]);
                                        Console.WriteLine("Правила игры: c помощью генератора случайных чисел бросаем 2 шестигранных кубика.\n" +
                                            "Если ни на одном из кубиков не выпадет 5 или 6, получаешь свой выигрыш.\n" +
                                            "Если хотя бы на одном кубике выпадет 5 или 6, ты проиграешь.");
                                        Console.WriteLine("");
                                        Console.WriteLine("так... ну, сколько ставим? Просто напиши число");
                                        int bet;
                                        while (!int.TryParse(Console.ReadLine(), out bet) || !finance.ChangeMoney(bet * (-1)))
                                        {
                                            Console.WriteLine("Действие невозможно. Нажми Enter и попробуй еще раз");
                                            Console.ReadLine();
                                            Console.WriteLine("так... ну, сколько ставим? Просто напиши число");
                                        }

                                        finance.ChangeMoney(gambling.FiveSix(bet, ratioGambling));
                                        if (finance.Money > 1)
                                        {
                                            int again;
                                            Console.WriteLine("Сыграем еще раз?");
                                            Console.WriteLine("1 - да, 2  - нет");
                                            while (!int.TryParse(Console.ReadLine(), out again) || (again != 1 && again != 2))
                                            {
                                                Console.WriteLine("Действие невозможно. Нажми Enter и попробуй еще раз");
                                                Console.ReadLine();
                                                Console.WriteLine("Сыграем еще раз?");
                                                Console.WriteLine("1 - да, 2  - нет");
                                            }
                                            if (again == 2) break;
                                        }
                                        else
                                        {
                                            Console.WriteLine("Твои карманы пусты. Иди, заработай");
                                            Console.WriteLine("");
                                            break;
                                        }

                                    }
                                }
                                if (game_select == 3)
                                {
                                    while (true)
                                    {
                                        conditionEffect = leisure.Gambling();
                                        condition.SetHelth(conditionEffect[0]);
                                        condition.SetHappines(conditionEffect[1]);
                                        condition.SetEnergy(conditionEffect[2]);
                                        Console.WriteLine("Правила игры: c помощью генератора случайных чисел машина выбирает число в диапазоне от 0 до 100.\n" +
                                            "У тебя есть возможность сделать ставку на два события:\n" +
                                            "новое число будет в диапазоне от 0 до 48 или оно будет в диапазоне от 52 до 100.\n" +
                                            "Если отгадаешь диапазон, получаешь свой выигрыш.\n" +
                                            "Если выпадает число в диапазоне от 49 до 51, ставка просто возвращается.");
                                        Console.WriteLine("");
                                        Console.WriteLine("Чтобы выберешь?");
                                        Console.WriteLine("1 - ниже 49, 2 - выше 51");
                                        int bet;
                                        while (!int.TryParse(Console.ReadLine(), out bet) || (bet != 1 && bet != 2))
                                        {
                                            Console.WriteLine("Действие невозможно. Нажми Enter и попробуй еще раз");
                                            Console.ReadLine();
                                            Console.WriteLine("Чтобы выберешь?");
                                            Console.WriteLine("1 - ниже 49, 2 - выше 51");
                                        }
                                        int betTwo;
                                        Console.WriteLine("Сколько поставишь?");
                                        while (!int.TryParse(Console.ReadLine(), out betTwo) || !finance.ChangeMoney(betTwo * (-1)))
                                        {
                                            Console.WriteLine("Действие невозможно. Нажми Enter и попробуй еще раз");
                                            Console.ReadLine();
                                            Console.WriteLine("Сколько поставишь?");
                                        }

                                        finance.ChangeMoney(gambling.UpDown(bet, betTwo, ratioGambling));
                                        if (finance.Money > 1)
                                        {
                                            int again;
                                            Console.WriteLine("Сыграем еще раз?");
                                            Console.WriteLine("1 - да, 2  - нет");
                                            while (!int.TryParse(Console.ReadLine(), out again) || (again != 1 && again != 2))
                                            {
                                                Console.WriteLine("Действие невозможно. Нажми Enter и попробуй еще раз");
                                                Console.ReadLine();
                                                Console.WriteLine("Сыграем еще раз?");
                                                Console.WriteLine("1 - да, 2  - нет");
                                            }
                                            if (again == 2) break;
                                        }
                                        else
                                        {
                                            Console.WriteLine("Твои карманы пусты. Иди заработай");
                                            Console.WriteLine("");
                                            break;
                                        }
                                    }
                                }
                                break;

                        }

                    }//------------------
                    if (actionFree == 2) // Работа
                    {
                        Console.WriteLine("");
                        int actionFreeWork = 0;
                        Console.WriteLine("1 - поиск работы, 2 - пойти на работу");
                        while (!int.TryParse(Console.ReadLine(), out actionFreeWork) || (actionFreeWork != 1 && actionFreeWork != 2))
                        {
                            Console.WriteLine("Действие невозможно. Нажми Enter и попробуй еще раз");
                            Console.ReadLine();
                            Console.WriteLine("1 - поиск работы, 2 - пойти на работу");
                        }

                        if (actionFreeWork == 1)
                        {
                            Console.WriteLine("");
                            Console.WriteLine("Выбери работу свой мечты. Только для некоторых профессий нужен навык.");
                            if (work.MyWork.ElementAt(0).Key != "Бандит")
                            {
                                Console.WriteLine($"Твоя текущая должность " + work.MyWork.ElementAt(0).Key + ". Зарплата " + work.MyWork.ElementAt(0).Value);
                            }
                            else Console.WriteLine($"Твоя текущая должность " + work.MyWork.ElementAt(0).Key + ". Зарплата бывает по-разному");
                            Console.WriteLine("");
                            int k = 1;
                            Console.WriteLine("0 - не менять работу");
                            foreach (KeyValuePair<string, int> profes in work.AllWork)
                            {
                                if (profes.Key != "Бандит")
                                {
                                    Console.WriteLine(k + " - " + profes.Key + ". Зарплата : " + profes.Value);
                                }
                                else
                                {
                                    Console.WriteLine(k + " - " + profes.Key + ". Зарплата : бывает по разному. Можешь даже потерять");
                                }
                                k++;
                            }

                            int workChoice = 0;
                            while (!int.TryParse(Console.ReadLine(), out workChoice) || workChoice < 0 || workChoice > work.AllWork.Count())
                            {
                                Console.WriteLine("Действие невозможно. Нажми Enter и попробуй еще раз");
                                Console.ReadLine();
                                Console.WriteLine("0 - не менять работу");
                                k = 1;
                                foreach (KeyValuePair<string, int> profes in work.AllWork)
                                {
                                    if (profes.Key != "Бандит")
                                    {
                                        Console.WriteLine(k + " - " + profes.Key + ". Зарплата : " + profes.Value);
                                    }
                                    else
                                    {
                                        Console.WriteLine(k + " - " + profes.Key + ". Зарплата : бывает по разному. Можешь даже потерять");
                                    }
                                    k++;
                                }
                            }

                            if (workChoice != 0)
                            {
                                string workYes = work.AllWork.ElementAt(workChoice - 1).Key;

                                if (workYes == "Курьер")
                                {
                                    work.ChoiseWork(workYes);
                                }
                                if (workYes == "Менеджер")
                                {
                                    if (skill.ManagerSkill == 100)
                                    {
                                        work.ChoiseWork(workYes);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Не хватает навыка. Жми Enter и иди учись");
                                        Console.ReadLine();
                                        //continue;
                                    }
                                }
                                if (workYes == "Разработчик")
                                {
                                    if (skill.DeveloperSkill == 100)
                                    {
                                        if (asset.asset_person.ContainsKey("Ноутбук") == true)
                                        {
                                            work.ChoiseWork(workYes);
                                        }
                                        else
                                        {
                                            Console.WriteLine("Еще нужен ноутбук... ты думаешь, это игра создана на телефоне?\n" +
                                                "Жми Enter и отправляйся в магазин");
                                            Console.ReadLine();
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Не хватает навыка. Жми Enter и иди учись");
                                        Console.ReadLine();
                                        //continue;
                                    }
                                }
                                if (workYes == "Бандит")
                                {

                                    if (asset.asset_person.ContainsKey("Оружие") == true)
                                    {
                                        work.ChoiseWork(workYes);
                                    }
                                    else
                                    {
                                        Console.WriteLine("");
                                        Console.WriteLine("Нужно бы прикупить оружие... жми Enter и отправляйся магазин");
                                        Console.ReadLine();
                                        //continue;
                                    }
                                }

                            }
                        }
                        if (actionFreeWork == 2)
                        {

                            conditionEffectWork = work.Working();


                            condition.SetHelth(conditionEffectWork[1]);
                            condition.SetHappines(conditionEffectWork[2]);
                            condition.SetEnergy(conditionEffectWork[3]);
                            Console.WriteLine("");

                            switch (work.MyWork.ElementAt(0).Key)
                            {
                                case "Курьер":
                                    if (asset.asset_person.ContainsKey("Велосипед") == true && asset.asset_person.ContainsKey("Машина") == false)
                                    {
                                        finance.ChangeMoney(conditionEffectWork[0] + 500);
                                        Console.WriteLine($">>> Заработано +{conditionEffectWork[0]} + 500 за работу на велосипеде. Так держать. Жми Enter");
                                        Console.ReadLine();
                                    }
                                    if (asset.asset_person.ContainsKey("Велосипед") == false && asset.asset_person.ContainsKey("Машина") == false)
                                    {
                                        finance.ChangeMoney(conditionEffectWork[0]);
                                        Console.WriteLine($">>> Заработано +{conditionEffectWork[0]}. Так держать. Жми Enter");
                                        Console.ReadLine();
                                    }
                                    if ((asset.asset_person.ContainsKey("Велосипед") == false && asset.asset_person.ContainsKey("Машина") == true)
                                        || (asset.asset_person.ContainsKey("Велосипед") == true && asset.asset_person.ContainsKey("Машина") == true))
                                    {
                                        finance.ChangeMoney(conditionEffectWork[0] + 1000);
                                        Console.WriteLine($">>> Заработано +{conditionEffectWork[0]} + 1000 за работу на машине. Так держать. Жми Enter");
                                        Console.ReadLine();
                                    }
                                    break;
                                case "Менеджер":
                                    if (asset.asset_person.ContainsKey("Брендовая одежда"))
                                    {
                                        finance.ChangeMoney(conditionEffectWork[0] + 1500);
                                        Console.WriteLine($">>> Заработано +{conditionEffectWork[0]} + 1500 за брендовый шмот. Так держать. Жми Enter");
                                        Console.ReadLine();
                                    }
                                    else
                                    {
                                        finance.ChangeMoney(conditionEffectWork[0]);
                                        Console.WriteLine($">>> Заработано +{conditionEffectWork[0]}. Так держать. Жми Enter");
                                        Console.ReadLine();
                                    }
                                    break;
                                default:
                                    Console.WriteLine($">>> Заработано +{conditionEffectWork[0]}. Так держать. Жми Enter");
                                    Console.ReadLine();
                                    break;
                            }


                        }
                    }
                    if (actionFree == 3) // Покупки
                    {
                        Console.WriteLine("");
                        int actionFreeBuy = 0;
                        Console.WriteLine("1 - обучение, 2 - имущество");
                        while (!int.TryParse(Console.ReadLine(), out actionFreeBuy) || (actionFreeBuy != 1 && actionFreeBuy != 2))
                        {
                            Console.WriteLine("Действие невозможно. Нажми Enter и попробуй еще раз");
                            Console.ReadLine();
                            Console.WriteLine("1 - обучение, 2 - имущество");
                        }

                        if (actionFreeBuy == 1)
                        {
                            Console.WriteLine("");
                            int education = 0;
                            Console.WriteLine("0 - Статус обучения");
                            Console.WriteLine($"1 - Менеджер Цена: {skill.PriceManager*(-1)}\n" +
                                            $"2 - Разработчик Цена: {skill.PriceDeveloper * (-1)}\n" +
                                            $"3 - Инвестор Цена: {skill.PriceInvestor * (-1)}\n" +
                                            $"4 - Игрок Цена: {skill.PriceGambling * (-1)}\n" +
                                            $"5 - Иностранный язык Цена: {skill.PriceLanguage * (-1)}");
                            while (!int.TryParse(Console.ReadLine(), out education) || education < 0 || education > 5)
                            {
                                Console.WriteLine("Действие невозможно. Нажми Enter и попробуй еще раз");
                                Console.ReadLine();
                                Console.WriteLine("0 - Статус обучения");
                                Console.WriteLine($"1 - Менеджер Цена: {skill.PriceManager * (-1)}\n" +
                                                $"2 - Разработчик Цена: {skill.PriceDeveloper * (-1)}\n" +
                                                $"3 - Инвестор Цена: {skill.PriceInvestor * (-1)}\n" +
                                                $"4 - Игрок Цена: {skill.PriceGambling * (-1)}\n" +
                                                $"5 - Иностранный язык Цена: {skill.PriceLanguage * (-1)}");
                            }

                            switch (education)
                            {
                                case 0:
                                    skill.GetSkills();
                                    Console.WriteLine("");
                                    Console.WriteLine("Жми Enter и продолжим");
                                    Console.ReadLine();
                                    continue;
                                case 1:
                                    if (finance.ChangeMoney(skill.PriceManager))
                                    {
                                        skill.LearningSkill(1);
                                    }
                                    break;
                                case 2:
                                    if (finance.ChangeMoney(skill.PriceDeveloper))
                                    {
                                        skill.LearningSkill(2);
                                    }
                                    break;
                                case 3:
                                    if (finance.ChangeMoney(skill.PriceInvestor))
                                    {
                                        skill.LearningSkill(3);
                                    }
                                    break;
                                case 4:
                                    if (finance.ChangeMoney(skill.PriceGambling))
                                    {
                                        skill.LearningSkill(4);
                                    }
                                    break;
                                case 5:
                                    if (finance.ChangeMoney(skill.PriceLanguage))
                                    {
                                        skill.LearningSkill(5);
                                    }
                                    break;
                                default: break;
                            }

                            Console.WriteLine("");
                            Console.WriteLine("Век живи - век учись! Жми Enter и продолжим");
                            Console.ReadLine();
                        }
                        if (actionFreeBuy == 2) // Покупка имущества
                        {
                            Console.WriteLine("");
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
                                    Console.WriteLine("Действие невозможно. Нажми Enter и попробуй еще раз");
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
                                        if (asker == "Машина")
                                        {
                                            mandoryPayments -= 500;
                                            Console.WriteLine("Машина требует обслуживания.\n" +
                                                $"Обязательные платежи на каждом ходу увеличины на 500 и теперь составляют {mandoryPayments}");
                                            Console.WriteLine("Жми Enter и продолжим");
                                            Console.ReadLine();

                                        }
                                        asset.Buy(asker);
                                    }
                                }
                                //else continue;
                            }
                            else
                            {
                                Console.WriteLine("Уже все куплено. Жми Enter");
                                Console.ReadLine();
                                //continue;
                            }
                        }
                    }
                }
                if (action == 2) // ФИНАНСЫ
                {
                    Console.WriteLine("");
                    int actionFinance = 0;
                    Console.WriteLine("1 - банк: снять\\внести\n" +
                        "2 - инвестировать: снять\\внести\n" +
                        "3 - имущество");
                    while (!int.TryParse(Console.ReadLine(), out actionFinance) || (actionFinance != 1 && actionFinance != 2 && actionFinance != 3))
                    {
                        Console.WriteLine("Действие невозможно. Нажми Enter и попробуй еще раз");
                        Console.ReadLine();
                        Console.WriteLine("1 - банк: снять\\внести\n" +
                                        "2 - инвестировать: снять\\внести\n" +
                                        "3 - имущество");
                    }

                    if (actionFinance == 1) // Банк: снять\\внести
                    {
                        Console.WriteLine("");
                        Console.WriteLine($"Всего отложено: {finance.allInvest}");
                        Console.WriteLine($"Всего изъято: {finance.allTaken}");
                        Console.WriteLine("");
                        Console.WriteLine("Снятие со знаком '-', внесение со знаком '+'");
                        Console.WriteLine("Введи целое число");
                        int moneyInOut = 0;
                        while (!int.TryParse(Console.ReadLine(), out moneyInOut) || moneyInOut > finance.Money || !finance.ChangeBankAction(moneyInOut))
                        {
                            Console.WriteLine("Такой суммы нет. Нажми Enter и попробуй еще раз");
                            Console.ReadLine();
                            Console.WriteLine("Снятие со знаком '-', внесение со знаком '+'");
                            Console.WriteLine("Сколько? Только целые числа");
                        }
                        finance.ChangeMoney(moneyInOut * (-1));
                    }
                    if (actionFinance == 2) // Инвестировать: снять\\внести
                    {
                        Console.WriteLine("");
                        Console.WriteLine($"Всего инвестировано: {finance.allInvest}");
                        Console.WriteLine($"Всего изъято: {finance.allTaken}");
                        Console.WriteLine("");
                        Console.WriteLine("Снятие со знаком '-', внесение со знаком '+'");
                        Console.WriteLine("Введи целое число");
                        int moneyInOut = 0;
                        while (!int.TryParse(Console.ReadLine(), out moneyInOut) || moneyInOut > finance.Money || !finance.ChangeInvestAction(moneyInOut))
                        {
                            Console.WriteLine("Такой суммы нет. Нажми Enter и попробуй еще раз");
                            Console.ReadLine();
                            Console.WriteLine("Снятие со знаком '-', внесение со знаком '+'");
                            Console.WriteLine("Сколько? Только целые числа");
                        }
                        finance.ChangeMoney(moneyInOut * (-1));
                    }
                    if (actionFinance == 3) // Продать имущество
                    {
                        Console.WriteLine("");
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
                                Console.WriteLine("Действие невозможно. Нажми Enter и попробуй еще раз");
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
                                if (asker == "Машина")
                                {
                                    Console.WriteLine("");
                                    mandoryPayments += 500;
                                    Console.WriteLine($"Обязательные платежи на каждом ходу уменьшены 500 и теперь составляют {mandoryPayments}");
                                    Console.WriteLine("Жми Enter и продолжим");
                                    Console.ReadLine();
                                }
                                asset.Sell(asker);
                            }
                            //else continue;
                        }
                        else
                        {
                            Console.WriteLine("");
                            Console.WriteLine("Нет имущества. Жми Enter");
                            Console.ReadLine();
                            //continue;
                        }
                    }
                }
                if (action == 3) // ЭМИГРАЦИЯ
                {
                    Console.WriteLine("");
                    if (emigration.GetStatus(skill.LanguageSkill, finance.Money + finance.Bank + finance.Invest) == false)
                    {
                        emigration.SetDiagrammeLanguage(skill.LanguageSkill);
                        emigration.SetDiagrammeMoney(finance.Money + finance.Bank + finance.Invest);
                        Console.WriteLine("");
                        Console.WriteLine("Не впечатляет? Продолжай. Жми Enter");
                        Console.ReadLine();
                        continue; // Уходим на следующий цикл игры, ничего не снимая с пользователя.
                    }
                    else
                    {
                        emigration.SetDiagrammeLanguage(skill.LanguageSkill);
                        emigration.SetDiagrammeMoney(finance.Money + finance.Bank + finance.Invest);
                        Console.WriteLine("Что ж... ты полностью готов смотать удочки и рвануть за бугор.\n" +
                            "Покупаем билет и летим?");
                        Console.WriteLine("1 - купить билет, собрать вещи и смотаться быстрей, 2 - нет, пожалуй, я останусь, все не так плохо");
                        int choise = 0;

                        while (!int.TryParse(Console.ReadLine(), out choise) || (choise != 1 && choise != 2))
                        {
                            Console.WriteLine("Действие невозможно. Нажми Enter и попробуй еще раз");
                            Console.ReadLine();
                            Console.WriteLine("1 - купить билет, собрать вещи и смотаться быстрей, 2 - нет, пожалуй, я останусь, все не так плохо");
                        }

                        if (choise == 1) Console.WriteLine("Удачного полета. Тебя ждет новая жизнь!");
                        if (choise == 2) Console.WriteLine("Тоже выбор. Достоин уважения. Успехов!");
                        break;
                    }


                }

                // Механика банкротства и ежедневного списания обязательных платежей
                if (finance.Money <= 0)
                {
                    if (finance.Bank > mandoryPayments * (-1))
                    {
                        Console.WriteLine("Не хватает денег на еду и крышу... если ты сейчас не снимешь деньги с банковского счета,\n" +
                            "то игра закончится.");
                        if (finance.ChangeMoney(mandoryPayments) == false)
                        {
                            break;
                        }
                    }
                    else
                    {
                        if (finance.Invest > mandoryPayments * (-1))
                        {
                            Console.WriteLine("Не хватает денег на еду и крышу... если ты сейчас не снимешь деньги с инвестиций,\n" +
                                              "то игра закончится.");
                            if (finance.ChangeMoney(mandoryPayments) == false)
                            {
                                break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Ты банкрот. Ни банковских накоплений, ни инвестиционных...\n" +
                                "Неужели ты хочешь провести свой остаток дней там, где находишься? Лучше попробуй еще раз.");
                            break;
                        }
                    }



                }
                else finance.ChangeMoney(mandoryPayments);

                //----------------------------------------------------------------------------

                if (condition.Helth < 1)
                {

                    Console.WriteLine("Здоровье не бесконечно, и оно закончилось. Это самое главное, о чем нужно заботиться.");
                    break;
                }

                if (condition.Happines > 0)
                {
                    condition.SetHappines(minusHappines);
                }
                else
                {
                    Console.WriteLine(condition.Happines);
                    Console.WriteLine("Умереть от депрессии... не самый приятный выход. Следи за уровнем своего счастья.");
                    break;
                }


                if (condition.Energy < 1)
                {
                    Console.WriteLine("Ты выгорел. Нет больше ни сил, ни желаний. Следи за уровнем своей энергии");
                    break;
                }

            }



            Console.WriteLine($"Игра завершена.\nКоличество ходов {i}");
            Console.ReadLine();
        }
    }


}
