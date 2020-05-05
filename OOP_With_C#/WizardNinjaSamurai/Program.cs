using System;

namespace WizardNinjaSamurai
{
    class DoThis
    {
        // Use a switch statement for attack or heal.
        public void Action(string do_this, Wizard w1, Samurai s1, Ninja n1, Human mon)
        {
            Random rand = new Random();
            System.Console.WriteLine("_,.-'~'-.,__,.-'~'-.,__,.-'~'-.,__,.-'~'-.,__,.-'~'-.,_");
            switch (do_this)
            {
                case "a":
                    w1.Attack(mon);
                    int x = rand.Next(3);
                    int y = rand.Next(2);
                    if (x == 1)
                    {
                        System.Console.WriteLine($"{s1.Name} has decided to help you attack!");
                        s1.Attack(mon);
                    }
                    else if (x == 2)
                    {
                        System.Console.WriteLine($"{n1.Name} has decided to help you attack!");
                        n1.Attack(mon);
                    }
                        System.Console.WriteLine("-------------------------------------------------");
                        if (y == 0)
                        {
                            mon.Attack(w1);
                        }
                        if (y == 1)
                        {
                            mon.Attack1(w1);
                        }
                    break;
                case "h":
                    w1.Heal(w1);
                    System.Console.WriteLine("-------------------------------------------------");
                    mon.Attack(w1);
                    break;
            }
            System.Console.WriteLine("-------------------------------------------------");
            mon.GetInfo();    
            w1.GetInfo();
            System.Console.WriteLine("_,.-'~'-.,__,.-'~'-.,__,.-'~'-.,__,.-'~'-.,__,.-'~'-.,_");
        }

        // For the boss attack
        public void BossAction(string do_this, Wizard w1, Samurai s1, Ninja n1, Human mon)
        {
            Random rand = new Random();
            System.Console.WriteLine("_,.-'~'-.,__,.-'~'-.,__,.-'~'-.,__,.-'~'-.,__,.-'~'-.,_");
            switch (do_this)
            {
                case "a":
                    w1.Attack(mon);
                    int x = rand.Next(3);
                    int y = rand.Next(6);
                    if (x == 1)
                    {
                        System.Console.WriteLine($"{s1.Name} has decided to help you attack!");
                        s1.Attack(mon);
                    }
                    else if (x == 2)
                    {
                        System.Console.WriteLine($"{n1.Name} has decided to help you attack!");
                        n1.Attack(mon);
                    }
                        System.Console.WriteLine("-------------------------------------------------");
                        if (y == 0)
                        {
                            mon.Attack(w1);
                        }
                        if (y == 1)
                        {
                            mon.Attack1(w1);
                        }
                        if (y == 2)
                        {
                            mon.Attack2(w1);
                        }
                        if (y == 3)
                        {
                            mon.Attack3(w1);
                        }
                        if (y == 4)
                        {
                            mon.Attack4(w1);
                        }
                        if (y == 5)
                        {
                            mon.Attack5(w1);
                        }
                    break;
                case "h":
                    int z = rand.Next(6);
                    w1.Heal(w1);
                    System.Console.WriteLine("-------------------------------------------------");
                                            if (z == 0)
                        {
                            mon.Attack(w1);
                        }
                        if (z == 1)
                        {
                            mon.Attack1(w1);
                        }
                        if (z == 2)
                        {
                            mon.Attack2(w1);
                        }
                        if (z == 3)
                        {
                            mon.Attack3(w1);
                        }
                        if (z == 4)
                        {
                            mon.Attack4(w1);
                        }
                        if (z == 5)
                        {
                            mon.Attack5(w1);
                        }
                    break;
            }
            System.Console.WriteLine("-------------------------------------------------");
            mon.GetInfo();    
            w1.GetInfo();
            System.Console.WriteLine("_,.-'~'-.,__,.-'~'-.,__,.-'~'-.,__,.-'~'-.,__,.-'~'-.,_");
        }

