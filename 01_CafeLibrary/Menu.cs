using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_CafeLibrary
{
    public class Menu
    {
        public int MealNumber { get; set; }
        public string MealName { get; set; }
        public string MealDescription { get; set; }
        public List<string> ListOfIngredients { get; set; }
        public decimal Price { get; set; }

        
        public Menu() { }

        
        public Menu(int number, string name, string description, List<string> listOfIngredients, decimal price)
        {
            MealNumber = number;
            MealName = name;
            MealDescription = description;
            ListOfIngredients = listOfIngredients;
            Price = price;
        }

    
    }
}
