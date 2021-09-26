using System;
using System.Collections.Generic;
using System.Text;

namespace BookShareOnline.WebAPI.Data.Models.Repository
{
    public interface ICartRepository
    {
        IEnumerable<CartEntry> Get();
        IEnumerable<CartEntry> Get(string userName);
        int Edit(int cartId, CartEntry cartEntry);
        int Edit(int cartId, string userName, CartEntry cartEntry);
        int Add(CartEntry cartEntry);
        int Delete(int cartId);
        int Delete(int cartId, string userName);
    }
}
