using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace DecisionTech.Checkout.Tests.Unit
{
    [TestFixture]
    public class BasketTotals
    {
        private Basket _basket;
        private PriceList _priceList;

        [SetUp]
        public void SetUp()
        {
            _priceList = new PriceList();
            _priceList.Add("A", 10);
            _priceList.Add("B", 20);
            _basket = new Basket(_priceList);
        }

        [Test]
        public void ReturnsZeroWhenWithoutProducts()
        {
            int total = _basket.Total();
            Assert.That(total, Is.EqualTo(0));
        }

        [TestCase("A", 10)]
        [TestCase("B", 20)]
        public void ReturnsThePriceOfASingleProduct(string product, int expected)
        {
            _basket.Add(product);
            int total = _basket.Total();
            Assert.That(total, Is.EqualTo(expected));
        }

        [Test]
        public void ReturnsTheCombinedPriceOfMultipleProducts()
        {
            _basket.Add("A").Add("B");
            int total = _basket.Total();
            Assert.That(total, Is.EqualTo(30));
        }
    }
}
