using System;
using System.Collections.Generic;
using static CustomerBasket.Product;

namespace CustomerBasket
{
    public class Basket
    {
        private Dictionary<ProductType, int> _products = new Dictionary<ProductType, int>();
        
        public void AddToBasket(ProductType product, int quantity = 1)
        {
            if (quantity < 1)
            {
                return;
            }

            if (_products.TryGetValue(product, out int currentQuantity))
            {
                currentQuantity += quantity;
                _products[product] = currentQuantity;
            }
            else
            {
                _products.Add(product, quantity);
            }
        }

        public int GetProductQuantity(Product.ProductType product)
        {
            _products.TryGetValue(product, out int productQty);
            return productQty;
        }
    }
}
