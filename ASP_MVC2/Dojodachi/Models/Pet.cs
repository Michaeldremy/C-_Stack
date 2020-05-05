using System;

namespace Dojodachi.Models
{
    public class Pet
    {
        public int Fullness {get;set;}
        public int Happiness {get;set;}
        public int Meals {get;set;}
        public int Energy {get;set;}
        public string Message {get;set;}
        public Pet (int fullness, int happiness, int meals, int energy, string message)
        {
            Fullness = fullness;
            Happiness = happiness;
            Meals = meals;
            Energy = energy;
            Message = message;
        }
        public Pet ()
        {
            Fullness = 20;
            Happiness = 20;
            Meals = 3;
            Energy = 50;
        }
        public void Feeding(int meals, int fullness, string message)
        {
            Fullness = fullness;
            Meals = meals;
            Message = message;

            Random randFullness = new Random();
            int chance = randFullness.Next(5,11);

            if (Meals > 0)
            {
                Meals -= 1;
                Random randPercent = new Random();
                int randChance = randPercent.Next(0,5);
                if (randChance == 0)
                {
                    Fullness = fullness;
                    Message = "Your Dojodachi did not want to play and it's happiness did not go up!";
                }
                else
                {
                Fullness += chance;
                Message = $"You played with your Dojodachi! Fullness +{chance} and Meals remaining {Meals}.";
                }
            }
            else
            {
                Message = $"You have run out of meals and can no longer feed your Dojodachi!";
            }
        }

        public void Playing(int energy, int happiness, string message)
        {
            Energy = energy;
            Happiness = happiness;
            Message = message;

            // Random ↓ will produce a 25% outcome to not increase Happiness.

            // Random ↓ will go between integers 5 and 10 and increase Happiness.
            Random randHappiness = new Random();
            int chance = randHappiness.Next(5,11);
            if (Energy > 0)
            {
                Energy -= 5;
                Random randPercent = new Random();
                int randChance = randPercent.Next(0,5);
                if (randChance == 0)
                {
                    Happiness = happiness;
                    Message = "Your Dojodachi did not want to play and it's happiness did not go up!";
                }
                else
                {
                Happiness += chance;
                Message = $"You played with your Dojodachi! Energy is now {Energy} and Happiness is +{chance}.";
                }
            }
            else
            {
                Message = $"You have run out of energy and you can no longer play with your Dojodachi!";
            }
        }
        public void Working(int energy, int meals, string message)
        {
            Energy = energy;
            Meals = meals;
            Message = message;

            Random randMeals = new Random();
            int chance = randMeals.Next(1,4);
            if (Energy > 0)
            {
                Energy -= 5;
                Meals += chance;
                Message = $"Your Dojodachi has went to work and became tired, your energy is now {Energy}. You have gained +{chance} meal.";
            }
            else
            {
                Message = "You have no more energy and you are unable to have your Dojodach go to work!";
            }
        }
        public void Sleeping(int energy, int fullness, int happiness, string message)
        {
            Energy = energy;
            Fullness = fullness;
            Happiness = happiness;
            Message = message;

            if (Happiness > 0 || Energy > 0)
            {

                Energy += 15;
                Fullness -= 5;
                Happiness -= 5;
                Message = $"Your Dojodach has went to Sleep! Dojodachi has gained 15 Energy but fullness and happiness went down by 5.";
            }
            else
            {
                Message = "You are either out of Happiness or Energy and can not longer sleep.";
            }
        }
    }
}