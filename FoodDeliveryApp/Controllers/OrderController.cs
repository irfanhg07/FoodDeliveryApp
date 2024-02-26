using DomainLayer.Model;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Implementation;
using ServiceLayer.Interface;
namespace FoodDeliveryApp.Controllers
{
    [Route("api/v1/Order")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrder _OrderService;
        public OrderController(IOrder OrderService)
        {
            _OrderService = OrderService;
        }
        // GET: api/v1/Order
        [HttpGet]
        public IActionResult GetAllOrder()
        {
            var Orders = _OrderService.GetAllOrders();
            return Ok(Orders);
        }
        // GET: api/v1/Order/{id}
        [HttpGet("{id}")]
        public IActionResult GetOrder(int id)
        {
            var user = _OrderService.GetSingleOrder(id);
            if (user == null)
                return NotFound();
            return Ok(user);
        }
        // DELETE: api/v1/Order/{id}
        [HttpDelete("{id}")]
        public IActionResult RemoveOrder(int id)
        {
            if (_OrderService.DeleteOrder(id))
                return NoContent();
            else
                return NotFound();
        }
        // POST: api/v1/Order
        [HttpPost]
        public IActionResult AddOrder([FromBody] Order Order)
        {
            var createdOrder = _OrderService.CreateOrder(Order);
            return Ok(createdOrder);
        }
    }
}