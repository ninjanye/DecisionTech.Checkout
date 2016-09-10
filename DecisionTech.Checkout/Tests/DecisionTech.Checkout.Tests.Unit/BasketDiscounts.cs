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

        [Test]
        public void BasketAppliesDiscount()
        {
            _basket.Add("A").Add("A").Add("A");
            int total = _basket.Total();
            Assert.That(total, Is.EqualTo(25));
        }
    }
}