using CustomerBasket.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerBasket.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public DiscountTag? DiscountTag { get; set; }
    }
}
