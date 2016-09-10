using System.Collections.Generic;
using System.Linq;

namespace DecisionTech.Checkout
{
    public class Basket
    {
        private readonly ICollection<string> _products;
        private readonly PriceList _prices;
        private readonly IEnumerable<Discount> _discounts;

        public Basket(PriceList prices, IEnumerable<Discount> discounts = null, ICollection<string> products = null)
        {
            _prices = prices;
            _discounts = discounts ?? new List<Discount>();
            _products = products ?? new List<string>();
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
            return this;
        }
    }
}