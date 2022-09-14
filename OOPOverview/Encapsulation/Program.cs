namespace Encapsulation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Product product = new Product();
            product.SetPrice(150);

            var price = product.GetPrice();
            product.Name = "Şemsiye";

        }
    }
}