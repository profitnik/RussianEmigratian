using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RussianEmigratian
{
    class Work
    {
        Random rnd = new Random();
        /*
         * 0 - курьер 1500
         * 1 - менеджер 2000
         * 2 - разработчик 3000
         * 3 - бандит -500 до 3000
         */
        int[] massivCondition = new int[4]; // Массив для возврата значений, которые нужно присвоить (0 деньги, 1 здоровье, 2 счастье, 3 энергия)


        public Dictionary <string, int> AllWork = new Dictionary<string, int>
        {
            ["Менеджер"] = 2000,
            ["Разработчик"] = 3000,
            ["Бандит"] = 0
        };

        public Dictionary<string, int> MyWork = new Dictionary<string, int>
        {
            ["Курьер"] = 1500
        };

        public void ChoiseWork(string x)
        {
            AllWork.Add(MyWork.ElementAt(0).Key,MyWork.ElementAt(0).Value); // Помещаем текущую работу во все работы
            MyWork.Remove(MyWork.ElementAt(0).Key); // Удаляю текущую работу
            AllWork.TryGetValue(x, out int value); // Получаю зарплату
            MyWork.Add(x, value); // Добавляю в текущую работу переданную работу с зп
            AllWork.Remove(x); // Удаляю переданную работу из всех
            
        }

        public int[] Working()
        {

            if(MyWork.ElementAt(0).Key == "Бандит")
            {
                massivCondition[0] = rnd.Next(-500, 3000 + 1);
                massivCondition[1] = -5;
                massivCondition[2] = -3;
                massivCondition[3] = -4;
            }

            if (MyWork.ElementAt(0).Key == "Курьер")
            {
                massivCondition[0] = 1500;
                massivCondition[1] = -1;
                massivCondition[2] = -1;
                massivCondition[3] = -3;
            }

            if (MyWork.ElementAt(0).Key == "Менеджер")
            {
                massivCondition[0] = 2000;
                massivCondition[1] = -2;
                massivCondition[2] = -3;
                massivCondition[3] = -2;
            }

            if (MyWork.ElementAt(0).Key == "Разработчик")
            {
                massivCondition[0] = 3000;
                massivCondition[1] = -2;
                massivCondition[2] = -1;
                massivCondition[3] = -1;
            }

            return (massivCondition);
        }
    }
}
