/*
 * Problem:
 * 
 * Bir nesne; kendisine bağlı birkaç başka nesne(ler)den oluşmaktadır.  İstemcinin; iç nesnelere müdahale etmeden bu nesneyi üretebilmesi için nasıl bir tasarım yapılmalı?
 * 
 * Turistlere yönelik bir harita uygulaması yapıyorsunuz.
 *     - Müze, Sergi gibi kültür haritası
 *     - Camii, Kilise gibi inanç haritası
 *     - Bar, Cafe gibi eğlence mekanları haritası
 *   
 * Bir harita; kendisine bağlı ziyaret edilmesi gereken yerler koleksiyonu ile oluşmaktadır. Harita türünden instance alındığında tüm bu noktaların oluşması gerekir.
 * 
 * CultureMap map = new CultureMap();
 * map.VisitPoints.Foreach(vp=>Write(vp.Name))
 * 
 * 
 *     
 */

CultureMap map = new CultureMap();
map.VisitPoints.ForEach(vp => Console.WriteLine(vp.Info));












ReligionMap religionMap = new ReligionMap();
var visitPoints = religionMap.VisitPoints;
Console.ReadLine();

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
        //db'den geliyor....
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

