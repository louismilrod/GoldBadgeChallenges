using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_KomodoCafe.Repository
{
    public enum Ingredients 
    { 
        Beef=1,
        Ham,
        Chicken,
        Lettuce,
        Tomato,
        Onion,
        Pickle,
        Bread,
        Cheese
    
    }

    //public enum ComboNumber
    //{
    //    Big_Mac = 1,
    //    Double_Quarter_Pounder = 2,
    //    Big_Chicken = 3,
    //    Hot_Ham_and_Cheese = 4,
    //    Grilled_Cheese = 5    

    //}

    public class MenuItem
    {
        //A meal number, so customers can say "I'll have the #5"
        //A meal name
        //A description
        //A list of ingredients,
        //A price

        public MenuItem()
        {

        }

        public MenuItem(int comboNumber, string mealName, string description, List<Ingredients> ingredients, decimal price)
        {
            ComboNumber = comboNumber;
            MealName = mealName;
            Description = description;
            Ingredients = ingredients;
            Price = price;
        }

        
        public int ComboNumber { get; set; }
        public string MealName { get; set;}
        public string Description { get; set;}
        public List <Ingredients> Ingredients { get; set; } = new List<Ingredients>();
        public decimal Price { get; set; }
    }
}
