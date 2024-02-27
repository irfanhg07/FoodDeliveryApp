//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//using System.Collections.Generic;
//using System.Linq;
//using DomainLayer.Model;
//using ServiceLayer.Interface;
//using RepositoryLayer;

//namespace ServiceLayer
//{
//    public class MenuItemService : IMenuItem
//    {
//        private readonly AppDbContext _dbContext;

//        public MenuItemService(AppDbContext dbContext)
//        {
//            _dbContext = dbContext;
//        }

//        public IEnumerable<MenuItem> GetAllMenuItems()
//        {
//            return _dbContext.MenuItem.ToList();
//        }

//        public MenuItem GetSingleMenuItem(int menuItemId)
//        {
//            return _dbContext.MenuItem.FirstOrDefault(m => m.ItemId == menuItemId);
//        }

//        public MenuItem CreateMenuItem(MenuItem menuItem)
//        {
//            _dbContext.MenuItem.Add(menuItem);
//            _dbContext.SaveChanges();
//            return menuItem;
//        }

//        public bool DeleteMenuItem(int menuItemId)
//        {
//            var menuItemToDelete = _dbContext.MenuItem.FirstOrDefault(m => m.ItemId == menuItemId);

//            if (menuItemToDelete == null)
//                return false;

//            _dbContext.MenuItem.Remove(menuItemToDelete);
//            _dbContext.SaveChanges();
//            return true;
//        }

//        public MenuItem UpdateMenuItem(MenuItem menuItem)
//        {
//            var existingMenuItem = _dbContext.MenuItem.FirstOrDefault(m => m.ItemId == menuItem.ItemId);

//            if (existingMenuItem == null)
//                return null;

//            existingMenuItem.ItemName = menuItem.ItemName;
//            existingMenuItem.Price = menuItem.Price;
//            existingMenuItem.RestaurantId = menuItem.RestaurantId;

//            _dbContext.SaveChanges();
//            return existingMenuItem;
//        }

//        public IEnumerable<MenuItem> GetMenuItemsForRestaurantId(int restaurantId)
//        {
//            return _dbContext.MenuItem
//                .Where(m => m.RestaurantId == restaurantId)
//                .ToList();
//        }
//    }
//}
using System.Collections.Generic;
using System.Linq;
using DomainLayer.Model;
using DomainLayer.DTO.Request; // Add this namespace for MenuItemRequest
using DomainLayer.DTO.Response; // Add this namespace for MenuItemResponse
using ServiceLayer.Interface;
using RepositoryLayer;


namespace ServiceLayer
{
    public class MenuItemService : IMenuItem
    {
        private readonly AppDbContext _dbContext;

        public MenuItemService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        //public IEnumerable<MenuItemResponse> GetAllMenuItems()
        //{
        //    var menuItems = _dbContext.MenuItem.Where(p => p.IsDeleted == false).ToList();
        //    return menuItems.Select(menuItem => MapMenuItemToResponse(menuItem));
        //}
        public IEnumerable<MenuItemResponse> GetAllMenuItems(int pageNumber, int pageSize)
        {
            int itemsToSkip = (pageNumber - 1) * pageSize;

            var menuItems = _dbContext.MenuItem
                .Where(p => p.IsDeleted == false)
                .Skip(itemsToSkip)
                .Take(pageSize)
                .ToList();

            return menuItems.Select(menuItem => MapMenuItemToResponse(menuItem));
        }


        public MenuItemResponse GetSingleMenuItem(int menuItemId)
        {
            var menuItem = _dbContext.MenuItem.FirstOrDefault(m => m.ItemId == menuItemId);
            return menuItem != null ? MapMenuItemToResponse(menuItem) : null;
        }

        public MenuItemResponse CreateMenuItem(MenuItemRequest menuItemRequest)
        {
            var newMenuItem = new MenuItem
            {
                ItemName = menuItemRequest.ItemName,
                Price = menuItemRequest.Price,
                RestaurantId = menuItemRequest.RestaurantId
            };

            _dbContext.MenuItem.Add(newMenuItem);
            _dbContext.SaveChanges();

            return MapMenuItemToResponse(newMenuItem);
        }

        public bool DeleteMenuItem(int menuItemId)
        {
            var menuItemToDelete = _dbContext.MenuItem.FirstOrDefault(m => m.ItemId == menuItemId);

            if (menuItemToDelete == null)
            {

                return false;
            }
            menuItemToDelete.IsDeleted = true;
            _dbContext.SaveChanges();
            return true;
        }

        public MenuItemResponse UpdateMenuItem(MenuItemRequest menuItemRequest, int menuItemId)
        {
            var existingMenuItem = _dbContext.MenuItem.FirstOrDefault(m => m.ItemId == menuItemId);

            if (existingMenuItem == null)
                return null;

            existingMenuItem.ItemName = menuItemRequest.ItemName;
            existingMenuItem.Price = menuItemRequest.Price;
            existingMenuItem.RestaurantId = menuItemRequest.RestaurantId;

            _dbContext.SaveChanges();
            return MapMenuItemToResponse(existingMenuItem);
        }

        public IEnumerable<MenuItemResponse> GetMenuItemsForRestaurantId(int restaurantId)
        {
            var menuItems = _dbContext.MenuItem
                .Where(m => m.RestaurantId == restaurantId)
                .ToList();

            return menuItems.Select(menuItem => MapMenuItemToResponse(menuItem));
        }

        // Helper method to map MenuItem to MenuItemResponse
        private MenuItemResponse MapMenuItemToResponse(MenuItem menuItem)
        {
            return new MenuItemResponse(menuItem.ItemId, menuItem.ItemName, menuItem.Price, menuItem.RestaurantId);
        }
        public IEnumerable<MenuItemResponse> GetMenuItemsByRestaurant(int restaurantId)
        {
            var menuItems = _dbContext.MenuItem
                .Where(item => item.RestaurantId == restaurantId)
                .Select(item => new MenuItemResponse(
                    item.ItemId,
                    item.ItemName,
                    item.Price,
                    item.RestaurantId
                ))
                .ToList();

            return menuItems;
        }



    }
}
