using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerBasket.Services
{
    public class BasketCalculator
    {
        private IProductDiscount[] _productDiscounts;

        // Inject the discounts into the constructor so the discounts are more flexible
        // to apply or remove. Also, calculator can be unit tested independently of the discounts.
        public BasketCalculator(params IProductDiscount[] productDiscounts)
        {
            _productDiscounts = productDiscounts ?? new IProductDiscount[0];
        }

        public decimal GetCostOfBasket(Basket basket)
        {            
            var totalCost = 0.0m;

            if (basket == null)
                return totalCost;

            foreach (var basketProduct in basket.GetBasketProducts())
            {
                totalCost += (basketProduct.ProductPrice * basketProduct.ProductQty);
            }
            foreach (var productDiscount in _productDiscounts)
            {
                totalCost -= productDiscount.ApplyDiscount(basket);
            }
            return totalCost;
        }
    }
}
