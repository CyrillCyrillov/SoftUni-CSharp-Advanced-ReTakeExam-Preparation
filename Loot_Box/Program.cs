using System;
using System.Collections;
using System.Linq;

namespace Loot_Box
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue firsLoot = new Queue();
            Stack secondLoot = new Stack();
            int loot = 0;
            const int limit = 100;

            for (int i = 1; i <= 2; i++)
            {
                int[] dataLine = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                 if(i == 1)
                 {
                        foreach (int item in dataLine)
                        {
                            firsLoot.Enqueue(item);
                        }
                 }
                 else
                 {
                        foreach (int item in dataLine)
                        {
                            secondLoot.Push(item); ;
                        }
                  }
            }

            while (firsLoot.Count != 0 && secondLoot.Count != 0)
            {

                int one = (int)firsLoot.Peek();
                int two = (int)secondLoot.Peek();

                int curentChekSum = one + two;

                if(curentChekSum % 2 == 0)
                {
                    loot += curentChekSum;
                    firsLoot.Dequeue();
                    secondLoot.Pop();
                }
                else
                {
                    firsLoot.Enqueue((int)secondLoot.Pop());
                    //firsLoot.Dequeue();
                }
            }

            if(firsLoot.Count == 0)
            {
                Console.WriteLine("First lootbox is empty");
            }
            else
            {
                Console.WriteLine("Second lootbox is empty");
            }
            if(loot >= limit)
            {
                Console.WriteLine($"Your loot was epic! Value: {loot}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {loot}");
            }
            //Console.WriteLine("Hello World!");
        }
    }
}
