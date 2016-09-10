using System;
using System.Collections.Generic;
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
            var prices = new Dictionary<string, int>();
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
            var discounts = new List<Discount>();
            foreach (var row in discountsTable.Rows)
            {
                var volume = Convert.ToInt32(row["Volume"]);
                var deduction = Convert.ToInt32(row["Discount"]);
                discounts.Add(new Discount(row["Product"], volume, deduction));
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
                var prices = ScenarioContext.Current.Get<Dictionary<string, int>>("prices");
                var discounts = ScenarioContext.Current.Get<List<Discount>>("discounts");
                ScenarioContext.Current["basket"] = Basket.New(prices, discounts);
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
