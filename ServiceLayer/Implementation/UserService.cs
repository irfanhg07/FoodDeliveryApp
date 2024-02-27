using DomainLayer.Model;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer;
using ServiceLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Implementation
{
    public class UserService : IUser

    {
        private readonly AppDbContext _dbContext;

        public UserService(AppDbContext dbContext) {
            _dbContext = dbContext;
        }
        //Create User
        public bool CreateUser(User user)
        {
            try
            {
                _dbContext.Users.Add(user);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
               
                return false;
            }
        }

        public bool DeleteUser(User user)
        {
            try
            {
                _dbContext.Users.Remove(user);
                return Save();
            }
            catch (Exception ex)
            {
                // Handle exception appropriately, e.g., log the error
                return false;
            }
        }

        public List<User> GetUsers()
        {
            return _dbContext.Users.ToList();
        }

        public User GetUser(int id)
        {
            return _dbContext.Users.Find(id);
        }

        public bool UserExists(int id)
        {
            return _dbContext.Users.Any(u => u.UserId == id);
        }

        public bool Save()
        {
            try
            {
                return _dbContext.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                // Handle exception appropriately, e.g., log the error
                return false;
            }
        }

        public bool UpdateUser(User user)
        {
            try
            {
                _dbContext.Entry(user).State = EntityState.Modified;
                return Save();
            }
            catch (Exception ex)
            {
                // Handle exception appropriately, e.g., log the error
                return false;
            }
        }

       
    }
}
