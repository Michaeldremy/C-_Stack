using System;

namespace Fundamentals_1
{
    class Program
    {
        static void Main(string[] args)
        {
        for (int i = 0; i <=255; i++)
        {
            Console.WriteLine(i);
        }
        divideNumbers();
        fizzBuzz();
        }
        public static void divideNumbers()
        {
            for (int DivNum = 0; DivNum <=100; DivNum++)
            {
                if (DivNum %5 == 0 || DivNum %3 == 0)
            {
                Console.WriteLine(DivNum);
            }
            }
        }
        public static void fizzBuzz()
        {
            for (int i = 0; i <=100; i++)
            {
                if (i %3 == 0)
                {
                    Console.WriteLine("Fizz");
                }
                if (i %5 == 0)
                {
                    Console.WriteLine("Buzz");
                }
                if (i %3 == 0 && i %5 == 0)
                {
                    Console.WriteLine("FizzBuzz");
                }
                }
            }
        }
    }
