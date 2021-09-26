using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookShareOnline.WebAPI.Data.Models.Repository
{
    public class CartRepository : ICartRepository
    {
        private BookShareContext _context;
        public CartRepository(BookShareContext context)
        {
            _context = context;
        }

        public int Add(CartEntry cartEntry, int bookid)
        {
            cartEntry.Book = _context.Books.FirstOrDefault(a => a.Id == bookid);
            _context.Add(cartEntry);
            return _context.SaveChanges();
        }

        public int Delete(int cartId)
        {
            CartEntry cart = _context.Cart.FirstOrDefault(a => a.Id == cartId);
            if (cart != null)
            {
                _context.Remove(cart);
            }
            return _context.SaveChanges();
        }

        public int Edit(int cartId, CartEntry cartEntry)
        {
            CartEntry oldCartEntry = _context.Cart.FirstOrDefault(a => a.Id == cartId);
            if (oldCartEntry != null)
            {
                cartEntry.Id = oldCartEntry.Id;
                _context.Update(cartEntry);
            }
            return _context.SaveChanges();
        }

        public int Edit(int cartId, string userName, CartEntry cartEntry)
        {
            CartEntry oldCartEntry = _context.Cart.FirstOrDefault(a => a.Id == cartId);
            if (oldCartEntry != null && cartEntry.Buyer == userName)
            {
                cartEntry.Id = oldCartEntry.Id;
                _context.Update(cartEntry);
            }
            return _context.SaveChanges();
        }

        public int Delete(int cartId, string userName)
        {
            CartEntry cartEntry = _context.Cart.FirstOrDefault(a => a.Id == cartId);
            if (cartEntry != null && cartEntry.Buyer==userName)
            {
                _context.Remove(cartEntry);
            }
            return _context.SaveChanges();
        }

        public IEnumerable<CartEntry> Get()
        {
            return _context.Cart.ToList();
        }
        public IEnumerable<CartEntry> Get(string userName)
        {
            return _context.Cart.ToList().Where(a=>a.Buyer==userName);
        }
    }
}
