using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerBasket.Tests
{
    [TestFixture]
    public class BasketTests
    {
        [Test]
        public void Add_Product_To_Basket_Stores_Product()
        {
            var basket = new Basket();
            var product = Product.ProductType.Bread;

            basket.AddToBasket(product);

            var qty = basket.GetProductQuantity(Product.ProductType.Bread);
            qty.Should().Be(1);
        }

        [Test]
        public void Cannot_Add_Product_Quantity_Less_Than_1()
        {
            var basket = new Basket();

            basket.AddToBasket(Product.ProductType.Bread, 0);
            basket.AddToBasket(Product.ProductType.Bread, -6);

            var qty = basket.GetProductQuantity(Product.ProductType.Bread);
            qty.Should().Be(0);
        }

        [Test]
        public void Add_Same_Product_Multiple_Times_Increases_Product_Quantity()
        {
            var basket = new Basket();
            var product = Product.ProductType.Butter;

            basket.AddToBasket(product, 3);
            basket.AddToBasket(product);
            basket.AddToBasket(product, 6);

            var qty = basket.GetProductQuantity(product);
            qty.Should().Be(10);
        }

        [Test]
        public void Add_Multiple_Products_Multiple_Times_Stores_All_Products()
        {
            var basket = new Basket();
            var butter = Product.ProductType.Butter;
            var milk = Product.ProductType.Milk;
            var bread = Product.ProductType.Bread;

            basket.AddToBasket(butter, 4);
            basket.AddToBasket(milk);
            basket.AddToBasket(butter);
            basket.AddToBasket(bread, 5);
            basket.AddToBasket(milk, 3);
            basket.AddToBasket(bread, 7);

            var butterQty = basket.GetProductQuantity(butter);
            var milkQty = basket.GetProductQuantity(milk);
            var breadQty = basket.GetProductQuantity(bread);
            butterQty.Should().Be(5);
            milkQty.Should().Be(4);
            breadQty.Should().Be(12);
        }
    }
}
