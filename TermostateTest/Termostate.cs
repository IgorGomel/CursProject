using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TermostateTest
{
    class Termostate
    {
        public int comfTWater;
        public int waterTemp = 1;

        public void setComfortTemp()
        {
            Console.WriteLine("Set the comfort temparature of water: ");
            comfTWater = Convert.ToInt32(Console.ReadLine());
            
        }

        
    }
}
