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
        //GetAll Users
        List<User> GetAllUsers();

        //GetSingle User
        User GetSingleUser(int id);

        //create user
        String CreateUser(User user);

        //Update user
        String UpdateUser(User user);
        //Delete user
        Boolean DeleteUser(int id);

    }
}
