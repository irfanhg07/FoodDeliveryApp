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
    public class RestaurantService : IRestaurant
    {
        private readonly AppDbContext _dbContext;

        public RestaurantService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Restaurant> GetAllRestaurants()
        {
            return _dbContext.Restaurants.ToList();
        }
        //public IEnumerable<MenuItem> GetMenuItemsForRestaurant(int restaurantId)
        //{
        //    return _dbContext.MenuItem
        //        .Where(m => m.RestaurantId == restaurantId)
        //        .ToList();
        //}
        public Restaurant GetSingleRestaurant(int restaurantId)
        {
            return _dbContext.Restaurants.FirstOrDefault(r => r.RestaurantId == restaurantId);
        }

        public Restaurant CreateRestaurant(Restaurant restaurant)
        {
            _dbContext.Restaurants.Add(restaurant);
            _dbContext.SaveChanges();
            return restaurant;
        }

        public bool DeleteRestaurant(int restaurantId)
        {
            var restaurantToDelete = _dbContext.Restaurants.FirstOrDefault(r => r.RestaurantId == restaurantId);

            if (restaurantToDelete == null)
                return false;

            _dbContext.Restaurants.Remove(restaurantToDelete);
            _dbContext.SaveChanges();
            return true;
        }

        public Restaurant UpdateRestaurant(Restaurant restaurant)
        {
            var existingRestaurant = _dbContext.Restaurants.FirstOrDefault(r => r.RestaurantId == restaurant.RestaurantId);

            if (existingRestaurant == null)
                return null;

            existingRestaurant.Name = restaurant.Name;
            existingRestaurant.Address = restaurant.Address;
            existingRestaurant.Phone = restaurant.Phone;
            existingRestaurant.Description = restaurant.Description;

            _dbContext.SaveChanges();
            return existingRestaurant;
        }
    }
}

