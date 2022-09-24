// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
/*
 * Problem:
 * 
 * Birden fazla nesnenin kullanıldığı karmaşık işleri, istemci sınıfına göre basitleştirmek istiyoruz. Bunu nasıl yaparız? 
 *
 * Senaryo:
 * Bir sipariş işlemi için 
 *   1. Sipariş Tablosuna kayıt
 *   2. Satın alınan her ürün orderline...
 *   3. Satın alınan adet kadar stoktan düşülecek...
 *   
 *   
 */

Customer customer = new Customer() { Name = "Tuğberk" };
var products = new List<Product>
{
    new Product{ Name="XXX", Quantity=3},
    new Product{ Name="YYY", Quantity=1},
    new Product{ Name="ZZZ", Quantity=2},


};
OrderFacade orderFacade = new OrderFacade();
orderFacade.CreateOrder(customer, products);


public class OrderFacade
{
    private OrderService orderService = new OrderService();
    private OrderLineService orderLineService = new OrderLineService();
    private ProductService productService = new ProductService();

    public void CreateOrder(Customer customer, List<Product> products)
    {
        int orderId = orderService.AddOrder(customer);
        orderLineService.AddOrderDetail(orderId, products);
        productService.UpdateStock(products);

    }
}

public class Product
{
    public string Name { get; set; }
    public int Quantity { get; set; }

}
public class Customer
{
    public string Name { get; set; }
}

public class OrderService
{
    public int AddOrder(Customer customer)
    {
        var dateTime = DateTime.Now;
        Console.WriteLine($"{dateTime} tarihinde {customer.Name} sipariş verdi");

        return 1;
    }
}

public class OrderLineService
{
    public void AddOrderDetail(int orderId, List<Product> products)
    {
        Console.WriteLine($"{orderId} numaralı siparişte;");
        products.ForEach(x => Console.WriteLine($"{x.Name} ürününden alındı"));


    }
}

public class ProductService
{
    public void UpdateStock(List<Product> products)
    {
        products.ForEach(x => Console.WriteLine($"{x.Name} ürününden {x.Quantity} adet düşüldü"));
    }
}

