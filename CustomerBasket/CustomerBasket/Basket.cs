using System;
using System.Collections.Generic;
using static CustomerBasket.Product;

namespace CustomerBasket
{
    public class Basket
    {
        public Dictionary<ProductType, int> Products { get; private set; } = new Dictionary<ProductType, int>();

        public void AddToBasket(ProductType product, int quantity = 1)
        {
            if (quantity < 1)
            {
                return;
            }

            if (Products.TryGetValue(product, out int currentQuantity))
            {
                currentQuantity += quantity;
                Products[product] = currentQuantity;
            }
            else
            {
                Products.Add(product, quantity);
            }
        }

        public int GetProductQuantity(Product.ProductType product)
        {
            Products.TryGetValue(product, out int productQty);
            return productQty;
        }
    }
}
