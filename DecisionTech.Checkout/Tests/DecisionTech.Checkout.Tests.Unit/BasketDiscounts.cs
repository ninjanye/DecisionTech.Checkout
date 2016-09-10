using System.Collections.Generic;
using NUnit.Framework;

namespace DecisionTech.Checkout.Tests.Unit
{
    [TestFixture]
    public class BasketDiscounts
    {
        private Basket _basket;
        private readonly Dictionary<string, int> _prices = new Dictionary<string, int>
        {
            {"A", 10},
            {"B", 20}
        };

        [SetUp]
        public void SetUp()
        {
            var discountA = new Discount("A", 3, 5);
            var discountB = new Discount("B", 2, 20);
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

    }
}