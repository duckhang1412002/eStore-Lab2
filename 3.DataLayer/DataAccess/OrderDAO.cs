using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessObject;

namespace DataAccess
{
    public class OrderDAO
    {
        public IEnumerable<OrderObject> GetOrderList() {
            var orders = new List<OrderObject>();
            try {
                using var context = new eStoreContext();
                orders = context.Orders.ToList();
            } catch (Exception) {
                //
            }
            return orders;
        }
    }
}