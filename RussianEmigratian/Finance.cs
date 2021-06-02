using System;

namespace RussianEmigratian
{
    class Finance
    {
        private double BankPercent = 0.05; // Процент начисления на остаток в банке каждый ход
        private double PercentGrowBank = 0; // Накопление банковского процента, если значение по % получается < 1
        private double PercentGrowInvest = 0; // Накопление инвестиционного процента, если значение по % получается < 1 и > -1
        public int Money { get; private set; } = 10000; // Несмотря на то, что мы работаем с деньгами,
                                                        // деньги являются у.е. и не требуют точности.
                                                        // Упрощения игрового процесса
        public int Bank { get; private set; } = 0;

        public int Invest { get; private set; } = 0;

        public bool ChangeMoney(int x) // Изменение операционных денег
        {
            if (Money + x < 0)
            {
                if (Money + Bank + x >= 0)
                {
                    Console.WriteLine("Не хватает операционных денег. Взять с банковского счета недостающей суммы?");
                    Console.WriteLine("1 - да, 2 - нет");
                    int takeMoney = 0;
                    while (!int.TryParse(Console.ReadLine(), out takeMoney) || (takeMoney != 1 && takeMoney != 2))
                    {
                        Console.WriteLine("Нет такого действия. Нажми Enter и попробуй еще раз");
                        Console.ReadLine();
                        Console.WriteLine("Не хватает операционных денег. Взять с банковского счета недостающей суммы?");
                        Console.WriteLine("1 - да, 2 - нет");
                    }

                    if (takeMoney == 1)
                    {
                        Bank = Bank + Money + x;
                        Money = 0;
                        return true;
                    }
                    if (takeMoney == 2)
                    {
                        Console.WriteLine("Хорошо. Не снимаем деньги.");
                        return false;
                    }
                } else
                {
                    if (Money + Invest + x >= 0)
                    {
                        Console.WriteLine("Не хватает операционных денег. Взять с инвестиционного счета недостающей суммы?");
                        Console.WriteLine("1 - да, 2 - нет");
                        int takeMoney = 0;
                        while (!int.TryParse(Console.ReadLine(), out takeMoney) || (takeMoney != 1 && takeMoney != 2))
                        {
                            Console.WriteLine("Нет такого действия. Нажми Enter и попробуй еще раз");
                            Console.ReadLine();
                            Console.WriteLine("Не хватает операционных денег. Взять с инвестиционного счета недостающей суммы?");
                            Console.WriteLine("1 - да, 2 - нет");
                        }

                        if (takeMoney == 1)
                        {
                            Invest = Invest + Money + x;
                            Money = 0;
                            return true;
                        }
                        if (takeMoney == 2)
                        {
                            Console.WriteLine("Хорошо. Не снимаем деньги.");
                            return false;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Не хватает денег");
                        return false;
                    }
                }




            }

            Money += x;
            return true;
        }

        public bool ChangeBankAction(int x) // Изменение банковских денег (действия)
        {
            if (Bank + x < 0) return false;
            Bank += x;
            return true;
        }
        public void ChangeBankPercent() // Изменение банковских денег (проценты)
        {

            if (Bank != 0)
            {
                double profitPercent = Bank * BankPercent / 100;

                if (profitPercent < 1)
                {
                    PercentGrowBank += profitPercent;
                }
                else
                {
                    Bank += Convert.ToInt32(profitPercent);
                    PercentGrowBank = 0;
                }

                if (PercentGrowBank >= 1)
                {
                    Bank += Convert.ToInt32(PercentGrowBank);
                    PercentGrowBank = 0;
                }
            }
        }
        public bool ChangeInvestAction(int x) // Изменение инвестиционных денег (действия)
        {
            if (Invest + x < 0) return false;
            Invest += x;
            return true;
        }
        public void ChangeInvestPercent(int x) // Изменение инвестиционных денег (проценты)
        {
            if (Invest != 0)
            {
                Invest += (int)(Invest * x / 100);
                double profitPercent = Invest * x / 100;

                if (profitPercent < 1 && profitPercent > -1)
                {
                    PercentGrowInvest += profitPercent;
                }
                else
                {
                    Invest += Convert.ToInt32(profitPercent);
                    PercentGrowInvest = 0;
                }

                if (PercentGrowInvest >= 1 || PercentGrowInvest <= -1)
                {
                    Invest += Convert.ToInt32(PercentGrowInvest);
                    PercentGrowInvest = 0;
                }
            }
        }
    }
}
