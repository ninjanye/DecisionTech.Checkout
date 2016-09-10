using System.Collections.Generic;
using System.Linq;

namespace DecisionTech.Checkout
{
    public class Discount
    {
        readonly string _product;
        readonly int _volume;
        private readonly string _productToDiscount;
        readonly int _deduction;

        public Discount(string product, int volume, int deduction)
        {
            _product = product;
            _volume = volume;
            _deduction = deduction;
        }

        public Discount(string product, int volume, string productToDiscount, int deduction)
        {
            _product = product;
            _volume = volume;
            _productToDiscount = productToDiscount;
            _deduction = deduction;
        }

        public int CalculateFor(ICollection<string> products)
        {
            if (products.Contains(_productToDiscount))
            {
                return 0;
            }
            return products.Count(p => p == _product) == _volume ? _deduction : 0;
        }
    }
}