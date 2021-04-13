using System;
using System.Collections.Generic;

namespace Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            int passedCars = 0;
            bool isCrash = false;
            bool isStopGreen = false;
            char crashChar = '!';
            string curentCar = null;

            int greenTime = int.Parse(Console.ReadLine());
            int freeWindowTime = int.Parse(Console.ReadLine());

            Queue<string> cars = new Queue<string>();


            while (true)
            {
                string nextComand = Console.ReadLine();

                if (nextComand.ToUpper() == "END") break; // EXIT The LOOP

                if(nextComand.ToUpper() == "GREEN")
                {
                    int time = greenTime;
                    
                    while (!isCrash && cars.Count > 0)
                    {
                        if (time <= 0) break;

                        curentCar = cars.Dequeue();

                        if (curentCar.Length <= time)
                        {
                            passedCars++;
                            time -= curentCar.Length;
                        }
                        else
                        { 
                            if(curentCar.Length > time && !isStopGreen)
                            {
                                time += freeWindowTime;
                            }
                            if(curentCar.Length > time)
                            {
                                isCrash = true;
                                int crashIndex = curentCar.Length - time + 2;
                                crashChar = curentCar[crashIndex];
                            }
                        }

                    }

                }
                else
                {
                    cars.Enqueue(nextComand);
                }


            }


                if(isCrash)
                {
                    Console.WriteLine("A crash happened!");
                    Console.WriteLine($"{curentCar} was hit at {crashChar}.");
                }
                else
                {
                    Console.WriteLine("Everyone is safe.");
                    Console.WriteLine($"{passedCars} total cars passed the crossroads.");
                }
            
                //Console.WriteLine("Hello World!");
        }
    }
}
