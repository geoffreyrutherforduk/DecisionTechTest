using CustomerBasket.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerBasket.Services
{
    public class ButterAndBreadDiscount : IProductDiscount
    {
        public decimal ApplyDiscount(Basket basket)
        {
            var totalDiscount = 0.0m;

            if (basket == null)
                return totalDiscount;

            var butterBasketProduct = basket.GetProductByDiscountTag(DiscountTag.Butter);
            var breadBasketProduct = basket.GetProductByDiscountTag(DiscountTag.Bread);

            if (butterBasketProduct.HasValue && breadBasketProduct.HasValue)
            {
                var butterGroupsOf2 = butterBasketProduct.Value.ProductQty / 2;
                var discountAppliedCount = Math.Min(butterGroupsOf2, breadBasketProduct.Value.ProductQty);
                totalDiscount = breadBasketProduct.Value.ProductPrice * 0.5m * discountAppliedCount;
            }
            return totalDiscount;
        }
    }
}
