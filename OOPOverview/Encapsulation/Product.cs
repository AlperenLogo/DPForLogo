namespace Encapsulation
{
    public class Product
    {
        private decimal price;
        public void SetPrice(decimal value)
        {
            if (value < 0)
            {
                throw new ArgumentException("Fiyat değeri negatif olamaz");
            }
            price = value;

        }

        public decimal GetPrice()
        {
            return price;
        }

        public string Name { get; set; }

        public double Rating { get; private set; }

    }
}
