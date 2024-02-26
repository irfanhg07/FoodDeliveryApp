using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.Generic;
using DomainLayer.Model;

namespace ServiceLayer.Interface
{
    public interface IMenuItem
    {
        // Retrieve all menu items
        IEnumerable<MenuItem> GetAllMenuItems();

        // Retrieve a single menu item by ID
        MenuItem GetSingleMenuItem(int menuItemId);

        // Create a new menu item
        MenuItem CreateMenuItem(MenuItem menuItem);

        // Delete a menu item by ID
        bool DeleteMenuItem(int menuItemId);

        // Update a menu item
        MenuItem UpdateMenuItem(MenuItem menuItem);
       // IEnumerable<MenuItem> GetMenuItemsByRestaurantId(int restaurantId);

    }
}
