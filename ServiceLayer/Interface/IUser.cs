using DomainLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Interface
{ 
    public interface IUser
    { 

    public List<User> GetUsers();
    public User GetUser(int id);
    public bool UserExists(int id);
    public bool CreateUser(User user);
    public bool UpdateUser(User user);
    public bool DeleteUser(User user);
    public bool Save();
}
}
