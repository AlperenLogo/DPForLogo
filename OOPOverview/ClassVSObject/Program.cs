namespace ClassVSObject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Personel p = new Personel();

            p.Ad = "Türkay";
            Personel p2 = p;
            p2.Ad = "İrem";

            Console.WriteLine(p.Ad);
        }
    }
}