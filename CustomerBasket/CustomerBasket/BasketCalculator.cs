using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerBasket
{
    public class BasketCalculator
    {
        private readonly Dictionary<Product.ProductType, decimal> _productPrices = new Dictionary<Product.ProductType, decimal>()
        {
            { Product.ProductType.Butter, 0.80m },
            { Product.ProductType.Milk, 1.15m },
            { Product.ProductType.Bread, 1.0m }
        };

        public decimal GetCostOfBasket(Basket basket)
        {
            var totalCost = 0.0m;
            foreach (var product in basket.Products)
            {
                var productPrice = _productPrices[product.Key];
                totalCost += (productPrice * product.Value);
            }
            return totalCost;
        }
    }
}
