// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
//Bir nesne gelişime AÇIK değişime KAPALI olmalıdır.
Customer customer = new Customer { Name = "Tuğberk", Cart = new PremiumCart() };
OrderManager orderManager = new OrderManager { Customer = customer };
Console.WriteLine(orderManager.GetDiscountedPrice(100));


public abstract class Cart
{
    public abstract decimal GetDiscounted(decimal totalPrice);

}

public class StandardCart : Cart
{
    public override decimal GetDiscounted(decimal totalPrice)
    {
        return totalPrice * .95m;
    }
}

public class SilverCart : Cart
{
    public override decimal GetDiscounted(decimal totalPrice)
    {
        return totalPrice * .90m;
    }
}

public class GoldCart : Cart
{
    public override decimal GetDiscounted(decimal totalPrice)
    {
        return totalPrice * .85m;
    }
}

public class PremiumCart : Cart
{
    public override decimal GetDiscounted(decimal totalPrice)
    {
        return totalPrice * .75m;
    }
}


public class Customer
{
    public string Name { get; set; }
    public Cart Cart { get; set; }
}

public class OrderManager
{

    public Customer Customer { get; set; }
    public decimal GetDiscountedPrice(decimal totalPrice)
    {
        return Customer.Cart.GetDiscounted(totalPrice);
        //switch (Customer.Cart)
        //{
        //    case Cart.Standard:
        //        return totalPrice * 0.95M;
        //    case Cart.Silver:
        //        return totalPrice * 0.90M;
        //    case Cart.Gold:
        //        return totalPrice * 0.85M;
        //    case Cart.Premium:
        //        return totalPrice * 0.75M;
        //    default:
        //        return totalPrice;
        //}
    }
}