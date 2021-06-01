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
        }
        public void SetHappines(int x)
        {
            int happines = Helth + x;
            if (happines <= 100 && happines > 0) Happines = happines;
        }
        public void SetEnergy(int x)
        {
            int energy = Helth + x;
            if (energy <= 100 && energy > 0) Energy = energy;
        }
    }
}
