namespace LiskovSubstution
{
    internal class Program
    {
        /*
         * Bir derived class; bir base class'ın davranışını değiştiremez. Yani, base ve derived birbirlerinin yerine kullanılabilir olmalıdır.
         */
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            var rect = Factory.GetRectangle(7);

            Console.WriteLine(rect.GetArea());



        }
    }



    public static class Factory
    {
        public static IAreaCalcutable GetRectangle(int width, int height = 1)
        {
            //bir biçimde...........
            if (height > 1)
            {
                return new Rectangle { Width = width, Height = height };
            }
            return new Square { UnitLength = width };
        }
    }

    public interface IAreaCalcutable
    {
        int GetArea();
    }
    public class Rectangle : IAreaCalcutable
    {

        protected int width;
        protected int height;
        public int Width { get => width; set => width = value; }
        public int Height { get => height; set => height = value; }

        public int GetArea() => Width * Height;
    }

    public class Square : IAreaCalcutable //: Rectangle
    {
        public int UnitLength { get; set; }
        public int GetArea() => UnitLength * UnitLength;


    }


    public class Scenerio
    {
        public void SetSource(DataSource dataSource)
        {
            dataSource.WriteData();
        }

        public DataSource GetDataSource(int number)
        {
            var isEven = number % 2 == 0;
            return isEven ? new XMLDataSource() : new DBDataSource();

        }
    }

    public class DataSource
    {
        public void GenerateReport()
        {

        }
        public void WriteData()
        {
            Console.WriteLine("Ok");
        }
    }

    public class XMLDataSource : DataSource
    {

    }

    public class DBDataSource : DataSource
    {

    }





}