using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_KomodoCafe.Repository
{
    public class MenuItemRepository
    //Create a Program file that allows the cafe manager to add, delete, and see all items in the menu list.
    {
        public List<MenuItem> _items = new List<MenuItem>();
        private int _count;

        public bool AddMenuItem(MenuItem newMenuItem)
        {
            if (newMenuItem == null)
            {
                return false;
            }
            else
            {
                _count++;
                newMenuItem.ComboNumber = _count;
                _items.Add(newMenuItem);
                return true;
            }
        }

        public List<MenuItem> GetAllMenuItems()
        {
            return _items;
        }

        public MenuItem GetMenuItem(int index)
        {
            foreach (var item in _items)
            {
                if (item.ComboNumber == index)
                {
                    return item;
                }
            }
            return null;
        }
        public bool DeleteExsistingMenuItem(MenuItem existingItem)
        {
            bool deleteResult = _items.Remove(existingItem);
            return deleteResult;
        }

    }
}
