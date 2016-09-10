using System.Collections.Generic;

namespace DecisionTech.Checkout
{
    public class PriceList
    {
        private readonly Dictionary<string, int> _prices = new Dictionary<string, int>();

        public void Add(string product, int price)
        {
            _prices.Add(product, price);
        }

        public int this[string name]
        {
            get { return _prices[name]; }
            set { _prices[name] = value; }
        }
    }
}