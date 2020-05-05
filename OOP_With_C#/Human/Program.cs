using System;

namespace Human
{
    class Program
    {
        static void Main(string[] args)
        {
            Human firstHuman = new Human ("Michael the Great");
            Human secondHuman = new Human ("Rachel the Queen");
            Wizard firstWizard = new Wizard ("Jacob the western Wizard");
            Ninja firstNinja = new Ninja ("Ariella");
            Samurai firstSamurai = new Samurai ("Becca from the mystical mountains");


        }
    }
}

            // System.Console.WriteLine($"{firstHuman.Name}, has a strength level of {firstHuman.Strength}, an intelligence level of {firstHuman.Intelligence}, a dexterity level of {firstHuman.Dexterity} and a total amount of hp = {firstHuman.Health}");
            // System.Console.WriteLine($"{secondHuman.Name}, has a strength level of {secondHuman.Strength}, an intelligence level of {secondHuman.Intelligence}, a dexterity level of {secondHuman.Dexterity} and a total amount of hp = {secondHuman.Health}");
            // firstHuman.Attack(secondHuman);
            // System.Console.WriteLine($"{secondHuman.Name} now has {secondHuman.Health} Health Points remaining.");
            // // System.Console.WriteLine($"{firstNinja.Name} the first ninja, has a dexterity level of {firstNinja.Dexterity}.");
            // firstWizard.Heal(secondHuman);
            // System.Console.WriteLine($"{secondHuman.Name} has been healed, their health is now {secondHuman.Health}!");
            // System.Console.WriteLine($"{firstWizard.Name} health points are now {firstWizard.Health}.");
            // // firstNinja.Attack(firstHuman);
            // // System.Console.WriteLine($"{firstHuman.Name} now has {firstHuman.Health} and has died.");
            // firstHuman.Attack(firstSamurai);
            // System.Console.WriteLine($"{firstSamurai.Name} health points are now {firstSamurai.Health}.");
            // firstSamurai.Meditate(firstSamurai);
            // System.Console.WriteLine($"{firstSamurai.Name} health points are now {firstSamurai.Health}.");
            // firstNinja.Steal(firstWizard);
            // System.Console.WriteLine($"{firstWizard.Name} health points are now {firstWizard.Health}");
            // System.Console.WriteLine($"{firstNinja.Name} health points are now {firstNinja.Health}");
            // firstSamurai.Attack(firstWizard);
            // System.Console.WriteLine($"{firstWizard.Name} health points are now {firstWizard.Health}");