using DomainLayer.Model;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Interface;

namespace FoodDeliveryApp.Controllers
{
    [Route("api/v1/restaurants")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private readonly IRestaurant _restaurantService;
        //private readonly IMenuItem _menuItemService; // Add the MenuItem service

        public RestaurantController(IRestaurant restaurantService, IMenuItem menuItemService)
        {
            _restaurantService = restaurantService;
            //_menuItemService = menuItemService;
        }

        // GET: api/v1/restaurants
        [HttpGet]
        public IActionResult GetAllRestaurants()
        {
            var restaurants = _restaurantService.GetAllRestaurants();
            return Ok(restaurants);
        }

        // GET: api/v1/restaurants/{id}
        [HttpGet("{id}")]
        public IActionResult GetRestaurant(int id)
        {
            var restaurant = _restaurantService.GetSingleRestaurant(id);
            if (restaurant == null)
                return NotFound();

            return Ok(restaurant);
        }

        // POST: api/v1/restaurants
        [HttpPost]
        public IActionResult AddRestaurant([FromBody] Restaurant restaurant)
        {
            var createdRestaurant = _restaurantService.CreateRestaurant(restaurant);
            return Ok(createdRestaurant);
        }

        // DELETE: api/v1/restaurants/{id}
        [HttpDelete("{id}")]
        public IActionResult RemoveRestaurant(int id)
        {
            if (_restaurantService.DeleteRestaurant(id))
                return NoContent();
            else
                return NotFound();
        }

        // PUT: api/v1/restaurants/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateRestaurant(int id, [FromBody] Restaurant restaurant)
        {
            if (id != restaurant.RestaurantId)
                return BadRequest();

            var updatedRestaurant = _restaurantService.UpdateRestaurant(restaurant);
            if (updatedRestaurant == null)
                return NotFound();

            return Ok(updatedRestaurant);
        }
       // [HttpGet("{id}/menuitems")]
        //public IActionResult GetMenuItemsForRestaurant(int id)
        //{
        //    var restaurant = _restaurantService.GetSingleRestaurant(id);

        //    if (restaurant == null)
        //        return NotFound();

        //    var menuItems = _menuItemService.GetMenuItemsByRestaurantId(id);
        //    return Ok(menuItems);
        //}
    }
}
