using System;

using System.Collections.Generic;

namespace Boxing_and_unboxing
{
    class Program
    {
        static void Main()
        {
            // Created a List of type object. Object can contain multiple data structures!
            List<object> emptyList = new List<object>();
            emptyList.Add(7);
            emptyList.Add(28);
            emptyList.Add(-1);
            emptyList.Add(true);
            emptyList.Add("chair");
            // Loop through the list and print all values (Hint: Type Inference might help here!)
            foreach (object listItem in emptyList)
            {
                System.Console.WriteLine(listItem);
            }
            int Sum = 0;
            for (int i = 0; i < emptyList.Count; i++)
            {
                if (emptyList[i] is int)
                {
                    
                    Sum += (int)emptyList[i];
                }
            }
                System.Console.WriteLine(Sum);
            
        }
    }
}
