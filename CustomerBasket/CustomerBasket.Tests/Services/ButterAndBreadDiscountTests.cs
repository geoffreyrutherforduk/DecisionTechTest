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
    public class ButterAndBreadDiscountTests
    {
        private Product _testButter;
        private Product _testBread;
        private ButterAndBreadDiscount _butterAndBreadDiscount;


        [SetUp]
        public void Setup()
        {
            _butterAndBreadDiscount = new ButterAndBreadDiscount();
            _testButter = new Product
            {
                Id = 1,
                Name = "Butter",
                DiscountTag = DiscountTag.Butter,
                Price = 0.80m
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
            var discount = _butterAndBreadDiscount.ApplyDiscount(null);
            discount.Should().Be(0);
        }

        [Test]
        public void Empty_Basket_Returns_0()
        {
            var discount = _butterAndBreadDiscount.ApplyDiscount(new Basket());
            discount.Should().Be(0);
        }

        [Test]
        public void Basket_With_1_Butter_And_1_Bread_Returns_0_Discount()
        {
            var basket = new Basket();
            basket.AddToBasket(_testBread);
            basket.AddToBasket(_testButter);

            var discount = _butterAndBreadDiscount.ApplyDiscount(basket);

            discount.Should().Be(0);
        }

        [Test]
        public void Basket_With_2_Butter_And_No_Bread_Returns_0_Discount()
        {
            var basket = new Basket();
            basket.AddToBasket(_testButter, 2);

            var discount = _butterAndBreadDiscount.ApplyDiscount(basket);

            discount.Should().Be(0);
        }

        [Test]
        public void Basket_With_2_Butter_And_1_Bread_Returns_0_50_Discount()
        {
            var basket = new Basket();
            basket.AddToBasket(_testButter, 2);
            basket.AddToBasket(_testBread);

            var discount = _butterAndBreadDiscount.ApplyDiscount(basket);

            discount.Should().Be(0.50m);
        }

        [Test]
        public void Basket_With_5_Butter_And_1_Bread_Returns_0_50_Discount()
        {
            var basket = new Basket();
            basket.AddToBasket(_testButter, 5);
            basket.AddToBasket(_testBread);

            var discount = _butterAndBreadDiscount.ApplyDiscount(basket);

            discount.Should().Be(0.50m);
        }

        [Test]
        public void Basket_With_3_Butter_And_6_Bread_Returns_0_50_Discount()
        {
            var basket = new Basket();
            basket.AddToBasket(_testButter, 3);
            basket.AddToBasket(_testBread, 6);

            var discount = _butterAndBreadDiscount.ApplyDiscount(basket);

            discount.Should().Be(0.50m);
        }

        [Test]
        public void Basket_With_7_Butter_And_5_Bread_Returns_1_50_Discount()
        {
            var basket = new Basket();
            basket.AddToBasket(_testButter, 7);
            basket.AddToBasket(_testBread, 5);

            var discount = _butterAndBreadDiscount.ApplyDiscount(basket);

            discount.Should().Be(1.50m);
        }
    }
}
