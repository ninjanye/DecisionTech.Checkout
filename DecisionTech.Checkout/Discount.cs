using System.Linq;

namespace DecisionTech.Checkout
{
    public class Discount
    {
        private readonly string _product;
        private readonly int _volume;
        private readonly string _productToDiscount;
        private readonly int _deduction;

        /// <summary>
        /// Product discounts are only applied if the product exists with the required volume
        /// </summary>
        public static Discount ProductDiscount(string product, int volume, int deduction)
        {
            return new Discount(product, volume, product, deduction);
        }

        /// <summary>
        /// Cross product discounts are only applied if the product and the product to discount exist
        /// in the supplied basket
        /// </summary>
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

        public int CalculateFor(Basket basket)
        {
            if (!basket.Contains(_productToDiscount))
            {
                return 0;
            }

            int total = 0;
            int productCount = basket.Count(p => p == _product);
            while (productCount >= _volume)
            {
                total += _deduction;
                productCount -= _volume;
            }
            return total;
        }
    }
}