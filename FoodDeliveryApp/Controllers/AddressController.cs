using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DomainLayer.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net;
using ServiceLayer.Implementation;

namespace YourNamespace.Controllers
{
    [Route("api/v1/UserAddresses")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddress _addressService;  

        public AddressController(IAddress addressService)  
        {
            _addressService = addressService;
        }

        // GET: api/Address
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Address>>> GetAddresses()
        {
            var addresses = await _addressService.GetAddressesAsync(); 
            return Ok(addresses);
        }

        // GET: api/Address/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Address>> GetAddress(int id)
        {
            var address = await _addressService.GetAddressByIdAsync(id); 

            if (address == null)
            {
                return NotFound();
            }

            return Ok(address);
        }

        // POST: api/Address
        [HttpPost]
        public async Task<ActionResult<Address>> PostAddress(Address address)
        {
            await _addressService.AddAddressAsync(address); 
            return CreatedAtAction("GetAddress", new { id = address.AddressId }, address);
        }

        // PUT: api/Address/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAddress(int id, Address address)
        {
            if (id != address.AddressId)
            {
                return BadRequest();
            }

            try
            {
                await _addressService.UpdateAddressAsync(address); 
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _addressService.AddressExistsAsync(id))  
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/Address/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAddress(int id)
        {
            var address = await _addressService.GetAddressByIdAsync(id);  
            if (address == null)
            {
                return NotFound();
            }

            await _addressService.DeleteAddressAsync(address);  
            return NoContent();
        }
    }
}
