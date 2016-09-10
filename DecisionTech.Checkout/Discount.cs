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

        public static Discount ProductDiscount(string product, int volume, int deduction)
        {
            return new Discount(product, volume, product, deduction);
        }

        public static Discount CrossProductDiscount(string product, int volume, string productToDiscount, int deduction)
        {
            return new Discount(product, volume, productToDiscount, deduction);
        }

        private Discount(string product, int volume, string productToDiscount, int deduction)
        {
            _product = product;
            _volume = volume;
            _productToDiscount = productToDiscount;
            _deduction = deduction;
        }

        public int CalculateFor(ICollection<string> products)
        {
            if (!products.Contains(_productToDiscount))
            {
                return 0;
            }

            int total = 0;
            int productCount = products.Count(p => p == _product);
            while (productCount >= _volume)
            {
                total += _deduction;
                productCount -= _volume;
            }
            return total;
        }
    }
}