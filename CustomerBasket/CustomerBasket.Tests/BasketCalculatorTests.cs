using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerBasket.Tests
{
    [TestFixture]
    public class BasketCalculatorTests
    {
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
            basket.AddToBasket(Product.ProductType.Butter);

            var basketCalculator = new BasketCalculator();

            var cost = basketCalculator.GetCostOfBasket(basket);

            cost.Should().Be(0.8m);
        }

        [Test]
        public void Basket_With_Same_Product_Multiple_Times_Returns_Product_Price_Times_Quantity()
        {
            var basket = new Basket();
            basket.AddToBasket(Product.ProductType.Bread, 4);
            basket.AddToBasket(Product.ProductType.Bread);
            basket.AddToBasket(Product.ProductType.Bread, 1);

            var basketCalculator = new BasketCalculator();

            var cost = basketCalculator.GetCostOfBasket(basket);

            cost.Should().Be(6.0m);
        }

        [Test]
        public void Basket_With_Multiple_Products_Multiple_Times_Returns_Correct_Cost_Sum()
        {
            var basket = new Basket();
            basket.AddToBasket(Product.ProductType.Bread, 4);
            basket.AddToBasket(Product.ProductType.Milk);
            basket.AddToBasket(Product.ProductType.Bread, 1);
            basket.AddToBasket(Product.ProductType.Butter, 2);
            basket.AddToBasket(Product.ProductType.Milk, 3);

            var basketCalculator = new BasketCalculator();

            var cost = basketCalculator.GetCostOfBasket(basket);
            cost.Should().Be(11.20m);
        }

        [Test]
        public void Basket_With_1_Bread_1_Milk_1_Butter_Returns_2_95()
        {
            var basket = new Basket();
            basket.AddToBasket(Product.ProductType.Bread);
            basket.AddToBasket(Product.ProductType.Milk);
            basket.AddToBasket(Product.ProductType.Butter);

            var basketCalculator = new BasketCalculator();

            var cost = basketCalculator.GetCostOfBasket(basket);
            cost.Should().Be(2.95m);
        }
    }
}
