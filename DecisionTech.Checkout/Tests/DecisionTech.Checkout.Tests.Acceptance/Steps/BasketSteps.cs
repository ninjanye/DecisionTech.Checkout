using System;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace DecisionTech.Checkout.Tests.Acceptance.Steps
{
    [Binding]
    public sealed class BasketSteps
    {
        [Given(@"I have the following prices")]
        public void GivenTheFollowingPrices(Table pricesTable)
        {
            var prices = new PriceList();
            foreach (var row in pricesTable.Rows)
            {
                int price = Convert.ToInt32(row["Price"]);
                prices.Add(row["Name"], price);
            }

            ScenarioContext.Current["prices"] = prices;
        }

        [Given(@"I have the following discounts")]
        public void GivenTheFollowingDiscounts(Table discountsTable)
        {
            var discounts = new Discounts();
            foreach (var row in discountsTable.Rows)
            {
                var product = row["Product"];
                int volume = Convert.ToInt32(row["Volume"]);
                int deduction = Convert.ToInt32(row["Discount"]);
                string productToDiscount = row["ProductToDiscount"];
                var discount = string.IsNullOrEmpty(productToDiscount) ? 
                    Discount.ProductDiscount(product, volume, deduction) : 
                    Discount.CrossProductDiscount(product, volume, productToDiscount, deduction);
                discounts.Add(discount);

            }
            ScenarioContext.Current["discounts"] = discounts;
        }

        [Given(@"(?:[The basket has ]*)(\d+) (Bread|Butter|Milk)")]
        public void GivenTheBasketHas(int itemCount, string product)
        {
            CreateBasket(); 
            var basket = ScenarioContext.Current.Get<Basket>("basket");
            for (int i = 0; i < itemCount; i++)
            {
                basket.Add(product);
            }
        }

        private static void CreateBasket()
        {
            if (!ScenarioContext.Current.ContainsKey("basket"))
            {
                var prices = ScenarioContext.Current.Get<PriceList>("prices");
                var discounts = ScenarioContext.Current.Get<Discounts>("discounts");
                ScenarioContext.Current["basket"] = new Basket(prices, discounts);
            }
        }

        [When(@"I total the basket")]
        public void WhenITotalTheBasket()
        {
            var basket = ScenarioContext.Current.Get<Basket>("basket");
            var totalCost = basket.Total();
            ScenarioContext.Current["total_cost"] = totalCost;
        }

        [Then(@"the total should be £(.*)")]
        public void ThenTheTotalShouldBe(Decimal expectedTotal)
        {
            var total = ScenarioContext.Current.Get<int>("total_cost");
            Assert.That(total, Is.EqualTo(expectedTotal * 100));
        }
    }
}
