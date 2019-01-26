using CustomerBasket.Entities;
using CustomerBasket.Services;
using CustomerBasket.Types;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerBasket.Tests
{
    [TestFixture]
    public class IntegrationTests
    {
        private Product _testButter;
        private Product _testMilk;
        private Product _testBread;
        private BasketCalculator _basketCalculator;

        [SetUp]
        public void Setup()
        {
            var freeMilkDiscount = new FreeMilkDiscount();
            var butterAndBreadDiscount = new ButterAndBreadDiscount();

            _basketCalculator = new BasketCalculator(freeMilkDiscount, butterAndBreadDiscount);

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
        public void Basket_With_1_Bread_1_Butter_1_Milk_Returns_Cost_Of_2_95()
        {
            var basket = new Basket();
            basket.AddToBasket(_testBread);
            basket.AddToBasket(_testButter);
            basket.AddToBasket(_testMilk);

            var cost = _basketCalculator.GetCostOfBasket(basket);

            cost.Should().Be(2.95m);
        }

        [Test]
        public void Basket_With_2_Butter_And_2_Bread_Returns_Cost_Of_3_10()
        {
            var basket = new Basket();
            basket.AddToBasket(_testBread, 2);
            basket.AddToBasket(_testButter, 2);

            var cost = _basketCalculator.GetCostOfBasket(basket);

            cost.Should().Be(3.10m);
        }

        [Test]
        public void Basket_With_4_Milk_Returns_Cost_Of_3_45()
        {
            var basket = new Basket();
            basket.AddToBasket(_testMilk, 4);

            var cost = _basketCalculator.GetCostOfBasket(basket);

            cost.Should().Be(3.45m);
        }

        [Test]
        public void Basket_With_2_Butter_And_1_Bread_8_Milk_Returns_Cost_Of_9_00()
        {
            var basket = new Basket();
            basket.AddToBasket(_testButter, 2);
            basket.AddToBasket(_testBread);
            basket.AddToBasket(_testMilk, 8);

            var cost = _basketCalculator.GetCostOfBasket(basket);

            cost.Should().Be(9.00m);
        }
    }
}
