namespace AbstractANDInterface
{
    public abstract class Document
    {
        public string Title { get; set; }
        public string Owner { get; set; }
        public DateTime CreatedDate { get; set; }
        public void Copy(string from, string to)
        {
            Console.WriteLine("dosya kopyalandı");
        }

        public abstract void Save(string path);
        public abstract void Open(string path);

        //public abstract void Print();

    }


    public interface IPrintable
    {
        void Print();
    }

    public class ExcelDocument : Document, IPrintable
    {
        public override void Open(string path)
        {
            Console.WriteLine($"{GetType().Name} açıldı");
        }

        public void Print()
        {
            Console.WriteLine("çıktı...");

        }

        //public override void Print()
        //{
        //    throw new NotImplementedException();
        //}

        public override void Save(string path)
        {
            Console.WriteLine($"{GetType().Name} kaydedildi...");
        }
    }

    public class PDFDocument : Document
    {
        public override void Open(string path)
        {
            Console.WriteLine($"{GetType().Name} açıldı");

        }

        //public override void Print()
        //{
        //    throw new NotImplementedException();
        //}

        public override void Save(string path)
        {
            Console.WriteLine($"{GetType().Name} kaydedildi...");

        }
    }

    public class WordDocument : Document, IPrintable, IEquatable<Document>
    {
        public bool Equals(Document? other)
        {
            throw new NotImplementedException();
        }

        public override void Open(string path)
        {
            Console.WriteLine($"{GetType().Name} açıldı");

        }

        public void Print()
        {
            Console.WriteLine("çıktı...");
        }

        //public override void Print()
        //{
        //    throw new NotImplementedException();
        //}

        public override void Save(string path)
        {
            Console.WriteLine($"{GetType().Name} kaydedildi...");

        }


    }

    public class PrintComponent
    {
        public void Print(IPrintable printable)
        {
            printable.Print();
        }
    }
}
