using _01_KomodoCafe.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace _01_KomodoCafe.UI
{
    public class ProgramUI
    {
        private readonly MenuItemRepository _repo;

        public ProgramUI()
        {
            _repo = new MenuItemRepository();
        }

        public void Run()
        {
            Seed();
            RunApplication();
        }


        public void RunApplication()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("Welcome to Komodo Cafe\n" +
                    "1. Add A Menu Item \n" +
                    "2. View All Menu Items \n" +
                    "3. Delete Menu Item \n");

                string userInput = ReadLine();

                switch (userInput)
                {
                    case "1":
                        AddMenuItem();
                        break;
                    case "2":
                        ViewAllMenuItems();
                        break;
                    case "3":
                        RemoveMenuItems();
                        break;
                    default:
                        WriteLine("Invalid Selection");
                        WaitForKey();
                        break;
                }
                Clear();

            }

        }

        private void AddMenuItem()
        {
            Clear();
            WriteLine("Food Items Available");
            MenuItem menuItems = new MenuItem();

            Write("Please enter a Meal Name: ");
            menuItems.MealName = ReadLine();

            Write("Please enter a description for the meal: ");
            menuItems.Description = ReadLine();

            bool hasAddedAllIngredients = false;
            while (hasAddedAllIngredients == false)
            {
                Write("Please enter the ingredients for the meal: ");

                Console.WriteLine("Available Ingredients: \n" +
                    "1. Beef \n" +
                    "2. Ham \n" +
                    "3. Chicken \n" +
                    "4. Lettuce \n" +
                    "5. Tomtao \n" +
                    "6. Onion \n" +
                    "5. Pickle \n" +
                    "6. Bread \n" +
                    "7. Cheese");

                int userInput2 = int.Parse(ReadLine());
                menuItems.Ingredients.Add((Ingredients)userInput2);
                WriteLine("Do you want to add another ingredient y/n?");
                string userInput3 = ReadLine();
                if (userInput3 == "Y".ToLower())
                {
                    continue;
                }
                else
                {
                    hasAddedAllIngredients = true;
                }
            }




            Write("Please enter a price for the meal: ");
            menuItems.Price = Convert.ToDecimal(ReadLine());  //convertDecimal = Convert.ToDecimal(value)//        

            _repo.AddMenuItem(menuItems);

        }

        private void ViewAllMenuItems()
        {
            Clear();
            WriteLine("Menu items available:");
            List<MenuItem> foodItems = _repo.GetAllMenuItems();
            foreach (MenuItem item in foodItems)
            {
                DisplayContentListItem(item);
            }

            WaitForKey();
        }

        private void DisplayContentListItem(MenuItem foodItems)
        {
            WriteLine($"\n" +
                $"Food Item Name: {foodItems.MealName} \n" +
                $"Food Item Description: {foodItems.Description}\n" +
                $"Food Item Price: {foodItems.Price}\n" +
                $"Combo Number: {foodItems.ComboNumber}");
            GetContentIngredients(foodItems);
        }

        private void RemoveMenuItems()
        {
            Clear();
            ViewAllMenuItems();
            Console.WriteLine("Please input the combo number you wish to remove");
            MenuItem item = _repo.GetMenuItem(int.Parse(ReadLine()));
            if (item != null)
            {
                var success = _repo.DeleteExsistingMenuItem(item);
                if (success)
                {
                    Console.WriteLine("SUCCESS");
                }
                else
                {
                    Console.WriteLine("FAIL");
                }
            }
            Console.WriteLine($"The menu item does not exist");

        }
        private void Seed()
        {
            MenuItem bigMac = new MenuItem();
            bigMac.ComboNumber = 1;
            bigMac.MealName = "Big Mac";
            bigMac.Description = "Two all beef with the stuff";
            bigMac.Price = 6.95m;
            bigMac.Ingredients = new List<Ingredients> { Ingredients.Beef, Ingredients.Cheese };
            _repo.AddMenuItem(bigMac);

            MenuItem hotHam = new MenuItem();
            hotHam.ComboNumber = 2;
            hotHam.MealName = "Hot Ham and Cheese";
            hotHam.Description = "cheesy ham";
            hotHam.Price = 5.95m;
            hotHam.Ingredients = new List<Ingredients> { Ingredients.Ham, Ingredients.Cheese };
            _repo.AddMenuItem(hotHam);

        }

        private void GetContentIngredients(MenuItem foodItem)
        {
            Console.WriteLine("Ingredients: ");
            foreach (var item in foodItem.Ingredients)
            {
                Console.WriteLine(item);
            }
        }

        private void WaitForKey()
        {
            ReadKey();
        }

        private void Clear()
        {
            Console.Clear();
        }

    }
}
