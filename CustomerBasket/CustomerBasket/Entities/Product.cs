using CustomerBasket.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerBasket.Entities
{
    // Product entity that'll most likely come from the repository
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        // A tag attached to a product to be used for discounting purposes.
        // Nullable type since not all products may be discountable.
        public DiscountTag? DiscountTag { get; set; }
    }
}
