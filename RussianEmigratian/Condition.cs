using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RussianEmigratian
{
    class Condition
    {
        public int Helth { get; private set; } = 100;
        public int Happines { get; private set; } = 100;
        public int Energy { get; private set; } = 100;

        public void SetHelth(int x)
        {
            int helth = Helth + x;
            if (helth <= 100 && helth > 0) Helth = helth;
            if (helth <= 0) Helth = 0;
        }
        public void SetHappines(int x)
        {
            int happines = Happines + x;
            if (happines <= 100 && happines > 0) Happines = happines;
            if (happines <= 0) Happines = 0;
        }
        public void SetEnergy(int x)
        {
            int energy = Energy + x;
            if (energy <= 100 && energy > 0) Energy = energy;
            if (energy <= 0) Energy = 0;
        }
    }
}
