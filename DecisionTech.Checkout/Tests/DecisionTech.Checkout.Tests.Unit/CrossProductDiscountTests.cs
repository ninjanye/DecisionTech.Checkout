using System.Collections.Generic;
using NUnit.Framework;

namespace DecisionTech.Checkout.Tests.Unit
{
    [TestFixture]
    public class CrossProductDiscountTests
    {
        private Basket _basket;
        private PriceList _prices;

        [Test]
        public void DoesNotApplyDiscountAcrossIfDiscountedProductIsNotPresent()
        {
            _prices = new PriceList();
            _prices.Add("A", 10);
            _prices.Add("B", 20);

            var discount = new Discount("B", 2, "A", 5);
            var discounts = new List<Discount> {discount};

            _basket = new Basket(_prices, discounts);
            var total = _basket.Add("B").Add("B").Add("A").Total();

            Assert.That(total, Is.EqualTo(50));
        }
    }
}