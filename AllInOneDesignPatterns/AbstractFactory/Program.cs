namespace AbstractFactory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             * Problem:
             * Aynı tipten türeyen A,B,C nesneleriniz var. Her bir nesne de kendi içinde A1, A2 ve A3 gibi varyantlara sahip.
             * 
             * A2 B2 C2
             * A1 B1 C1
             * A3 B3 C3
             * 
             * Senaryo:
             * Factory Method'daki örneğe ek olarak Sokak ya da Uydu haritası görünümü eklemek istiyoruz. Turist, hangi türde ne haritası görmek istediğini belirtir ve sistem bu ihtiyacı otomatik karşılar.
             * 
             */
            Map<StreetReligionMap> map1 = new Map<StreetReligionMap>();
            map1.Show();

        }
    }

    public interface IMapFormat
    {
        void AddToMap(IRecommendedVisitPoint point);
    }

    public class SatelliteMap : IMapFormat
    {
        public void AddToMap(IRecommendedVisitPoint point)
        {
            Console.WriteLine($"{point.Info} haritaya eklendi");
        }
    }

    public class StreetMap : IMapFormat
    {
        public void AddToMap(IRecommendedVisitPoint point)
        {
            Console.WriteLine($"{point.Info} haritaya eklendi");
        }
    }


    public interface IMapCreator
    {
        List<IRecommendedVisitPoint> visitPoints();
        IMapFormat mapFormat();
    }

    public class SatelliteCultureMap : IMapCreator
    {
        public IMapFormat mapFormat()
        {
            return new SatelliteMap();
        }

        public List<IRecommendedVisitPoint> visitPoints()
        {
            return new CultureMap().VisitPoints;
        }
    }

    public class StreetCultureMap : IMapCreator
    {
        public IMapFormat mapFormat()
        {
            return new StreetMap();
        }

        public List<IRecommendedVisitPoint> visitPoints()
        {
            return new CultureMap().VisitPoints;
        }
    }

    public class SatelliteReligion : IMapCreator
    {
        public IMapFormat mapFormat()
        {
            return new SatelliteMap();
        }

        public List<IRecommendedVisitPoint> visitPoints()
        {
            return new ReligionMap().VisitPoints;
        }
    }

    public class StreetReligionMap : IMapCreator
    {
        public IMapFormat mapFormat()
        {
            return new StreetMap();
        }

        public List<IRecommendedVisitPoint> visitPoints()
        {
            return new ReligionMap().VisitPoints;
        }
    }

    public class Map<T> where T : IMapCreator, new()
    {
        private IMapFormat format;
        private T mapCreator;


        public Map()
        {
            mapCreator = new T();
            format = mapCreator.mapFormat();
        }
        public void Show()
        {
            Console.WriteLine($"Harita formatı: {format.GetType().Name}");
            mapCreator.visitPoints().ForEach(vp => Console.WriteLine(vp.Info));
        }
    }


    #region Factory Method'dan aldık
    public interface IRecommendedVisitPoint
    {
        double Latitude { get; set; }
        double Longitude { get; set; }
        string Icon { get; set; }
        string Info { get; set; }
    }

    public class Church : IRecommendedVisitPoint
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Icon { get; set; }
        public string Info { get; set; }
    }

    public class Museum : IRecommendedVisitPoint
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Icon { get; set; }
        public string Info { get; set; }
    }

    public class Bar : IRecommendedVisitPoint
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Icon { get; set; }
        public string Info { get; set; }
    }

    public class Theatre : IRecommendedVisitPoint
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Icon { get; set; }
        public string Info { get; set; }
    }

    public class Mosquee : IRecommendedVisitPoint
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Icon { get; set; }
        public string Info { get; set; }
    }

    public abstract class MapBase
    {
        public List<IRecommendedVisitPoint> VisitPoints { get; set; }
        public MapBase()
        {
            VisitPoints = new List<IRecommendedVisitPoint>();
            addVisitPoint();
        }

        protected abstract void addVisitPoint();

    }

    public class CultureMap : MapBase
    {
        protected override void addVisitPoint()
        {
            var topkapi = new Museum { Info = "Topkapı Sarayı" };
            var haldunTaner = new Theatre { Info = "Kadıköy haldun taner sahnesi..." };

            VisitPoints.Add(topkapi);
            VisitPoints.Add(haldunTaner);


        }
    }

    public class ReligionMap : MapBase
    {
        protected override void addVisitPoint()
        {
            var ayasofya = new Mosquee { Info = "Ayasofya Camii" };
            var sultanahmet = new Mosquee { Info = "Sultanahmet camii" };

            VisitPoints.Add(ayasofya);
            VisitPoints.Add(sultanahmet);

        }
    }

    #endregion
}