using System;
using System.Collections.Generic;
using System.Text;

namespace BookShareOnline.WebAPI.Data.Models.Repository
{
    public interface IRatingRepository
    {
        public IEnumerable<Rating> Get();
        int AddRating(string username, int bookid, int score);
        public int Delete(int ratingid);

    }
}
