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

        [Test]
        public void ReturnsThePriceOfAProduct()
        {
            var basket = new Basket();
            basket.Add("A");
            int total = basket.Total();
            Assert.That(total, Is.EqualTo(10));
        }
    }
}
