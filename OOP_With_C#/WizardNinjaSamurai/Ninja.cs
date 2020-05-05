using System;

namespace WizardNinjaSamurai
{
    class Ninja : Human
    {
        // Constructor
        public Ninja(string name) : base(name)
        {
            Dexterity = 10;
        }
        // Override Attack Method
        public override int Attack(Human target)
        {
            int dmg = Dexterity * 5;
            Random rand = new Random();
            int chance = rand.Next(5);
            if (chance == 0)
            {
                dmg += 10;
            }
            target.Health -= dmg;
            Console.WriteLine($"{Name} attacked {target.Name} for {dmg} damage!");
            return target.Health;
        }
        // Steal Method
        public int Steal(Human target)
        {
            target.Health -= 5;
            Health += 5;
            System.Console.WriteLine($"{target.Name} now has Health: {target.Health} and {Name} now was Health: {Health}");
            return Health;
        }
    }
}
