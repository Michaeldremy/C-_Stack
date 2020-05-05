using System;
using System.Collections.Generic;


namespace Hungry_Ninja
{

    class Food
{
    public string Name;
    public int Calories;
    // Foods can be Spicy and/or Sweet
    public bool IsSpicy; 
    public bool IsSweet; 
    // add a constructor that takes in all four parameters: Name, Calories, IsSpicy, IsSweet
    public Food(string name, int calories, bool isSpicy, bool isSweet)
    {
        Name = name;
        Calories = calories;
        IsSpicy = isSpicy;
        IsSweet = isSweet;
    }
}

class Buffet
{
    public List<Food> Menu;
     
    public Buffet()
    {
        Menu = new List<Food>()
        {
            new Food("Lasanga", 1000, false, false),
            new Food("Chicken Alfredo", 1600, false, false),
            new Food("Tacos", 250, true, false),
            new Food("Bubble Tea", 300, false, true),
            new Food("Brownies", 500, false, true),
            new Food("Chocolate", 400, true, true),
            new Food("Ice Cream", 600, false, true)
        };
    }
     
    public Food Serve()
    {
        var random = new Random();
        int index = random.Next(Menu.Count);
        System.Console.WriteLine(Menu[index].Name);
        return Menu[index];
    }
}

class Ninja
{
    private int calorieIntake;
    public List<Food> FoodHistory;
     
    // add a constructor
    public Ninja()
    {
        calorieIntake = 0;
        FoodHistory = new List<Food>();
    }
     
    // add a public "getter" property called "IsFull"
    public bool IsFull
    {
        get
        {
            if (calorieIntake > 1200)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
     
    // build out the Eat method
    public void Eat(Food item)
    {
        if(IsFull)
        {
            System.Console.WriteLine("Ninja is full and WILL not eat anymore!");
        }
        else
        {
            calorieIntake += item.Calories;
            FoodHistory.Add(item);

            string spicy_sweet = "";
            if(item.IsSpicy == true && item.IsSweet == true)
            {
                spicy_sweet = $"This {item.Name} is sweet and spicy!";
                System.Console.WriteLine(spicy_sweet);
            }
        }
    }
}



    class Program
    {
        static void Main(string[] args)
        {
            Buffet newBuffet = new Buffet();
            Ninja firstNinja = new Ninja();
            firstNinja.Eat(newBuffet.Serve());
            firstNinja.Eat(newBuffet.Serve());
            firstNinja.Eat(newBuffet.Serve());
        }
    }
}
