using System;
using System.Collections.Generic;
using System.Text;

namespace BookShareOnline.WebAPI.Data.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string Buyer { get; set; }
        public Book Book { get; set; }
        public int Quantity { get; set; }
        public string Status { get; set; }
    }
}
