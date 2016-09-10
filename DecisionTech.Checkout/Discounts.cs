using System.Collections;
using System.Collections.Generic;

namespace DecisionTech.Checkout
{
    public class Discounts : IEnumerable<Discount>
    {
        private readonly ICollection<Discount> _discounts;

        public Discounts()
        {
            _discounts = new List<Discount>();
        }

        public void Add(Discount discount)
        {
            _discounts.Add(discount);
        }

        public IEnumerator<Discount> GetEnumerator()
        {
            return _discounts.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}