        public void CheckHealth(Wizard w1)
        {
            if (w1.Health < 0)
            {
                System.Console.WriteLine(" _______  _______  __   __  _______    _______  __   __  _______  ______     ");
                System.Console.WriteLine("|       ||   _   ||  |_|  ||       |  |       ||  | |  ||       ||    _ |    ");
                System.Console.WriteLine("|    ___||  |_|  ||       ||    ___|  |   _   ||  |_|  ||    ___||   | ||    ");
                System.Console.WriteLine("|   | __ |       ||       ||   |___   |  | |  ||       ||   |___ |   |_||_   ");
                System.Console.WriteLine("|   ||  ||       ||       ||    ___|  |  |_|  ||       ||    ___||    __  |  ");
                System.Console.WriteLine("|   |_| ||   _   || ||_|| ||   |___   |       | |     | |   |___ |   |  | |  ");
                System.Console.WriteLine("|_______||__| |__||_|   |_||_______|  |_______|  |___|  |_______||___|  |_|  ");
                Environment.Exit(0);

            }

        }

    }
    class Program
    {
        static void Main(string[] args)
        {   
            
            System.Console.WriteLine(@"        ,     \    /      ,        ");
            System.Console.WriteLine(@"       / \    )\__/(     / \       ");
            System.Console.WriteLine(@"      /   \  (_\  /_)   /   \      ");
            System.Console.WriteLine(@" ____/_____\__\@  @/___/_____\____ ");
            System.Console.WriteLine(@"|             |\../|              |");
            System.Console.WriteLine(@"|              \VV/               |");
            System.Console.WriteLine(@"|   The Tale of a Young Wizard    |");
            System.Console.WriteLine(@"|_________________________________|");
            System.Console.WriteLine(@" |    /\ /      \\       \ /\    | ");
            System.Console.WriteLine(@" |  /   V        ))       V   \  | ");
            System.Console.WriteLine(@" |/     `       //        '     \| ");
            System.Console.WriteLine(@" `              V                ' ");
            System.Console.WriteLine("Welcome Wizard! You are on a journey from becoming a weak peasant wizard to Supreme Wizard with ultimate powers. But to do that, you must first defeat Chronus and his monster friends. On your journey, you will be accompanied by two adventurers - Samurai and Ninja");
            System.Console.WriteLine("--------------------------------------------------");
            System.Console.WriteLine("To start your adventure. Type your name, then press enter");
            string pname = (Console.ReadLine());
            System.Console.WriteLine("--------------------------------------------------");
            Wizard w1 = new Wizard(pname);
            Samurai s1 = new Samurai("Samurai Sam");
            Ninja n1 = new Ninja("Ninja Nina");
            System.Console.WriteLine($"Hello {pname}. Here are your current stats, and the stats of your friends:");
            w1.GetInfoStart();
            s1.GetInfoStart();
            n1.GetInfoStart();
            System.Console.WriteLine("--------------------------------------------------");
            System.Console.WriteLine("You are about to face your first challenge. Press any key to continue.");
            Console.ReadLine();

            // !!!!!! Modify to monster !!!!!!!!
            Bandos m1 = new Bandos("Bandos");
            Human mon = m1;
            System.Console.WriteLine($"You have encountered your first monster!");
            mon.GetInfo();
            DoThis act = new DoThis();

            while (mon.Health > 0 && w1.Health > 0)
                {
                    // Ask the user to choose an option.
                    System.Console.WriteLine("What do you want to do?");
                    Console.WriteLine("\ta - Attack!");
                    Console.WriteLine("\th - Load up on some health points.");
                    string do_this = Console.ReadLine();
                    act.Action(do_this, w1, s1, n1, mon);
                }
            act.CheckHealth(w1);
            
            
            System.Console.WriteLine("You have defeated Bandos!!");
            w1.Heal(w1);
            System.Console.WriteLine("Sorry you're forced to continue. Press any key.");
            Console.ReadLine();

            // MONSTER 2
            Wyvern m2 = new Wyvern("Wyvern");
            mon = m2;
            System.Console.WriteLine("Your new opponent Wyvern has appeared!");
            mon.GetInfo();
            w1.GetInfo();
            
            while (mon.Health > 0 && w1.Health > 0)
                {
                    // Ask the user to choose an option.
                    System.Console.WriteLine("What do you want to do?");
                    Console.WriteLine("\ta - Attack!");
                    Console.WriteLine("\th - Load up on some health points.");
                    string do_this = Console.ReadLine();
                    act.Action(do_this, w1, s1, n1, mon);
                }
                act.CheckHealth(w1);

            // MONSTER 3
            System.Console.WriteLine("You have defeated Wyvern!!");
            w1.Heal(w1);
            System.Console.WriteLine("Sorry you're forced to continue. Press any key.");
            Console.ReadLine();

            Arcanis m3 = new Arcanis("Arcanis");
            mon = m3;
            System.Console.WriteLine("Your new opponent Arcanis has appeared!");
            mon.GetInfo();
            w1.GetInfo();
            while (mon.Health > 0 && w1.Health > 0)
                {
                    // Ask the user to choose an option.
                    System.Console.WriteLine("What do you want to do?");
                    Console.WriteLine("\ta - Attack!");
                    Console.WriteLine("\th - Load up on some health points.");
                    string do_this = Console.ReadLine();
                    act.Action(do_this, w1, s1, n1, mon);
                }
                act.CheckHealth(w1);
            // BOSSS!!!!!!
            System.Console.WriteLine("You have defeated Arcanis!!");
            w1.Heal(w1);
            System.Console.WriteLine("Sorry you're forced to continue. Press any key.");
            Console.ReadLine();

            Chronus B1 = new Chronus("Chronus");
            mon = B1;
            System.Console.WriteLine("Your last opponent Chronus has appeared!");
            mon.GetInfo();
            w1.GetInfo();
            while (mon.Health > 0 && w1.Health > 0)
                {
                    // Ask the user to choose an option.
                    System.Console.WriteLine("What do you want to do?");
                    Console.WriteLine("\ta - Attack!");
                    Console.WriteLine("\th - Load up on some health points.");
                    string do_this = Console.ReadLine();
                    act.BossAction(do_this, w1, s1, n1, mon);
                }
                act.CheckHealth(w1);

            System.Console.WriteLine("  __   __  _______  __   __   _     _  _______  __    _  __  ");
            System.Console.WriteLine(" |  | |  ||       ||  | |  | | | _ | ||       ||  |  | ||  | ");
            System.Console.WriteLine(" |  |_|  ||   _   ||  | |  | | || || ||   _   ||   |_| ||  | ");
            System.Console.WriteLine(" |       ||  | |  ||  |_|  | |       ||  | |  ||       ||  | ");
            System.Console.WriteLine(" |_     _||  |_|  ||       | |       ||  |_|  ||  _    ||__| ");
            System.Console.WriteLine("   |   |  |       ||       | |   _   ||       || | |   | __  ");
            System.Console.WriteLine("   |___|  |_______||_______| |__| |__||_______||_|  |__||__| ");    


        

        }
    }
}
