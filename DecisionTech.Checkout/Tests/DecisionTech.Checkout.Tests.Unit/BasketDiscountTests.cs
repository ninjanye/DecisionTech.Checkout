using System.Collections.Generic;
using NUnit.Framework;

namespace DecisionTech.Checkout.Tests.Unit
{
    [TestFixture]
    public class BasketDiscountTests
    {
        private Basket _basket;
        private PriceList _prices;

        [SetUp]
        public void SetUp()
        {
            _prices = new PriceList();
            _prices.Add("A", 10);
            _prices.Add("B", 20);

            var discountA = Discount.ProductDiscount("A", 3, 5);
            var discountB = Discount.ProductDiscount("B", 2, 20);
            var discounts = new List<Discount> { discountA, discountB };

            _basket = new Basket(_prices, discounts);
        }

        [TestCase("A", 3, 25)]
        [TestCase("B", 2, 20)]
        public void BasketAppliesDiscount(string product, int volume, int expectedTotal)
        {
            for (int i = 0; i < volume; i++)
            {
                _basket.Add(product);
            }
            int total = _basket.Total();
            Assert.That(total, Is.EqualTo(expectedTotal));
        }

        [Test]
        public void BasketAppliesMultipleDiscounts()
        {
            _basket.Add("A").Add("A").Add("A").Add("B").Add("B");
            int total = _basket.Total();
            Assert.That(total, Is.EqualTo(45));
        }

        [Test]
        public void BasketAppliesDiscountsMultipleTimes()
        {
            _basket.Add("A").Add("A").Add("A").Add("A").Add("A").Add("A");
            int total = _basket.Total();
            Assert.That(total, Is.EqualTo(50));
        }

    }
}