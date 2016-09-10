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
            _basket = Basket.New(_prices);
        }

        [TestCase("A", 3, 25)]
        [TestCase("B", 4, 60)]
        public void BasketAppliesDiscount(string product, int volume, int expected)
        {
            for (int i = 0; i < volume; i++)
            {
                _basket.Add(product);
            }
            int total = _basket.Total();
            Assert.That(total, Is.EqualTo(expected));
        }
    }
}