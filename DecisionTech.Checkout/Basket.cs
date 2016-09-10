using System.Collections.Generic;
using System.Linq;

namespace DecisionTech.Checkout
{
    public class Basket
    {
        private readonly List<string> _products = new List<string>();
        private readonly Dictionary<string, int> _prices;

        public Basket(Dictionary<string, int> prices = null)
        {
            _prices = prices ?? new Dictionary<string, int>();
        }

        public int Total()
        {
            return _products.Sum(p => _prices[p]);
        }

        public Basket Add(string product)
        {
            _products.Add(product);
            return this;
        }
    }
}