using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookShareOnline.WebAPI.Data.Models.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private BookShareContext _context;
        public OrderRepository(BookShareContext context)
        {
            _context = context;
        }

        public int Add(Order order)
        {
            _context.Add(order);
            return _context.SaveChanges();
        }

        public int AddNew(Order order, int bookid)
        {
            order.Book = _context.Books.FirstOrDefault(a => a.Id == bookid);
            _context.Add(order);
            return _context.SaveChanges();
        }

        public int Delete(int orderId)
        {
            Order order = _context.Orders.FirstOrDefault(a => a.Id == orderId);
            if (order != null)
            {
                _context.Remove(order);
            }
            return _context.SaveChanges();
        }

        public int Delete(int orderId, string userName)
        {
            Order order = _context.Orders.FirstOrDefault(a => a.Id == orderId);
            if (order != null && order.Buyer == userName)
            {
                _context.Remove(order);
            }
            return _context.SaveChanges();
        }

        public int Edit(int orderId, Order order)
        {
            Order oldOrder = _context.Orders.FirstOrDefault(a => a.Id == orderId);
            if (oldOrder != null)
            {
                order.Id = oldOrder.Id;
                _context.Update(order);
            }
            return _context.SaveChanges();
        }

        public int Edit(int orderId, string userName, Order order)
        {
            Order oldOrderEntry = _context.Orders.FirstOrDefault(a => a.Id == orderId);
            if (oldOrderEntry != null && oldOrderEntry.Buyer == userName)
            {
                order.Id = oldOrderEntry.Id;
                _context.Update(order);
            }
            return _context.SaveChanges();
        }

        public int Edit(int orderId, string userName)
        {
            Order oldOrderEntry = _context.Orders.FirstOrDefault(a => a.Id == orderId);
            if (oldOrderEntry != null && oldOrderEntry.Buyer == userName)
            {
                 oldOrderEntry.Status = "Canceled";
                _context.Update(oldOrderEntry);
            }
            return _context.SaveChanges();
        }

        public IEnumerable<Order> Get()
        {
            return _context.Orders.ToList();
        }

        public IEnumerable<Order> Get(string userName)
        {
            return _context.Orders.ToList().Where(a => a.Buyer == userName);
        }
    }
}
