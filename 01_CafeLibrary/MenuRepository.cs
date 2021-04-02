using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_CafeLibrary
{
    public class MenuRepository
    {

        private List<Menu> _menuDirectory = new List<Menu>();

        public void AddMenuItem(Menu item)
        {
            _menuDirectory.Add(item);
        }

        public Menu GetMenuItemByName(string name)
        {
            foreach (Menu item in _menuDirectory)
            {
                if (item.MealName.ToLower() == name.ToLower())
                {
                    return item;
                }
            }
            return null;
        }

        public bool DeleteMenuItem(Menu item)
        {
            bool wasDeleted = _menuDirectory.Remove(item);
            return wasDeleted;
        }

        public List<Menu> DisplayMenuItems()
        {
            return _menuDirectory;
        }
    }
}
