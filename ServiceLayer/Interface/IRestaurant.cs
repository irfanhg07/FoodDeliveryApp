using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.Generic;
using DomainLayer.Model;

namespace ServiceLayer.Interface
{
    public interface IRestaurant
    {
        // Retrieve all restaurants
        IEnumerable<Restaurant> GetAllRestaurants();

        // Retrieve a single restaurant by ID
        Restaurant GetSingleRestaurant(int restaurantId);

        // Create a new restaurant
        Restaurant CreateRestaurant(Restaurant restaurant);

        // Delete a restaurant by ID
        bool DeleteRestaurant(int restaurantId);
        //IEnumerable<MenuItem> GetMenuItemsForRestaurant(int restaurantId);


        // Update a restaurant
        Restaurant UpdateRestaurant(Restaurant restaurant);
    }
}
