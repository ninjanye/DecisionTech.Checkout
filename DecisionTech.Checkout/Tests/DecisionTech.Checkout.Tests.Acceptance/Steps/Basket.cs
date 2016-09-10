using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace DecisionTech.Checkout.Tests.Acceptance.Steps
{
    [Binding]
    public sealed class Basket
    {
        [Given(@"The basket has (.*) bread, (.*) butter, and (.*) milk")]
        public void GivenTheBasketHasBreadButterAndMilk(int p0, int p1, int p2)
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I total the basket")]
        public void WhenITotalTheBasket()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"the total should be £(.*)")]
        public void ThenTheTotalShouldBe(Decimal p0)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
