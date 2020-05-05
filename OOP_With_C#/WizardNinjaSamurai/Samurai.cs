using System;

namespace WizardNinjaSamurai
{
    class Samurai : Human
    {
        // Constructor
        public Samurai(string name) : base(name)
        {
            Health = 200;
        }
        // Override Attack Method
        public override int Attack(Human target)
        {
            if (target.Health < 50)
            {
                target.Health = 0;
                Console.WriteLine($"{Name} attacked {target.Name} for all of Health!");    
            }
            else{
                Console.WriteLine($"{Name} attacked {target.Name}. But no damange!");    
            }
            return target.Health;
        }
        // Meditate Method
        public int Meditate()
        {
            if (Health < 200)
            {
                Health = 200;
            }
            return Health;
        }
    }
}
