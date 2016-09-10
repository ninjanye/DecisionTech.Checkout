namespace DecisionTech.Checkout
{
    public class Basket
    {
        private string _product;

        public int Total()
        {
            return _product == "A" ? 10 : 0;
        }

        public void Add(string product)
        {
            _product = product;
        }
    }
}