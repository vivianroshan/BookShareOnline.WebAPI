using System;
using System.Collections.Generic;
using System.Text;

namespace BookShareOnline.WebAPI.Data.Models.Repository
{
    public interface IOrderRepository
    {
        IEnumerable<Order> Get();
        IEnumerable<Order> Get(string userName);
        int Edit(int orderId, Order order);
        int Edit(int orderId, string userName, Order order);
        int Edit(int orderId, string userName);
        int Add(Order order);
        int Delete(int ordertId);
        int Delete(int orderId, string userName);
        int AddNew(Order order, int bookid);
    }
}
