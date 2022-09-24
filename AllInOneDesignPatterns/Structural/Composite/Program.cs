// See https://aka.ms/new-console-template for more information
using System.Xml;

Console.WriteLine("Hello, World!");

XmlDocument xmlDocument = new XmlDocument();


/*
 * Problem:
 * 
 * Kendi içinde parent -> child ilişkisi olan nesnelerin yapısını nasıl oluşturursunuz.
 * 
 * Senaryo: Kategori -> Alt kategori -> Ürün iç içe geçen yapısını tanımlıyoruz
 */

CategoryComposite<Category> categoryComposite = new CategoryComposite<Category>() { Node = new Category("Elektronik") };
var bilgisayar = categoryComposite.Add(new Category("bilgisayar"));
var laptop = bilgisayar.Add(new Category("Dell"));
var evSinema = categoryComposite.Add(new Category("Ev sinema sistemleri"));
var bluetooth = evSinema.Add(new Category("bluetooth"));

CategoryComposite<Category>.Demo(1, categoryComposite);

public class Category : IComparable<Category>
{
    public int CompareTo(Category? other)
    {
        return this == other ? 0 : -1;
    }
    public string Name { get; set; }
    public Category(string name)
    {
        Name = name;
    }
    public override string ToString()
    {
        return Name;
    }
}
public class CategoryComposite<T> where T : IComparable<T>
{
    public T Node { get; set; }
    public List<CategoryComposite<T>> Children { get; private set; } = new List<CategoryComposite<T>>();

    public CategoryComposite<T> Add(T child)
    {
        CategoryComposite<T> newCategory = new CategoryComposite<T>() { Node = child };
        Children.Add(newCategory);
        return newCategory;

    }

    public static void Demo(int level, CategoryComposite<T> composite)
    {
        string line = new string('-', level);
        Console.WriteLine($"{line}{composite.Node}");
        foreach (var item in composite.Children)
        {
            Demo(level + 1, item);
        }
    }
}