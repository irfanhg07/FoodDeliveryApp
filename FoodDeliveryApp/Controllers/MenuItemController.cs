using DomainLayer.Model;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Interface;

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
        public IActionResult GetAllMenuItems()
        {
            var menuItems = _menuItemService.GetAllMenuItems();
            return Ok(menuItems);
        }

        // GET: api/v1/menuitems/{id}
        [HttpGet("{id}")]
        public IActionResult GetMenuItem(int id)
        {
            var menuItem = _menuItemService.GetSingleMenuItem(id);
            if (menuItem == null)
                return NotFound();

            return Ok(menuItem);
        }

        // POST: api/v1/menuitems
        [HttpPost]
        public IActionResult AddMenuItem([FromBody] MenuItem menuItem)
        {
            var createdMenuItem = _menuItemService.CreateMenuItem(menuItem);
            return Ok(createdMenuItem);
        }

        // DELETE: api/v1/menuitems/{id}
        [HttpDelete("{id}")]
        public IActionResult RemoveMenuItem(int id)
        {
            if (_menuItemService.DeleteMenuItem(id))
                return NoContent();
            else
                return NotFound();
        }

        // PUT: api/v1/menuitems/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateMenuItem(int id, [FromBody] MenuItem menuItem)
        {
            if (id != menuItem.ItemId)
                return BadRequest();

            var updatedMenuItem = _menuItemService.UpdateMenuItem(menuItem);
            if (updatedMenuItem == null)
                return NotFound();

            return Ok(updatedMenuItem);
        }
    }
}
