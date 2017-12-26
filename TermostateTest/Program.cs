using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace TermostateTest
{
    class Program
    {
        static void Main(string[] args)
        {            
            int a; 
            Console.WriteLine("Enter '1' to start the boiler: ");//для запуску бойлера введіть 1
            a = Convert.ToInt32(Console.ReadLine());//змінна в яку буде вводитись 1 - для ввімкнення термостата
                                                                               // 0 - для вимкнення 
            while (a != 1)
                { 
                    Console.WriteLine("Input error! Try again:");//якщо ввели число, відмінне від 1 - пробуйте ще раз
                    a = Convert.ToInt32(Console.ReadLine());
                }
            
            Termostate term = new Termostate();
            int sleepTime = 1000;//період зміни занчення таймера
            term.setComfortTemp();//викликали функцію введення комфортної темпаратури води
            //Console.WriteLine("Current temparature of water: " + 0);
            
            while(true)
            {
                while (term.waterTemp != term.comfTWater)//поки темпаратура води не піднялась до рівня комфортної
                {
                    Thread.Sleep(sleepTime);
                    term.waterTemp++;
                    Console.Clear();
                    Console.WriteLine("Current temparature of water: " + term.waterTemp);    
                }

                if (term.waterTemp == term.comfTWater)//якщо темпаратура води піднялась до рівня комфортної
                {
                    //тоді вимикаємо тен...
                    Console.WriteLine("The TEN is off! ");
                    //та чекаємо, поки темпаратура води охолоне на 10 градусів нижче...
                    //...від комфортної темпаратури(після чого знову ввімкнемо тен)
                    while (term.waterTemp != term.comfTWater - 5)
                    {
                        Thread.Sleep(sleepTime);
                        term.waterTemp--;
                        Console.Clear();
                        Console.WriteLine("Current temparature of water: " + term.waterTemp);

                    }
                }

                if (term.waterTemp == term.comfTWater - 5)//якщо темпаратура води понизилась до мінімальної...
                    Console.WriteLine("The TEN is on! ");//...тоді вмикаємо тен
            }
        }
    }
}
