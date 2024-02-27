using System.Collections.Generic;
using System.Threading.Tasks;
using DomainLayer.Model;

namespace ServiceLayer.Implementation
{
    public interface IAddress
    {
        IEnumerable<Address> GetAddresses();
        Address GetAddress(int id);
        bool AddressExists(int id);
        public bool CreateAddressForUser(int userId, Address address);
        List<Address> GetAddressesByUserId(int userId);
        bool UpdateAddress(Address address);
        bool DeleteAddress(Address address);
    }
}
