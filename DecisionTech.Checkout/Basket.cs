using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace DecisionTech.Checkout
{
    public class Basket
    {
        private readonly List<string> _products;
        private readonly Dictionary<string, int> _prices;
        private readonly List<Discount> _discounts;

        public static Basket New(Dictionary<string, int> prices)
        {
            return new Basket(prices, new List<Discount>(), new List<string>());
        }
        public static Basket New(Dictionary<string, int> prices, List<Discount> discounts)
        {
            return new Basket(prices, discounts, new List<string>());
        }

        private Basket(Dictionary<string, int> prices, List<Discount> discounts, List<string> products = null)
        {
            _prices = prices;
            _products = products ?? new List<string>();
            _discounts = discounts;
        }

        public int Total()
        {
            var total = _products.Sum(p => _prices[p]);
            return total - Discount();
        }

        private int Discount()
        {
            return _discounts.Sum(d => d.CalculateFor(_products));
        }

        public Basket Add(string product)
        {
            _products.Add(product);
            return new Basket(_prices, _discounts, _products);
        }
    }

    public class Discount
    {
        readonly string _product;
        readonly int _volume;
        readonly int _deduction;

        public Discount(string product, int volume, int deduction)
        {
            _product = product;
            _volume = volume;
            _deduction = deduction;
        }

        public int CalculateFor(List<string> products)
        {
            return products.Count(p => p == _product) == _volume ? _deduction : 0;
        }
    }
}