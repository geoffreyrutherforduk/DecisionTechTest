using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerBasket
{
    public class FreeMilkDiscount
    {
        public decimal ApplyDiscount(Basket basket)
        {
            basket.Products.TryGetValue(Product.ProductType.Milk, out int milkQty);
            var milkGroupsOf4 = milkQty / 4;
            var milkPrice = 1.15m;
            return milkPrice * milkGroupsOf4;
        }
    }
}
