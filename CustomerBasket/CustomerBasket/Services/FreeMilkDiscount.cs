using CustomerBasket.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerBasket.Services
{
    public class FreeMilkDiscount : IProductDiscount
    {
        public decimal ApplyDiscount(Basket basket)
        {
            var milkBasketProduct = basket.GetProductByDiscountTag(DiscountTag.Milk);
            if (milkBasketProduct.HasValue)
            {
                var milkGroupsOf4 = milkBasketProduct.Value.ProductQty / 4;
                var milkPrice = milkBasketProduct.Value.ProductPrice;
                return milkPrice * milkGroupsOf4;
            }
            return 0;
        }
    }
}
