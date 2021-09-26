using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookShareOnline.WebAPI.Data.Models.Repository
{
    public class BookRepository : IBookRepository
    {
        private BookShareContext _context;
        public BookRepository(BookShareContext context)
        {
            _context=context;
        }
        public int Add(Book book)
        {
            _context.Add(book);
            return _context.SaveChanges();
        }

        public int Delete(int bookId)
        {
            Book book = _context.Books.FirstOrDefault(a => a.Id == bookId);
            if (book != null)
            {
                _context.Remove(book);
            }
            return _context.SaveChanges();
        }

        public int Edit(int bookId, Book book)
        {
            Book oldBook = _context.Books.FirstOrDefault(a => a.Id == bookId);
            if (oldBook != null)
            {
                book.Id = oldBook.Id;
                _context.Update(book);
            }
            return _context.SaveChanges();
        }

        public IEnumerable<Book> Get()
        {
            return _context.Books.ToList();
        }

        public Book Get(string bookName)
        {
            return _context.Books.FirstOrDefault(a => a.Name == bookName);
        }
    }
}
