using DomainLayer.Model;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer;
using ServiceLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ServiceLayer.Implementation
{
    public class AddressService : IAddress
    {
        private readonly AppDbContext _dbContext;

        public AddressService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool CreateAddressForUser(int userId, Address address)
        {
            try
            {
                // Create a new entry in UserAddress table associating the user with the address
                var userAddress = new UserAddress { UserId = userId, Address = address };
                _dbContext.UserAddresses.Add(userAddress);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                
                return false;
            }
        }


        public bool DeleteAddress(Address address)
        {
            try
            {
                _dbContext.Addresses.Remove(address);
                 _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
              
                return false;
            }
        }

        public IEnumerable<Address> GetAddresses()
        {
            return _dbContext.Addresses.ToList();
        }

        public List<Address> GetAddressesByUserId(int userId)
        {
            return _dbContext.UserAddresses
                .Where(ua => ua.UserId == userId)
                .Select(ua => ua.Address)
                .ToList();
        }

        public Address GetAddress(int id)
        {
            return _dbContext.Addresses.Find(id);
        }

        public bool AddressExists(int id)
        {
            return _dbContext.Addresses.Any(a => a.AddressId == id);
        }

        public bool Save()
        {
            try
            {
                return _dbContext.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                
                return false;
            }
        }

        public bool UpdateAddress(Address address)
        {
            try
            {
                _dbContext.Entry(address).State = EntityState.Modified;
                return Save();
            }
            catch (Exception ex)
            {
               
                return false;
            }
        }
    }
}
