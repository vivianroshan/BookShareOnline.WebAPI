using System;
using System.Collections.Generic;
using System.Text;

namespace BookShareOnline.WebAPI.Data.Models
{
    public class Rating
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public Book Book { get; set; }
        public int Score { get; set; }
    }
}
