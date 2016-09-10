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

            var discount = Discount.CrossProductDiscount("B", 2, "A", 5);
            var discounts = new Discounts {discount};

            _basket = new Basket(_prices, discounts);
            var total = _basket.Add("B").Add("B").Total();

            Assert.That(total, Is.EqualTo(40));
        }

        [Test]
        public void AppliesDiscountAcrossIfDiscountedProductIsPresent()
        {
            _prices = new PriceList();
            _prices.Add("A", 10);
            _prices.Add("B", 20);

            var discount = Discount.CrossProductDiscount("B", 2, "A", 5);
            var discounts = new Discounts {discount};

            _basket = new Basket(_prices, discounts);
            var total = _basket.Add("B").Add("B").Add("A").Total();

            Assert.That(total, Is.EqualTo(45));
        }
    }
}