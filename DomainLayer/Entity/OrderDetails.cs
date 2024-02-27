using DomainLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Entity
{
    public class OrderDetails
    {
        public int MenuItemId;
        public int OrderId;
        public MenuItem menuItem;
        public Order Order;
    }
}

