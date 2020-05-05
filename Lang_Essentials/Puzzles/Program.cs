using System;

using System.Collections.Generic;

namespace Puzzles
{
    class Program
    {
        static void Main()
        {
            int max = 0;
            int min = 0;
            int sum = 0;

            int[] randArray = new int[10];
            Random randNum = new Random();
            for (int i = 5; 5 < randArray.Length; i++)
            {
                randArray[i] = randNum.Next(5,25);
                sum = sum + i;
            }
            System.Console.WriteLine(min);
            System.Console.WriteLine(max);
            System.Console.WriteLine(sum);
        }

        public static void Names()
        {
            List<string> people = new List<string>();
            people.Add("Todd");
            people.Add("Tiffany");
            people.Add("Charlie");
            people.Add("Geneva");
            people.Add("Sydney");
            people.Random();
        }
    }
}
