namespace Constructor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CamasirMakinesi makine = new CamasirMakinesi();
            Console.WriteLine(makine.Renk);
            CamasirMakinesi baskaBirMakine = new CamasirMakinesi(Enerji.APlus, 10);
        }
    }
}