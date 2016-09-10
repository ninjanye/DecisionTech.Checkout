using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace DecisionTech.Checkout
{
    public class Basket
    {
        private readonly List<string> _products;
        private readonly Dictionary<string, int> _prices;

        public static Basket New(Dictionary<string, int> prices)
        {
            return new Basket(prices, new List<string>());
        }

        private Basket(Dictionary<string, int> prices, List<string> products = null)
        {
            _prices = prices;
            _products = products ?? new List<string>();
        }

        public int Total()
        {
            var total = _products.Sum(p => _prices[p]);
            return total - Discount();
        }

        private int Discount()
        {
            int discount = 0;
            if (_products.Count(p => p == "A") == 3)
            {
                discount = 5;
            }
            return discount;
        }

        public Basket Add(string product)
        {
            _products.Add(product);
            return new Basket(_prices, _products);
        }
    }
}