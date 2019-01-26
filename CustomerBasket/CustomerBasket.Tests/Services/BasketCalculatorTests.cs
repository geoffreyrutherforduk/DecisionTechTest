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
    public class BasketCalculatorTests
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
        public void Null_Basket_Returns_0()
        {
            var basketCalculator = new BasketCalculator();

            var cost = basketCalculator.GetCostOfBasket(null);

            cost.Should().Be(0);
        }

        [Test]
        public void Empty_Basket_Returns_0()
        {
            var basket = new Basket();
            var basketCalculator = new BasketCalculator();

            var cost = basketCalculator.GetCostOfBasket(basket);

            cost.Should().Be(0);
        }
        
        [Test]
        public void Basket_With_Single_Product_Returns_Product_Price()
        {
            var basket = new Basket();
            basket.AddToBasket(_testButter);

            var basketCalculator = new BasketCalculator();

            var cost = basketCalculator.GetCostOfBasket(basket);

            cost.Should().Be(0.80m);
        }

        [Test]
        public void Basket_With_Same_Product_Multiple_Times_Returns_Product_Price_Times_Quantity()
        {
            var basket = new Basket();
            basket.AddToBasket(_testBread, 4);
            basket.AddToBasket(_testBread);
            basket.AddToBasket(_testBread, 1);

            var basketCalculator = new BasketCalculator();

            var cost = basketCalculator.GetCostOfBasket(basket);

            cost.Should().Be(6.0m);
        }

        [Test]
        public void Basket_With_Multiple_Products_Multiple_Times_Returns_Correct_Cost_Sum()
        {
            var basket = new Basket();
            basket.AddToBasket(_testBread, 4);
            basket.AddToBasket(_testMilk);
            basket.AddToBasket(_testBread, 1);
            basket.AddToBasket(_testButter, 2);
            basket.AddToBasket(_testMilk, 3);

            var basketCalculator = new BasketCalculator();

            var cost = basketCalculator.GetCostOfBasket(basket);
            cost.Should().Be(11.20m);
        }

        [Test]
        public void Basket_With_1_Bread_1_Milk_1_Butter_Returns_2_95()
        {
            var basket = new Basket();
            basket.AddToBasket(_testBread);
            basket.AddToBasket(_testMilk);
            basket.AddToBasket(_testButter);

            var basketCalculator = new BasketCalculator();

            var cost = basketCalculator.GetCostOfBasket(basket);
            cost.Should().Be(2.95m);
        }
    }
}
