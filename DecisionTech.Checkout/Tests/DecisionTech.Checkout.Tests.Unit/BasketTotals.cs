using System;
using NUnit.Framework;

namespace DecisionTech.Checkout.Tests.Unit
{
    [TestFixture]
    public class BasketTotals
    {
        [Test]
        public void ReturnsZeroWhenWithoutProducts()
        {
            var basket = new Basket();
            int total = basket.Total();
            Assert.That(total, Is.EqualTo(0));
        }

        [TestCase("A", 10)]
        [TestCase("B", 20)]
        public void ReturnsThePriceOfASingleProduct(string product, int expected)
        {
            var basket = new Basket();
            basket.Add(product);
            int total = basket.Total();
            Assert.That(total, Is.EqualTo(expected));
        }
    }
}
