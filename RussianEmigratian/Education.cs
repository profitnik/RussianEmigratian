using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RussianEmigratian
{
    class Education
    {

        public int ManagerSkill { get; private set; } = 0;          //  уровень профессии "менеджер"
        public int DeveloperSkill { get; private set; } = 0;        //  уровень профессии "разработчик"
        public int InvestorSkill { get; private set; } = 0;        //  уровень профессии "инвестор"
        public int GamblingSkill { get; private set; } = 0;        //  уровень профессии "игрок"
        public int LanguageSkill { get; private set; } = 0;        //  уровень языка
        public int PriceManager { get; } = -1000;
        public int PriceDeveloper { get; } = -2000;
        public int PriceInvestor { get; } = -3000;
        public int PriceGambling { get; } = -4000;
        public int PriceLanguage { get; } = -5000;
        public void LearningSkill(int skill)
        {
            switch (skill)
            {
                case 1:
                    if (ManagerSkill < 100)
                    {
                        ManagerSkill += 5;
                    }
                    else Console.WriteLine("Навык уже полностью получен");
                    break;
                case 2:
                    if (DeveloperSkill < 100)
                    {
                        DeveloperSkill += 2;
                    }
                    else Console.WriteLine("Навык уже полностью получен");
                    break;
                case 3:
                    if (InvestorSkill < 100)
                    {
                        InvestorSkill += 5;
                    }
                    else Console.WriteLine("Навык уже полностью получен");
                    break;
                case 4:
                    if (GamblingSkill < 100)
                    {
                        GamblingSkill += 10;
                    }
                    else Console.WriteLine("Навык уже полностью получен");
                    break;
                case 5:
                    if (LanguageSkill < 100)
                    {
                        LanguageSkill += 2;
                    }
                    else Console.WriteLine("Навык уже полностью получен");
                    break;
                default: break;
            }
        }

        public void GetSkills()
        {
            // Показать уровень обучения на менеджера
            Console.WriteLine("");
            int part = ManagerSkill / 5;        // чтобы стать разработчиком необходимо 20 обучений
            if (part == 20)
            {
                Console.Write("√ Менеджер\n" +
                    "Уровень " + ManagerSkill + "\\100  ");

            }

            if (part < 20)
            {
                Console.Write("X Менеджер\n" +
                    "Уровень " + ManagerSkill + "\\100  ");
            }

            string loading = "█ ";
            for (int k = 0; k < part; k++)
            {
                Console.Write(loading);
                Thread.Sleep(50);
            }
            Console.WriteLine();

            // Показать уровень обучения на разработчика
            Console.WriteLine("");
            part = DeveloperSkill / 5;      // чтобы стать разработчиком необходимо 50 обучений
            if (part == 20)
            {
                Console.Write("√ Разработчик\n" +
                    "Уровень " + DeveloperSkill + "\\100  ");

            }

            if (part < 20)
            {
                Console.Write("X Разработчик\n" +
                    "Уровень " + DeveloperSkill + "\\100  ");
            }

            loading = "█ ";
            for (int k = 0; k < part; k++)
            {
                Console.Write(loading);
                Thread.Sleep(50);
            }
            Console.WriteLine();

            // Показать уровень обучения на инвестора
            Console.WriteLine("");
            part = InvestorSkill / 5;        // чтобы стать инвестором необходимо 20 обучений
            if (part == 20)
            {
                Console.Write("√ Инвестор\n" +
                    "Уровень " + InvestorSkill + "\\100  ");

            }

            if (part < 20)
            {
                Console.Write("X Инвестор\n" +
                    "Уровень " + InvestorSkill + "\\100  ");
            }

            loading = "█ ";
            for (int k = 0; k < part; k++)
            {
                Console.Write(loading);
                Thread.Sleep(50);
            }
            Console.WriteLine();

            // Показать уровень обучения на игрока
            Console.WriteLine("");
            part = GamblingSkill / 5;        // чтобы стать игроком необходимо 10 обучений
            if (part == 20)
            {
                Console.Write("√ Игрок\n" +
                    "Уровень " + GamblingSkill + "\\100  ");

            }

            if (part < 20)
            {
                Console.Write("X Игрок\n" +
                    "Уровень " + GamblingSkill + "\\100  ");
            }

            loading = "█ ";
            for (int k = 0; k < part; k++)
            {
                Console.Write(loading);
                Thread.Sleep(50);
            }
            Console.WriteLine();

            // Показать уровень языка
            Console.WriteLine("");
            part = LanguageSkill / 5;        // чтобы изучить язык нужно 50 обучений
            if (part == 20)
            {
                Console.Write("√ Язык\n" +
                    "Уровень " + LanguageSkill + "\\100  ");

            }

            if (part < 20)
            {
                Console.Write("X Язык\n" +
                    "Уровень " + LanguageSkill + "\\100  ");
            }

            loading = "█ ";
            for (int k = 0; k < part; k++)
            {
                Console.Write(loading);
                Thread.Sleep(50);
            }
            Console.WriteLine();
        }




    }
}
