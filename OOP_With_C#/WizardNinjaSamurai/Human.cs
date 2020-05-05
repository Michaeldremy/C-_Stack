using System;

namespace WizardNinjaSamurai
{
    class Human
    {
        // Fields for Human
        public string Name;
        public int Strength;
        public int Intelligence;
        public int Dexterity;
        public int Health;
         
        // Add a constructor that takes a value to set Name, and set the remaining fields to default values
        public Human(string name)
        {
            Name = name;
            Strength = 3;
            Intelligence = 3;
            Dexterity = 3;
            Health = 100;
        }
        // Add a constructor to assign custom values to all fields
        public Human(string name, int stren, int intell, int dext, int hlth)
        {
            Name = name;
            Strength = stren;
            Intelligence = intell;
            Dexterity = dext;
            Health = hlth;
        }
        // Build Attack method
        public virtual int Attack(Human target)
        {
            int dmg = Strength * 3;
            target.Health = target.Health - dmg;
            Console.WriteLine($"{Name} attacked {target.Name} for {dmg} damage!");
            return target.Health;
        }
        // Build Attack1 method
        public virtual int Attack1(Human target)
        {
            int dmg = Strength * 3;
            target.Health = target.Health - dmg;
            Console.WriteLine($"{Name} attacked {target.Name} for {dmg} damage!");
            return target.Health;
        }
        // Build Attack2 method
        public virtual int Attack2(Human target)
        {
            return target.Health;
        }
        // Build Attack3 method
        public virtual int Attack3(Human target)
        {
            return target.Health;
        }
        // Build Attack4 method
        public virtual int Attack4(Human target)
        {
            return target.Health;
        }
        // Build Attack5 method
        public virtual int Attack5(Human target)
        {
            return target.Health;
        }

        // Display Info
        public void GetInfoStart()
        {
            System.Console.WriteLine($"{Name}: Strength: {Strength}, Intelligence: {Intelligence}, Dexterity: {Dexterity}, Health: {Health}");
        }
        public void GetInfo()
        {
            System.Console.WriteLine($"{Name}: Health: {Health}");
        }
    }

}