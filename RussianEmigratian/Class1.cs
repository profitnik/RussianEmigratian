using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RussianEmigratian
{
    class Class1
    {
        Random rnd = new Random();
       public double depo = 10000;


        public void Percent()
        {
            double per = depo * rnd.Next(-3,3) / 100;
            depo += per;
        }
    }
}
