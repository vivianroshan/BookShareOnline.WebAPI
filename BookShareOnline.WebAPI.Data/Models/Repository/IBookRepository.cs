using System;
using System.Collections.Generic;
using System.Text;

namespace BookShareOnline.WebAPI.Data.Models.Repository
{
    public interface IBookRepository
    {
        IEnumerable<Book> Get();
        Book Get(string BookName);
        int Edit(int bookId, Book book);
        int Add(Book book);
        int Delete(int bookId);
    }
}
