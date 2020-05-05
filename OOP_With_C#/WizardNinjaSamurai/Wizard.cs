using System;

namespace WizardNinjaSamurai
{
    class Wizard : Human
    {
        // Constructor
        public Wizard(string name) : base(name)
        {
            Health = 250;
            Intelligence = 10;
        }
        // Override Attack Method
        public override int Attack(Human target)
        {
            int dmg = Intelligence * 7;
            target.Health -= dmg;
            // Health += dmg;
            Console.WriteLine($"{Name} attacked {target.Name} for {dmg} damage!");
            return target.Health;
        }
        // Heal Method
        public int Heal(Human target)
        {
            int heal = Intelligence * 10;
            target.Health += heal;
            Console.WriteLine($"{Name} healed with {heal} points!");
            return target.Health;
        }
    }
}
