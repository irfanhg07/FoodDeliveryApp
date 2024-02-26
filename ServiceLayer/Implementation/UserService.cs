using DomainLayer.Model;
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
        public string CreateUser(User user)
        {
            try
            {
                this._dbContext.Users.Add(user);
                this._dbContext.SaveChanges();
                return "Success";
            }
            catch (Exception ex)
            {
                return ex.Message;  
            }
        }


        //Delete User
        public Boolean DeleteUser(int id)
        {
            try
            {
                this._dbContext.Users.Find(id);
                this._dbContext.Remove(id);
                this._dbContext.SaveChanges();
                return true;
            }catch (Exception ex)
            {
                
                return false;
            }
        }

        //Get All Users
        public List<User> GetAllUsers()
        {
            return _dbContext.Users.ToList();
        }

        //Get  a single user
        public User GetSingleUser(int id)
        {
            // return this._dbContext.Users.Where(x=>x.Id==id).FirstOrDefault();
            return this._dbContext.Users.Find(id);
        }

        //Update a User
        public string UpdateUser(User user)
        {
            try
            {


                var userValue = this._dbContext.Users.Find(user.UserId);
                if (userValue != null)
                {
                    userValue.UserName = user.UserName;
                    return "successfully updated";

                }
                else
                {
                    return "No record found";
                }
            }
            catch(Exception ex) {
                return ex.Message;  
            
            }
          

        }
    }
}
