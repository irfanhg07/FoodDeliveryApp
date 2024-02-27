using Microsoft.AspNetCore.Mvc;
using DomainLayer.Model;
using ServiceLayer.Interface;
using FoodDeliveryApp.Util;
using DomainLayer.DTO.Request;
using DomainLayer.DTO.Response;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using ServiceLayer.Implementation;

namespace PokemonReviewApp.Controllers
{
    [Route("api/v1/UserAddresses")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddress _addressService;
        private readonly IUser _userService;
        private readonly IMapper _mapper;

        public AddressController(IAddress addressService,IUser userService, IMapper mapper)
        {
            _addressService = addressService;
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAddresses()
        {
            var addresses = _addressService.GetAddresses();
            var addressResponses = _mapper.Map<IEnumerable<AddressResponse>>(addresses);
            return ApiResponse.SuccessResponse("Addresses retrieved successfully.", addressResponses, 200);
        }

        [HttpGet("{addressId}")]
        public IActionResult GetAddress(int addressId)
        {
            var address = _addressService.GetAddress(addressId);
            if (address == null)
                return ApiResponse.ErrorResponse("Address not found.", 404);

            var addressResponse = _mapper.Map<AddressResponse>(address);
            return ApiResponse.SuccessResponse("Address retrieved successfully.", addressResponse, 200);
        }

        [HttpPost]
        public IActionResult CreateAddress(int userId, [FromBody] AddressRequest addressRequest)
        {
            if (addressRequest == null)
                return BadRequest("Address data is null.");

            // Create a new address instance
            var address = _mapper.Map<Address>(addressRequest);

            // Try to create the address
            if (!_addressService.CreateAddressForUser(userId, address))
                return ApiResponse.ErrorResponse("Something went wrong while saving the address.", 500);

            // Map the created address to an address response DTO
            var addressResponse = _mapper.Map<AddressResponse>(address);

            // Return a success response
            return ApiResponse.SuccessResponse("Address created successfully.", addressResponse, 201);
        }

        [HttpGet("{userId}/addresses")]
        public IActionResult GetAddressesByUserId(int userId)
        {
            try
            {
                // Check if the user exists
                var userExists = _userService.UserExists(userId);
                if (!userExists)
                {
                    
                    return ApiResponse.ErrorResponse("User does not exist.", 404);
                }

                var addresses = _addressService.GetAddressesByUserId(userId);

               
                if (addresses == null || !addresses.Any())
                {
                    
                    return ApiResponse.SuccessResponse("User does not have any addresses.", new List<AddressResponse>(), 200);
                }

              
                var addressResponses = _mapper.Map<IEnumerable<AddressResponse>>(addresses);

               
                return ApiResponse.SuccessResponse("Addresses retrieved successfully.", addressResponses, 200);
            }
            catch (Exception ex)
            {
               
                return ApiResponse.ErrorResponse("An error occurred while retrieving addresses.", 500);
            }
        }




        [HttpPut("{addressId}")]
        public IActionResult UpdateAddress(int addressId, [FromBody] AddressRequest addressRequest)
        {
            if (addressRequest == null || addressId != addressRequest.AddressId)
                return BadRequest("Invalid address data.");

            var existingAddress = _addressService.GetAddress(addressId);

            if (existingAddress == null)
                return ApiResponse.ErrorResponse("Address not found.", 404);

            _mapper.Map(addressRequest, existingAddress);

            if (!_addressService.UpdateAddress(existingAddress))
                return ApiResponse.ErrorResponse("Something went wrong updating the address.", 500);

            var updatedAddressResponse = _mapper.Map<AddressResponse>(existingAddress);
            return ApiResponse.SuccessResponse("Address updated successfully.", updatedAddressResponse, 200);
        }

        [HttpDelete("{addressId}")]
        public IActionResult DeleteAddress(int addressId)
        {
            if (!_addressService.AddressExists(addressId))
                return ApiResponse.ErrorResponse("Address not found.", 404);

            var address = _addressService.GetAddress(addressId);

            if (!_addressService.DeleteAddress(address))
                return ApiResponse.ErrorResponse("Something went wrong deleting the address.", 500);

            return ApiResponse.SuccessResponse("Address deleted successfully.", null, 204);
        }
    }
}
