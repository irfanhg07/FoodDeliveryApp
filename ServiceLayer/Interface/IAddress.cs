using System.Collections.Generic;
using System.Threading.Tasks;
using DomainLayer.Model;

namespace ServiceLayer.Implementation
{
    public interface IAddress
    {
        Task<IEnumerable<Address>> GetAddressesAsync();
        Task<Address> GetAddressByIdAsync(int id);
        Task AddAddressAsync(Address address);
        Task UpdateAddressAsync(Address address);
        Task<bool> AddressExistsAsync(int id);
        Task DeleteAddressAsync(Address address);
    }
}
