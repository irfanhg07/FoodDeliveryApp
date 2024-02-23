using DomainLayer.Model;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Interface;

namespace FoodDeliveryApp.Controllers
{
    [Route("api/v1/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUser _userService;

        public UserController(IUser userService)
        {
            _userService = userService;
        }

        // GET: api/v1/users
        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var users = _userService.GetAllUsers();
            return Ok(users);
        }

        // GET: api/v1/users/{id}
        [HttpGet("{id}")]
        public IActionResult GetUser(int id)
        {
            var user = _userService.GetSingleUser(id);
            if (user == null)
                return NotFound();

            return Ok(user);
        }

        // POST: api/v1/users
        [HttpPost]
        public IActionResult AddUser([FromBody] User user)
        {
            var createdUser = _userService.CreateUser(user);
            return Ok(createdUser);
        }

        // DELETE: api/v1/users/{id}
        [HttpDelete("{id}")]
        public IActionResult RemoveUser(int id)
        {
            if (_userService.DeleteUser(id))
                return NoContent(); 
            else
                return NotFound(); 
        }

        // PUT: api/v1/users/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, [FromBody] User user)
        {
            if (id != user.Id)
                return BadRequest(); 

            var updatedUser = _userService.UpdateUser(user);
            if (updatedUser == null)
                return NotFound(); 

            return Ok(updatedUser);
        }
    }
}
