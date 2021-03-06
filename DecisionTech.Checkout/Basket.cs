using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DecisionTech.Checkout
{
    public class Basket : IEnumerable<string>
    {
        private readonly ICollection<string> _products;
        private readonly PriceList _prices;
        private readonly Discounts _discounts;

        public Basket(PriceList prices, Discounts discounts = null, ICollection<string> products = null)
        {
            _prices = prices;
            _discounts = discounts ?? new Discounts();
            _products = products ?? new List<string>();
        }

        public int Total()
        {
            var total = _products.Sum(p => _prices[p]);
            return total - Discount();
        }

        private int Discount()
        {
            return _discounts.Sum(d => d.CalculateFor(this));
        }

        public Basket Add(string product)
        {
            _products.Add(product);
            return this;
        }

        public IEnumerator<string> GetEnumerator()
        {
            return _products.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}