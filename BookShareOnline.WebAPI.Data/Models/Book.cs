using System;
using System.Collections.Generic;
using System.Text;

namespace BookShareOnline.WebAPI.Data.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Category { get; set; }
        public string Author { get; set; }
        public string Details { get; set; }
        public string Seller { get; set; }

        //public string PhotoFileName { get; set; }
    }
}
