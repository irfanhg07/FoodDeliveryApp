using AutoMapper;
using DomainLayer.Model;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Interface;
using FoodDeliveryApp.Util;
using DomainLayer.DTO.Request;
using DomainLayer.DTO.Response;
using System.Net;

namespace PokemonReviewApp.Controllers
{
    [Route("api/v1/User")]
    public class UserController : ControllerBase
    {
        private readonly IUser _userService;
        private readonly IMapper _mapper;

        public UserController(IUser userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            var users = _userService.GetUsers();
            var userResponses = _mapper.Map<IEnumerable<UserResponse>>(users);
            return ApiResponse.SuccessResponse("Users retrieved successfully.", userResponses, 200);
        }


        [HttpGet("{userId}")]
        public IActionResult GetUser(int userId)
        {
            var user = _userService.GetUser(userId);
            if (user == null)
                return ApiResponse.ErrorResponse("User not found.", 404);

            var userResponse = _mapper.Map<UserResponse>(user);
            return ApiResponse.SuccessResponse("User retrieved successfully.", userResponse, 200);
        }


        [HttpPost]
        public IActionResult CreateUser([FromBody] UserRequest userRequest)
        {
            if (userRequest == null)
                return BadRequest("User data is null.");

            if (_userService.UserExists(userRequest.Id))
                return Conflict("User already exists.");

            var user = _mapper.Map<User>(userRequest);

            if (!_userService.CreateUser(user))
                return ApiResponse.ErrorResponse("Something went wrong while saving the user.", 500);

            var userResponse = _mapper.Map<UserResponse>(user);

            return ApiResponse.SuccessResponse("User created successfully.", user, 201);
        }

        [HttpPut("{userId}")]
        public IActionResult UpdateUser(int userId, [FromBody] UserRequest userRequest)
        {
            if (userRequest == null || userId != userRequest.Id)
                return BadRequest("Invalid user data.");

            var existingUser = _userService.GetUser(userId);

            if (existingUser == null)
                return ApiResponse.ErrorResponse("User not found.", 404);

            // Update the existing user with data from the request
            _mapper.Map(userRequest, existingUser);

            if (!_userService.UpdateUser(existingUser))
                return ApiResponse.ErrorResponse("Something went wrong updating the user.", 500);

            // Map the updated user to a response DTO
            var updatedUserResponse = _mapper.Map<UserResponse>(existingUser);

            return ApiResponse.SuccessResponse("User updated successfully.", updatedUserResponse, 200);
        }


        [HttpDelete("{userId}")]
        public IActionResult DeleteUser(int userId)
        {
            if (!_userService.UserExists(userId))
                return ApiResponse.ErrorResponse("User not found.", 404);

            var user = _userService.GetUser(userId);

            if (!_userService.DeleteUser(user))
                return ApiResponse.ErrorResponse("Something went wrong deleting the user.", 500);

            return ApiResponse.SuccessResponse("User deleted successfully.", null, 204);
        }

    }
}
