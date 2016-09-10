using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace DecisionTech.Checkout.Tests.Acceptance.Steps
{
    [Binding]
    public sealed class BasketSteps
    {
        [Given(@"I have a basket with the following prices")]
        public void GivenTheFollowingPrices(Table pricesTable)
        {
            var prices = new Dictionary<string, int>();
            foreach (var row in pricesTable.Rows)
            {
                int price = Convert.ToInt32(row["Price"]);
                prices.Add(row["Name"], price);
            }

            ScenarioContext.Current["basket"] = Basket.New(prices);
        }

        [Given(@"The basket has (.*) bread, (.*) butter, and (.*) milk")]
        public void GivenTheBasketHasBreadButterAndMilk(int p0, int p1, int p2)
        {
            var basket = ScenarioContext.Current.Get<Basket>("basket");
            basket.Add("Bread").Add("Butter").Add("Milk");
        }

        [When(@"I total the basket")]
        public void WhenITotalTheBasket()
        {
            var basket = ScenarioContext.Current.Get<Basket>("basket");
            var totalCost = basket.Total();
            ScenarioContext.Current["total_cost"] = totalCost;
        }

        [Then(@"the total should be £(.*)")]
        public void ThenTheTotalShouldBe(Decimal p0)
        {
            var total = ScenarioContext.Current.Get<int>("total_cost");
            Assert.That(total, Is.EqualTo(p0 * 100));
        }
    }
}
