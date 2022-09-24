
using System.Collections;


/*
 * Problem:
 * Bir koleksiyonunuz var  ve bu koleksiyonda; ihtiyacınıza göre elemanlar arasında hareket etmek istiyorsunuz (ileri, geri, başa dön, sona git)
 * 
 */
Iterator<News> galerie = new Iterator<News>();
galerie.Add(new News() { Title = "Deprem bilimci uyardı!" });
galerie.Add(new News() { Title = "Magazin haber" });
galerie.Add(new News() { Title = "Komedi bir haber" });

foreach (var item in galerie)
{

}
galerie.Next();
Console.WriteLine(galerie.Current.Title);

galerie.Before();
Console.WriteLine(galerie.Current.Title);
var lastNew = galerie.Last();
var firstNew = galerie.First();
Console.WriteLine(lastNew.Title);
Console.WriteLine(firstNew.Title);



public class News
{
    public string Title { get; set; }
}


public class Iterator<T> : IEnumerable<T>
{

    List<T> collection = new List<T>();
    public void Add(T item)
    {
        collection.Add(item);
        Current = collection[0];
    }



    public int Count { get => collection.Count; }

    public IEnumerator<T> GetEnumerator()
    {
        foreach (var item in collection)
        {
            yield return item;

        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
    public Iterator()
    {

    }


    public int Position { get; set; }
    public T Current { get; set; }
    public T Next()
    {
        Position++;
        Current = collection[Position];
        return collection[Position];
    }

    public T Before()
    {
        Position--;
        Current = collection[Position];
        return Current;
    }

    public T First()
    {
        return collection[0];
    }

    public T Last()
    {
        return collection[collection.Count - 1];
    }

}