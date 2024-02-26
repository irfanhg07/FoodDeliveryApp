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
    public class OrderService : IOrder
    {
        private readonly AppDbContext _dbContext;
        public OrderService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        //Create Order
        public string CreateOrder(Order Order)
        {
            try
            {
                this._dbContext.Orders.Add(Order);
                this._dbContext.SaveChanges();
                return "Success";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        //Delete Order
        public Boolean DeleteOrder(int id)
        {
            try
            {
                this._dbContext.Orders.Find(id);
                this._dbContext.Remove(id);
                this._dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        //Get  a single Order
        public Order GetSingleOrder(int id)
        {
            // return this._dbContext.Users.Where(x=>x.Id==id).FirstOrDefault();
            return this._dbContext.Orders.Find(id);
        }
        List<Order> IOrder.GetAllOrders()
        {
            return _dbContext.Orders.ToList();
        }
    }
}