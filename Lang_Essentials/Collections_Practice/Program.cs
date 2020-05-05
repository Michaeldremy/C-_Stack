using System;

// Gives access to Lists and Dictionaries
using System.Collections.Generic;

namespace Collections_Practice
{
    class Program
    {
        static void Main()
        {
            // Create an array to hold integer values 0 through 9
            int[] valArray;
            valArray = new int[] {0,1,2,3,4,5,6,7,8,9};
            foreach (int value in valArray)
            Console.WriteLine(value);
            Names();
            trueOrFalse();
            iceCreamFlavors();
            infoDict();
        }
        static void Names()
        {
            // Create an array of the names "Tim", "Martin", "Nikki", & "Sara"
        string[] namesArray;
        namesArray = new string[] {"Tim", "Martin", "Nikki", "Sara"};
        foreach (string name in namesArray)
        Console.WriteLine(name);
        }
        static void trueOrFalse()
        {
            // Create an array of length 10 that alternates between true and false values, starting with true
            string[] tOrFArray;
            tOrFArray = new string[] {"True", "False", "True", "False", "True", "False", "True","False","True","False"};
            foreach (string tOrF in tOrFArray)
            Console.WriteLine(tOrF);
        }
        static void iceCreamFlavors()
        {
            List<string> ice_cream_flavor = new List<string>();
            ice_cream_flavor.Add("Rocky Road");
            ice_cream_flavor.Add("Chocolate");
            ice_cream_flavor.Add("Vanilla");
            ice_cream_flavor.Add("Mocha");
            ice_cream_flavor.Add("Cookies and Cream");
            // Output the length of this list after building it
            System.Console.WriteLine(ice_cream_flavor.Count);
            // Output the third flavor in the list, then remove this value
            System.Console.WriteLine(ice_cream_flavor[3]);
            ice_cream_flavor.Remove("Vanilla");
            // Output the new length of the list (It should just be one fewer!)
            System.Console.WriteLine(ice_cream_flavor.Count);
        }
        static void infoDict()
        {
            // Create a dictionary that will store both string keys as well as string values
            Dictionary<string,string> userDict = new Dictionary<string, string>();
            userDict.Add("Tim", "Rocky Road");
            userDict.Add("Martin", "Chocolate");
            userDict.Add("Nikki", "Mocha");
            userDict.Add("Sara","Cookies and Cream");
            // Loop through the dictionary and print out each user's name and their associated ice cream flavor
            foreach (var entry in userDict)
            {
                Console.WriteLine(entry.Key + " - " + entry.Value);
            }
        }
    }
}
