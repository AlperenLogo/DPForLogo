namespace TemplateMethod
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Sorun:
            //Aynı işlemi; aynı nesnelerin aynı metotlarıyla ve sırasıyla yapmak istiyoruz. Bu denetimi nasıl sağlarız.
            //
            ProductDataAccessObject productDataAccessObject = new ProductDataAccessObject();
            productDataAccessObject.Run();
        }
    }

    public interface IRunnable
    {
        void Run();
    }

    public abstract class DataAccessObject : IRunnable
    {
        public abstract void Connect();
        public bool IsConnected { get; set; }
        public abstract void Select();
        public abstract void Process();
        public abstract void Disconnect();
        public void Run()
        {
            Connect();
            if (IsConnected)
            {
                Select();
                Process();
                Disconnect();
            }
        }
    }

    public class ProductDataAccessObject : DataAccessObject
    {
        public override void Connect()
        {
            Console.WriteLine("Db'ye bağlandı");
            IsConnected = true;
        }

        public override void Disconnect()
        {
            Console.WriteLine("Db bağlantısı sonlandı");
        }

        public override void Process()
        {
            Console.WriteLine("Çekien veri işeniyor.....");
        }

        public override void Select()
        {
            Console.WriteLine("Select sorgusu çalışıyor");
        }
    }



}