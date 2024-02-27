using DomainLayer.DTO.Response;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Interface;
using DomainLayer.DTO.Request;
using DomainLayer.DTO;

using System.Net;
using Wps.WebApi.Middlewares.Exceptions;

namespace FoodDeliveryApp.Controllers
{
    [Route("api/v1/menuitems")]
    [ApiController]
    public class MenuItemController : ControllerBase
    {
        private readonly IMenuItem _menuItemService;

        public MenuItemController(IMenuItem menuItemService)
        {
            _menuItemService = menuItemService;
        }

        // GET: api/v1/menuitems
        [HttpGet]
        public IActionResult GetAllMenuItems([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 3)
        {
            IEnumerable<MenuItemResponse> menuItems = _menuItemService.GetAllMenuItems(pageNumber, pageSize);

            var apiResponse = new ApiResponse<MenuItemResponse>(menuItems);
            return Ok(apiResponse);
        }

        // GET: api/v1/menuitems/{id}
        [HttpGet("{id}")]
        public IActionResult GetMenuItem(int id)
        {
            MenuItemResponse menuItem = _menuItemService.GetSingleMenuItem(id);

            if (menuItem == null)
                return NotFound();

            var apiResponse = new ApiResponse<MenuItemResponse>(menuItem);
            return Ok(apiResponse);
        }


        // POST: api/v1/menuitems
        [HttpPost]
        public IActionResult AddMenuItem([FromBody] MenuItemRequest menuItemRequest)
        {
            if (menuItemRequest == null)
            {
                throw new WpsException("MenuItem cannot be null", "WPS001", HttpStatusCode.BadRequest);
            }

            // Validate ItemName
            if (string.IsNullOrEmpty(menuItemRequest.ItemName))
            {
                throw new WpsException("ItemName cannot be null or empty", "WPS002", HttpStatusCode.BadRequest);
            }

            // Validate Price
            if (menuItemRequest.Price <= 0)
            {
                throw new WpsException("Price must be greater than zero", "WPS003", HttpStatusCode.BadRequest);
            }

            // Validate RestaurantId
            if (menuItemRequest.RestaurantId <= 0)
            {
                throw new WpsException("RestaurantId must be greater than zero", "WPS004", HttpStatusCode.BadRequest);
            }

            MenuItemResponse createdMenuItem = _menuItemService.CreateMenuItem(menuItemRequest);

            var apiResponse = new ApiResponse<MenuItemResponse>(createdMenuItem);
            return Ok(apiResponse);

        }


        // DELETE: api/v1/menuitems/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteMenuItem(int id)
        {
            if (_menuItemService.DeleteMenuItem(id))
            {
                var apiResponse = new ApiResponse<MenuItemResponse>(new List<MenuItemResponse>());
                return Ok(apiResponse);
            }
            else
                return NotFound();
        }

        // GET: api/v1/menuitems/resturant/{restaurantId}
        [HttpGet("restaurant/{restaurantId}")]
        public IActionResult GetMenuItemsByRestaurant(int restaurantId)
        {
            IEnumerable<MenuItemResponse> menuItems = _menuItemService.GetMenuItemsByRestaurant(restaurantId);

            if (menuItems == null || !menuItems.Any())
                return NotFound();

            var apiResponse = new ApiResponse<MenuItemResponse>(menuItems);
            return Ok(apiResponse);
        }



    }
}
