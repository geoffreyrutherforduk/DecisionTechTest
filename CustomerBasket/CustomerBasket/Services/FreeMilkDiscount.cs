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
            var totalDiscount = 0.0m;

            if (basket == null)
                return totalDiscount;

            var milkBasketProduct = basket.GetProductByDiscountTag(DiscountTag.Milk);
            if (milkBasketProduct.HasValue)
            {
                var milkGroupsOf4 = milkBasketProduct.Value.ProductQty / 4;
                var milkPrice = milkBasketProduct.Value.ProductPrice;
                totalDiscount = (milkPrice * milkGroupsOf4);
            }
            return totalDiscount;
        }
    }
}
