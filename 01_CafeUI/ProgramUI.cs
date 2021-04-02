using _01_CafeLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_CafeUI
{
      public class ProgramUI
    {
        private MenuRepository _repo = new MenuRepository();

        public void Run()
        {
            SeedMenuList();
            RunMenu();
        }

        private void RunMenu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();
                Console.WriteLine("Please select the option you'd prefer: \n" +
                    "1. Display whole menu \n" +
                    "2. Add new menu item \n" +
                    "3. Delete existing menu item \n" +
                    "4. Exit");
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        {
                            //Display all menu items
                            DisplayMenuItems();
                            break;
                        }
                    case "2":
                        {
                            //Add new menu item
                            AddMenuItem();
                            break;
                        }
                    case "3":
                        {
                            //Delete existing menu item
                            DeleteMenuItem();
                            break;
                        }
                    case "4":
                        {
                            //Exit
                            continueToRun = false;
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Please select an appropriate option (1-4)");
                            break;
                        }
                }
            }
        }

        private void DisplayMenuItems()
        {
            List<Menu> menuItems = _repo.DisplayMenuItems();
            foreach (Menu item in menuItems)
            {
                Console.WriteLine($"{item.MealNumber}. {item.MealName}");
                Console.WriteLine($"Description: {item.MealDescription}");
                Console.Write("Ingredients: ");
                foreach (string ingredient in item.ListOfIngredients)
                {
                    Console.Write($"{ingredient}, ");
                }
                Console.WriteLine(" \n");
                Console.WriteLine($"${item.Price}");
                Console.WriteLine(" \n" +
                    "------------");
            }
            Console.WriteLine("Press any key to return to the main screen...");
            Console.ReadKey();
        }

        private void AddMenuItem()
        {
            Menu itemAdded = new Menu();
            Console.Write("Please enter a new meal number: ");
            string mealNumber = Console.ReadLine();
            itemAdded.MealNumber = int.Parse(mealNumber);

            Console.Write("Please enter the name of the new meal: ");
            itemAdded.MealName = Console.ReadLine();

            Console.Write("Please describe the new meal: ");
            itemAdded.MealDescription = Console.ReadLine();

            Console.Write("Please enter the ingredients in the new meal: ");
            itemAdded.ListOfIngredients = new List<string> { Console.ReadLine() };

            Console.Write("Please enter the price of the new meal: ");
            string priceOfMeal = Console.ReadLine();
            itemAdded.Price = decimal.Parse(priceOfMeal);

            _repo.AddMenuItem(itemAdded);
            Console.WriteLine("Press any key to return to the main screen...");
            Console.ReadKey();
        }

        private void DeleteMenuItem()
        {
            Console.WriteLine("Please enter the name of the menu item you wish to delete: ");
            Menu itemDeleted = _repo.GetMenuItemByName(Console.ReadLine());

            _repo.DeleteMenuItem(itemDeleted);
            Console.WriteLine("Press any key to return to the main screen...");
            Console.ReadKey();
        }


        private void SeedMenuList()
        {
            Menu cheeseburger = new Menu(1, "Cheeseburger", "The Komodo spin on the  Classic, with steak fries and drink included.", new List<string> { "bun", "patty", "cheese", "lettuce", "tomato", "pickle" }, 4.99m);
            Menu chickensandwich = new Menu(2, "Chicken Sandwich", "Fried chicken on a bun, with waffle fries and drink included.", new List<string> { "bun", "chicken", "pickle"}, 4.99m);
            Menu hotdog = new Menu(3, "Hotdog", "All-beef hotdog stuck between two sesame seed buns, just like you are at the ballpark.", new List<string> { "hotdog bun", "hotdog" }, 3.99m);
            Menu cheesecake = new Menu(4, "Cheesecake", "One slice of New York-Style cheesecake with a chocolate drizzle on top.", new List<string> { "cheesecake", "chocolate sauce" }, 3.99m);

            _repo.AddMenuItem(cheeseburger);
            _repo.AddMenuItem(chickensandwich);
            _repo.AddMenuItem(hotdog);
            _repo.AddMenuItem(cheesecake);
        }
    }
}
