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
       
        IEnumerable<Restaurant> GetAllRestaurants();

        
        Restaurant GetSingleRestaurant(int restaurantId);

        Restaurant CreateRestaurant(Restaurant restaurant);

      
        bool DeleteRestaurant(int restaurantId);
     

        Restaurant UpdateRestaurant(Restaurant restaurant);
    }
}
