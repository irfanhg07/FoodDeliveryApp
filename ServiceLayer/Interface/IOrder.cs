using DomainLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ServiceLayer.Interface
{
    public interface IOrder
    {
        //GetAll Orders
        List<Order> GetAllOrders();
        //GetSingle User
        Order GetSingleOrder(int OrderId);
        //create user
        String CreateOrder(Order Order);
        //Delete user
        Boolean DeleteOrder(int OrderId);
    }
}