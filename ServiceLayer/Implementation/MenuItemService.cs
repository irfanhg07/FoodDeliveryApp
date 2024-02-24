using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.Generic;
using System.Linq;
using DomainLayer.Model;
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

        public IEnumerable<MenuItem> GetAllMenuItems()
        {
            return _dbContext.MenuItem.ToList();
        }

        public MenuItem GetSingleMenuItem(int menuItemId)
        {
            return _dbContext.MenuItem.FirstOrDefault(m => m.ItemId == menuItemId);
        }

        public MenuItem CreateMenuItem(MenuItem menuItem)
        {
            _dbContext.MenuItem.Add(menuItem);
            _dbContext.SaveChanges();
            return menuItem;
        }

        public bool DeleteMenuItem(int menuItemId)
        {
            var menuItemToDelete = _dbContext.MenuItem.FirstOrDefault(m => m.ItemId == menuItemId);

            if (menuItemToDelete == null)
                return false;

            _dbContext.MenuItem.Remove(menuItemToDelete);
            _dbContext.SaveChanges();
            return true;
        }

        public MenuItem UpdateMenuItem(MenuItem menuItem)
        {
            var existingMenuItem = _dbContext.MenuItem.FirstOrDefault(m => m.ItemId == menuItem.ItemId);

            if (existingMenuItem == null)
                return null;

            existingMenuItem.ItemName = menuItem.ItemName;
            existingMenuItem.Price = menuItem.Price;
            existingMenuItem.RestaurantId = menuItem.RestaurantId;

            _dbContext.SaveChanges();
            return existingMenuItem;
        }

        public IEnumerable<MenuItem> GetMenuItemsForRestaurantId(int restaurantId)
        {
            return _dbContext.MenuItem
                .Where(m => m.RestaurantId == restaurantId)
                .ToList();
        }
    }
}
