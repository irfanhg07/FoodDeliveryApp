using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer.Model;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer;

namespace ServiceLayer.Implementation
{
    public class AddressService : IAddress
    {
        private readonly AppDbContext _dbContext;

        public AddressService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Address>> GetAddressesAsync()
        {
            return await _dbContext.Addresses.ToListAsync();
        }

        public async Task<Address> GetAddressByIdAsync(int id)
        {
            return await _dbContext.Addresses.FindAsync(id);
        }

        public async Task AddAddressAsync(Address address)
        {
            _dbContext.Addresses.Add(address);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAddressAsync(Address address)
        {
            _dbContext.Entry(address).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> AddressExistsAsync(int id)
        {
            return await _dbContext.Addresses.AnyAsync(e => e.AddressId == id);
        }

        public async Task DeleteAddressAsync(Address address)
        {
            _dbContext.Addresses.Remove(address);
            await _dbContext.SaveChangesAsync();
        }
    }
}
