﻿using CustomerBasket.Entities;
using CustomerBasket.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CustomerBasket.Services
{
    // A wrapper class around a dictionary containing products that are added.
    public class Basket
    {
        public struct BasketProduct
        {
            public int ProductQty { get; set; }
            public decimal ProductPrice { get; set; }
        }

        // Products are stored based on their product Id and store the product price and quantity added.
        private Dictionary<int, BasketProduct> _products = new Dictionary<int, BasketProduct>();

        // Products can also be retrieved by their discount tag which maps to the product Id.
        // Ideally a tag should map to a collection of product Ids rather than a single Id, however this
        // was changed to singular for simplicity of the task.
        private Dictionary<DiscountTag, int> _productDiscountItems = new Dictionary<DiscountTag, int>();

        public void AddToBasket(Product product, int quantity = 1)
        {
            if (product == null)
                return;

            if (quantity < 1)
                return;         

            if (_products.TryGetValue(product.Id, out BasketProduct basketProduct))
            {
                basketProduct.ProductQty += quantity;
                _products[product.Id] = basketProduct;
            }
            else
            {
                _products.Add(product.Id, new BasketProduct
                {
                    ProductQty = quantity,
                    ProductPrice = product.Price
                });
                if (product.DiscountTag.HasValue)
                    _productDiscountItems.Add(product.DiscountTag.Value, product.Id);
            }
        }

        public int GetProductQtyById(int productId)
        {
            if (_products.ContainsKey(productId))
            {
                return _products[productId].ProductQty;
            }
            else
            {
                return 0;
            }
        }

        public BasketProduct? GetProductByDiscountTag(DiscountTag discountTag)
        {
            if (_productDiscountItems.ContainsKey(discountTag))
            {
                var productId = _productDiscountItems[discountTag];
                return _products[productId];
            }
            else
            {
                return null;
            }
        }

        public BasketProduct[] GetBasketProducts()
        {
            return _products.Values.ToArray();
        }
    }
}
