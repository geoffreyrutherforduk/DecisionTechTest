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
    public class FreeMilkDiscountTests
    {
        private Product _testMilk;
        private FreeMilkDiscount _freeMilkDiscount;


        [SetUp]
        public void Setup()
        {
            _freeMilkDiscount = new FreeMilkDiscount();
            _testMilk = new Product
            {
                Id = 2,
                Name = "Milk",
                DiscountTag = DiscountTag.Milk,
                Price = 1.15m
            };
        }

        [Test]
        public void Null_Basket_Returns_0()
        {
            var discount = _freeMilkDiscount.ApplyDiscount(null);
            discount.Should().Be(0);
        }

        [Test]
        public void Empty_Basket_Returns_0()
        {
            var discount = _freeMilkDiscount.ApplyDiscount(new Basket());
            discount.Should().Be(0);
        }

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void Basket_With_0_To_3_Milk_Returns_0_Discount(int milkCount)
        {
            var basket = new Basket();
            basket.AddToBasket(_testMilk, milkCount);

            var discount = _freeMilkDiscount.ApplyDiscount(basket);

            discount.Should().Be(0);
        }

        [Test]
        public void Basket_With_4_Milk_Returns_Discount_Of_Price_Of_Milk()
        {
            var basket = new Basket();
            basket.AddToBasket(_testMilk, 4);

            var discount = _freeMilkDiscount.ApplyDiscount(basket);

            discount.Should().Be(_testMilk.Price);
        }

        [Test]
        public void Basket_With_8_Milk_Returns_Discount_Of_2_Times_Price_Of_Milk()
        {
            var basket = new Basket();
            basket.AddToBasket(_testMilk, 8);

            var discount = _freeMilkDiscount.ApplyDiscount(basket);

            var expectedDiscount = _testMilk.Price * 2.0m;
            discount.Should().Be(expectedDiscount);
        }
    }
}
