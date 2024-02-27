using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.Generic;
using DomainLayer.Model;

//namespace ServiceLayer.Interface
//{
//    public interface IMenuItem
//    {
//        // Retrieve all menu items
//        IEnumerable<MenuItem> GetAllMenuItems();

//        // Retrieve a single menu item by ID
//        MenuItem GetSingleMenuItem(int menuItemId);

//        // Create a new menu item
//        MenuItem CreateMenuItem(MenuItem menuItem);

//        // Delete a menu item by ID
//        bool DeleteMenuItem(int menuItemId);

//        // Update a menu item
//        MenuItem UpdateMenuItem(MenuItem menuItem);
//       // IEnumerable<MenuItem> GetMenuItemsByRestaurantId(int restaurantId);

//    }
//}
using System.Collections.Generic;
using DomainLayer.DTO.Request;
using DomainLayer.DTO.Response;
using DomainLayer.Model;
using DomainLayer.DTO.Request; 
using DomainLayer.DTO.Response; 

namespace ServiceLayer.Interface
{
    public interface IMenuItem
    {
        // Retrieve all menu items
        IEnumerable<MenuItemResponse> GetAllMenuItems(int pageNumber, int pageSize);


        // Retrieve a single menu item by ID
        MenuItemResponse GetSingleMenuItem(int menuItemId);

        // Create a new menu item
        MenuItemResponse CreateMenuItem(MenuItemRequest menuItemRequest);

        // Delete a menu item by ID
        bool DeleteMenuItem(int menuItemId);
        IEnumerable<MenuItemResponse> GetMenuItemsByRestaurant(int restaurantId); // Add this method


        // Update a menu item
        //MenuItemResponse UpdateMenuItem(MenuItemRequest menuItemRequest, int menuItemId);

        // Retrieve all menu items for a specific restaurant
        //IEnumerable<MenuItemResponse> GetMenuItemsForRestaurantId(int restaurantId);
        //MenuItemResponse UpdateMenuItem(int id, MenuItemRequest menuItemRequest);
    }
}
