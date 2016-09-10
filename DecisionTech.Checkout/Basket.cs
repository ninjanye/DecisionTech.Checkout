using System.Collections.Generic;

namespace DecisionTech.Checkout
{
    public class Basket
    {
        private string _product;
        private readonly Dictionary<string, int> _prices;

        public Basket(Dictionary<string, int> prices = null)
        {
            _prices = prices ?? new Dictionary<string, int>();
        }

        public int Total()
        {
            if (string.IsNullOrEmpty(_product))
            {
                return 0;
            }
            return _prices[_product];
        }

        public void Add(string product)
        {
            _product = product;
        }
    }
}