using CustomerBasket.Entities;
using CustomerBasket.Services;
using CustomerBasket.Types;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerBasket.Tests.Services
{
    [TestFixture]
    public class BasketTests
    {
        private Product _testButter;
        private Product _testMilk;
        private Product _testBread;

        [SetUp]
        public void Setup()
        {
            _testButter = new Product
            {
                Id = 1,
                Name = "Butter",
                DiscountTag = DiscountTag.Butter,
                Price = 0.80m
            };
            _testMilk = new Product
            {
                Id = 2,
                Name = "Milk",
                DiscountTag = DiscountTag.Milk,
                Price = 1.15m
            };
            _testBread = new Product
            {
                Id = 3,
                Name = "Bread",
                DiscountTag = DiscountTag.Bread,
                Price = 1.00m
            };
        }

        [Test]
        public void Add_Product_To_Basket_Stores_Product()
        {
            var basket = new Basket();
            basket.AddToBasket(_testBread);

            var qty = basket.GetProductQtyById(_testBread.Id);
            qty.Should().Be(1);
        }

        [Test]
        public void Cannot_Add_Product_Quantity_Less_Than_1()
        {
            var basket = new Basket();

            basket.AddToBasket(_testBread, 0);
            basket.AddToBasket(_testBread, -6);

            var qty = basket.GetProductQtyById(_testBread.Id);
            qty.Should().Be(0);
        }

        [Test]
        public void Add_Same_Product_Multiple_Times_Increases_Product_Quantity()
        {
            var basket = new Basket();

            basket.AddToBasket(_testButter, 3);
            basket.AddToBasket(_testButter);
            basket.AddToBasket(_testButter, 6);

            var qty = basket.GetProductQtyById(_testButter.Id);
            qty.Should().Be(10);
        }

        [Test]
        public void Add_Multiple_Products_Multiple_Times_Stores_All_Products()
        {
            var basket = new Basket();

            basket.AddToBasket(_testButter, 4);
            basket.AddToBasket(_testMilk);
            basket.AddToBasket(_testButter);
            basket.AddToBasket(_testBread, 5);
            basket.AddToBasket(_testMilk, 3);
            basket.AddToBasket(_testBread, 7);

            var butterQty = basket.GetProductQtyById(_testButter.Id);
            var milkQty = basket.GetProductQtyById(_testMilk.Id);
            var breadQty = basket.GetProductQtyById(_testBread.Id);
            butterQty.Should().Be(5);
            milkQty.Should().Be(4);
            breadQty.Should().Be(12);
        }
    }
}
