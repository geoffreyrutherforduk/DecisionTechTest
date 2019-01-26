using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerBasket.Tests
{
    [TestFixture]
    public class FreeMilkDiscountTests
    {
        private FreeMilkDiscount _freeMilkDiscount;

        [SetUp]
        public void Setup()
        {
            _freeMilkDiscount = new FreeMilkDiscount();
        }

        [Test]
        public void Empty_Basket_Returns_0_Discount()
        {
            var basket = new Basket();

            var discount = _freeMilkDiscount.ApplyDiscount(basket);

            discount.Should().Be(0);
        }

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void Basket_With_0_To_3_Milk_Returns_0_Discount(int milkCount)
        {
            var basket = new Basket();
            basket.AddToBasket(Product.ProductType.Milk, milkCount);

            var discount = _freeMilkDiscount.ApplyDiscount(basket);

            discount.Should().Be(0);
        }

        [Test]
        public void Basket_With_4_Milk_Returns_Discount_Of_Price_Of_Milk()
        {
            var basket = new Basket();
            basket.AddToBasket(Product.ProductType.Milk, 4);

            var discount = _freeMilkDiscount.ApplyDiscount(basket);

            discount.Should().Be(1.15m);
        }

        [Test]
        public void Basket_With_8_Milk_Returns_Discount_Of_2_Times_Price_Of_Milk()
        {
            var basket = new Basket();
            basket.AddToBasket(Product.ProductType.Milk, 8);

            var discount = _freeMilkDiscount.ApplyDiscount(basket);

            discount.Should().Be(2.30m);
        }
    }
}
