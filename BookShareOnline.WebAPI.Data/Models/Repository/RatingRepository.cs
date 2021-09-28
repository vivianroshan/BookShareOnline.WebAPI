using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookShareOnline.WebAPI.Data.Models.Repository
{
    public class RatingRepository : IRatingRepository
    {
        private BookShareContext _context;
        public RatingRepository(BookShareContext context)
        {
            this._context = context;
        }
        public int AddRating(string username, int bookid, int score)
        {
            Book book = _context.Books.FirstOrDefault(a => a.Id == bookid);
            Rating rating = new Rating()
            {
                Username = username,
                Book = book,
                Score = score
            };
            _context.Add(rating);
            return _context.SaveChanges();
        }

        public int Delete(int ratingid)
        {
            Rating rating = _context.Ratings.FirstOrDefault(a => a.Id == ratingid);
            _context.Ratings.Remove(rating);
            return _context.SaveChanges();
        }

        public IEnumerable<Rating> Get()
        {
            return _context.Ratings.ToList();
        }
    }

}
