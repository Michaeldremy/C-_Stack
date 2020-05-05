using System;
using System.Collections.Generic;

namespace Basic_13
{
    class Program
    {
        static void Main(string[] args)
        {
        PrintNumbers();
        PrintOdds();
        PrintSum();
        int[] someNums = {1,2,4,5,6,7,0,88,-10};
        LoopArray(someNums);
        int[] maxNum = {22,-5,0,55,33,56};
        FindMax(maxNum);
        System.Console.WriteLine(FindMax(maxNum));
        int[] avgNum = {2,10,3};
        GetAverage(avgNum);
        // OddArray();
        int[] gtY = {1,3,5,7};
        GreaterThanY(gtY, 3);
        int [] squareArr = {1,5,10,-10};
        SquareArrayValues(squareArr);
        int[] negativesArr = {1,5,10,-2};
        EliminateNegatives(negativesArr);
        int[] max_min_avgArr = {1, 5, 10, -2};
        MinMaxAverage(max_min_avgArr);
        int [] shiftArr = {1,5,10,7,-2};
        ShiftValues(shiftArr);
        }
        public static void PrintNumbers()
        {
            // Print 1-255
            // for (int i = 0; i <=255; i++)
            // System.Console.WriteLine(i);
        }
        public static void PrintOdds()
        {
            // Print all of the odd integers from 1 to 255.
            // for (int i = 0; i <=255; i++)
            //     if (i %2 != 0)
            //     {
            //         System.Console.WriteLine(i);
            //     }
        }
        public static void PrintSum()
        {
        // Print all of the numbers from 0 to 255, 
        // but this time, also print the sum as you go. 
        // int sum = 0;
        // for (int i = 0; i <=255; i++)
        // {
        //     sum = sum + i;
        //     System.Console.WriteLine("New Number: " + i);
        //     System.Console.WriteLine("Sum: " + sum);
        // }
        }
        public static void LoopArray(int[] numbers)
        {
            // Write a function that would iterate through each item of the given integer array and
            // print each value to the console. 
            // for (int i = 0; i <numbers.Length; i++)
            // {
            //     System.Console.WriteLine(numbers[i]);
            // }
        }
        public static int FindMax(int[] numbers)
        {
            // Write a function that takes an integer array and prints and returns the maximum value in the array. 
            // Your program should also work with a given array that has all negative numbers (e.g. [-3, -5, -7]), 
            // or even a mix of positive numbers, negative numbers and zero.
            int max = numbers[0];
            for (int i = 0; i < numbers.Length;i++)
            {
                if (max < numbers[i])
                {
                    max = numbers[i];
                }
            }
            return max;
        }
        public static void GetAverage(int[] numbers)
        {
            // Write a function that takes an integer array and prints the AVERAGE of the values in the array.
            // For example, with an array [2, 10, 3], your program should write 5 to the console.
        // int sum = 0;
        // for (int i = 0; i <numbers.Length;i++)
        // {
        //     sum = sum + numbers[i];
        // }
        // System.Console.WriteLine(sum / numbers.Length);
        }
        // public static int[] OddArray()
        // {
        //     // Write a function that creates, and then returns, an array that contains all the odd numbers between 1 to 255. 
        //     // When the program is done, this array should have the values of [1, 3, 5, 7, ... 255].
        //     List<int> odds = new List<int>();
        //     for (int i = 0; i <=255; i++)
        //     {
        //         if (i %2 !=0)
        //         {
        //             odds.Add(i);
        //         }
        //     }
        //     int[] newArray = new int[odds.Count];
        //     odds.CopyTo(newArray);
        //     foreach (int i in newArray)
        //     {
        //         System.Console.WriteLine(i);
        //     }
        //     return newArray;
        // }
        public static int GreaterThanY(int[] numbers, int y)
        {
            // Write a function that takes an integer array, and a integer "y" and returns the number of array values 
            // That are greater than the "y" value. 
            // For example, if array = [1, 3, 5, 7] and y = 3. Your function should return 2 
            // (since there are two values in the array that are greater than 3).
            int count = 0;
            for (int i=0;i<numbers.Length;i++)
            {
                if (numbers[i] > y)
                {
                    count++;
                }
            }
            return count;
        }
        public static void SquareArrayValues(int[] numbers)
        {
            // Write a function that takes an integer array "numbers", and then multiplies each value by itself.
            // For example, [1,5,10,-10] should become [1,25,100,100]
            for (int i = 0;  i<numbers.Length;i++)
            {
                numbers[i] = numbers[i] * numbers[i];
            }
            foreach (int i in numbers)
            {
            System.Console.WriteLine(i);
            }
        }
        public static void EliminateNegatives(int[] numbers)
        {
            // Given an integer array "numbers", say [1, 5, 10, -2], create a function that replaces any negative number with the value of 0. 
            // When the program is done, "numbers" should have no negative values, say [1, 5, 10, 0].
            for (int i = 0; i<numbers.Length;i++)
            {
                if (numbers[i] < 0)
                {
                    numbers[i] = 0;
                }
            }
            foreach (int i in numbers)
            {
            System.Console.WriteLine(i);
            }
        }
        public static void MinMaxAverage(int[] numbers)
        {
            // Given an integer array, say [1, 5, 10, -2], create a function that prints the maximum number in the array, 
            // the minimum value in the array, and the average of the values in the array.
        int max = numbers[0];
        int min = numbers[0];
        int sum = numbers[0];

        for (int i=0; i<numbers.Length;i++)
        {
            if (numbers[i] > max)
            {
                max = numbers[i];
            }
            if (numbers[i] < min)
            {
                min = numbers[i];
            }
            sum = sum + numbers[i];
        }
        int avg = sum / numbers.Length;
        int[] arrnew = {max,min,avg};
        foreach (int i in arrnew)
        System.Console.WriteLine(i);
        }
        public static void ShiftValues(int[] numbers)
        {
            // Given an integer array, say [1, 5, 10, 7, -2], 
            // Write a function that shifts each number by one to the front and adds '0' to the end. 
            // For example, when the program is done, if the array [1, 5, 10, 7, -2] is passed to the function, 
            // it should become [5, 10, 7, -2, 0].
            int temp = numbers[0];
            numbers[0] = numbers[numbers.Length -1];
            numbers[numbers.Length -1] = temp;
            foreach (int i in numbers)
            System.Console.WriteLine(i);
        }
        public static object[] NumToString(int[] numbers)
        {
            // Write a function that takes an integer array and returns an object array 
            // that replaces any negative number with the string 'Dojo'.
            // For example, if array "numbers" is initially [-1, -3, 2] 
            // your function should return an array with values ['Dojo', 'Dojo', 2].
            for (int i = 0; i < numbers.Length;i++)
            {
                if (numbers[i] < 0){
                    numbers[i] = "Dojo";
                }
            }
        }


    }
}
