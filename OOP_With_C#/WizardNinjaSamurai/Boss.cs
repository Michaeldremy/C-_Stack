using System;

namespace WizardNinjaSamurai
{
    class Chronus : Human
    {
        public Chronus(string name = "Chronus") : base(name)
        {
            Health = 2000;
            Strength = 25;
            Intelligence = 15;
            Dexterity = 10;
        }
        public  override int Attack(Human target)
        {
        // This will hit for 100 damage
            int damage = 4* this.Strength;
            target.Health -= damage;
            Console.WriteLine($"{Name} attacked {target.Name} for {damage} damage!");
            return target.Health;
        }
        public override int Attack1(Human target)
        {
        // This will do 25 damage and heal Bandos 25 health points
            int refresh = 25;
            target.Health -= refresh;
            System.Console.WriteLine($"{Name} has stolen 25 health from {target.Name} and has healed themselves.");
            Health += refresh;
            return target.Health;
        }
        public override int Attack2(Human target)
        {
        // This will hit for 50 damage
            int damage = 2* this.Strength;
            target.Health -= damage;
            Console.WriteLine($"{Name} attacked {target.Name} for {damage} damage!");
            return target.Health;
        }
        public override int Attack3(Human target)
        {
        // This has a 1/15 chance and if the targets health is below 65 will automatically kil the target
            Random rand = new Random();
            int chance = rand.Next(15);
            if (chance == 0)
            {
                base.Attack(target);
            }
            return target.Health;
        }
        public override int Attack4(Human target)
        {
        // This attack will hit for 45 damage
            int damage = 3* this.Intelligence;
            target.Health -= damage;
            Console.WriteLine($"{Name} attacked {target.Name} for {damage} damage!");
            return target.Health;
        }
        public override int Attack5(Human target)
        {
            Random rand = new Random();
            int chance = rand.Next(5);
            if (chance == 0)
            {
                if (target.Health < 35)
                {
                    target.Health = 250;
                    System.Console.WriteLine($"{Name} has healed and is now at 250 health points!");
                }
            }
            return Health;
        }
    }
}