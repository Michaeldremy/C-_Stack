using System;

namespace Human
{
    class Human
    {
        // Fields for Human
        public string Name;
        public int Strength;
        public int Intelligence;
        public int Dexterity;
        private int health;
         
        public int Health
        {
            get { return health; }
            set { health = value; }
        }
        
         
        // Add a constructor that takes a value to set Name, and set the remaining fields to default values
        public Human(string name)
        {
            Name = name;
            Strength = 3;
            Intelligence = 3;
            Dexterity = 3;
            this.health = 100;
        }
         
        // Add a constructor to assign custom values to all fields
        public void HumanCustom(string name, int str, int intel, int dex, int health)
        {
            Name = name;
            Strength = str; 
            Intelligence = intel;
            Dexterity = dex;
            this.health = health;
        }
         
        // Build Attack method
        public virtual int Attack(Human target)
        {
            int damage = 5* this.Strength;
            target.Health -= damage;
            Console.WriteLine($"{Name} attacked {target.Name} for {damage} damage!");
            return target.health;
        }
    }
    class Ninja : Human
    {
        public Ninja(string name) : base(name)
        {
            Dexterity = 175;
        }
        public override int Attack(Human target)
        {
            int damage = 5* this.Dexterity;
            Console.WriteLine($"{Name} attacked {target.Name} for {damage} damage!");
            Random rand = new Random();
            int chance = rand.Next(5);
            if (chance == 0)
            {
                damage += 10;
                System.Console.WriteLine($"{Name} has done additional an 10 points of damage!");
            }
            target.Health -= damage;
            return target.Health;
        }
        public int Steal(Human target)
        {
            int steal = 5;
            target.Health -= steal;
            System.Console.WriteLine($"{Name} has stolen 5 health from {target.Name} and has healed themselves.");
            Health += steal;
            return target.Health;
        }
    }

    class Wizard : Human
    {
        public Wizard(string name) : base(name)
        {
            Health = 50;
            Intelligence = 25;
        }
        public int Heal(Human target)
        {
            int heal = 5* this.Intelligence;
            target.Health += heal;
            System.Console.WriteLine($"{Name} has healed {target.Name} for {heal} health!");
            return target.Health;
        }
        public override int Attack(Human target)
        {
            int damage = 5* this.Intelligence;
            target.Health -= damage;
            Console.WriteLine($"{Name} attacked {target.Name} for {damage} damage!");
            Health += 5* this.Intelligence;
            System.Console.WriteLine($"{Name} has been healed for {damage}.");
            return target.Health;
        }
    }
    class Samurai : Human
    {
        public Samurai(string name) : base(name)
        {
            Health = 200;
        }
        public int Meditate(Human target)
        {
            Health = 200;
            int medidate = Health;
            return target.Health;
        }
        public override int Attack(Human target)
        {
            if (target.Health < 50)
            {
                target.Health = 0;
            }
            Console.WriteLine($"{Name} attacked {target.Name}!");
            return target.Health;
        }
    }
}