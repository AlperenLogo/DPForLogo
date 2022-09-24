// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

Products products = new Products();
products.Sort(new BubbleSortAlgorithm());
products.Sort(new HeapSortAlgorithm());



public class Product
{
}


public class Products
{
    public void Sort(ISortAlgorithm sortAlgorithm)
    {
        //Bubble sort....
        sortAlgorithm.Sort();
    }
}

public interface ISortAlgorithm
{
    void Sort();
}

public class BubbleSortAlgorithm : ISortAlgorithm
{
    public void Sort()
    {
        Console.WriteLine("Ürünler bubble algoritmasını kullanarak sıralandı");
    }
}

public class HeapSortAlgorithm : ISortAlgorithm
{
    public void Sort()
    {
        Console.WriteLine("Ürünler heap algoritmasını kullanarak sıralandı");
    }
}