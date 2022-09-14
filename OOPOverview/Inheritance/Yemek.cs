namespace Inheritance
{
    public class Yemek
    {
        public int PismeSuresi { get; set; }
        public decimal Fiyat { get; set; }
        public List<string> Malzemeler { get; set; } = new List<string>();

        public void Pisir()
        {
            Console.WriteLine(GetType().Name + " pişiriliyor...");
        }

        public virtual void SunumYap()
        {
            Console.WriteLine($"{GetType().Name} yemeği yanında pilav ile sunuluyor....");
        }
    }

    public class Corba : Yemek
    {

    }

    public class Ezogelin : Corba
    {

    }

    public class Pilav : Yemek
    {

    }

    public class Tatli : Yemek
    {
        public override void SunumYap()
        {
            Console.WriteLine("Tatlı yanında su ikramımızdır");
        }
    }

    public class Tulumba : Tatli
    {

    }

    public class SebzeYemegi : Yemek
    {

    }

    public class Pirasa : SebzeYemegi
    {

    }

    public class EtYemegi : Yemek
    {

    }

    public class Kofte : EtYemegi
    {

    }
}