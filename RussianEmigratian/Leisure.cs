using System;

namespace RussianEmigratian
{
    class Leisure
    {
        int[] conditionChange = new int[3];
        // [0] - здоровье
        // [1] - счастье
        // [2] - энергия
  
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
        public int[] Gambling()
        {
            conditionChange[0] = -1;
            conditionChange[1] = 2;
            conditionChange[2] = -1;

            return (conditionChange);
        }
    }
}