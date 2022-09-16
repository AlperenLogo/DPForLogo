
//Problem:
/*
 * Bir nesneyi oluşturan birden fazla aşama olsun.
 *   Söz konusu aşamaları yöneterek nesneyi inşa etmek için nasıl bir yöntem izlersiniz?
 *   
 *   Bir rapor;
 *      Başlık,
 *      İçerik,
 *      Grafik
 *      Hazırlayanlar
 *   bölümlerinden oluşmaktadır. Builder pattern ile rapor nesnesi oluşturalım.
 *   
 */

PerformanceReportBuilder performanceReport = new PerformanceReportBuilder();
//var report = performanceReport.Report;
//Console.WriteLine(performanceReport);

ReportCreator reportCreator = new ReportCreator();
reportCreator.Create(performanceReport);
reportCreator.Show();
var report = reportCreator.GetReport();


//Aşağıdaki enum'lar işimizi kolaylaştırmak için PATTERN İLE ALAKASI YOK



public enum ReportPart
{
    Title,
    Content,
    Graph,
    Owners
}

public enum ReportTypes
{
    Performance,
    Sales,
    Vehicle
}

public class Report
{
    private Dictionary<ReportPart, string> parts = new Dictionary<ReportPart, string>();
    private ReportTypes reportType;
    public Report(ReportTypes reportType)
    {
        this.reportType = reportType;
    }

    public string this[ReportPart index]
    {
        get { return parts[index]; }
        set { parts[index] = value; }
    }

    public void Demo()
    {
        Console.WriteLine($"{reportType} türündeki raporun: ");

        Console.WriteLine($"Başlık: {parts[ReportPart.Title]}");
        Console.WriteLine($"İçerik: {parts[ReportPart.Content]}");
        Console.WriteLine($"Grafik: {parts[ReportPart.Graph]}");
        Console.WriteLine($"Yazanlar: {parts[ReportPart.Owners]}");



    }

}

public abstract class ReportBuilder
{
    public Report Report { get; private set; }

    public ReportBuilder(ReportTypes type)
    {
        Report = new Report(type);
    }

    public abstract void CreateTitle();
    public abstract void CreateContent();
    public abstract void CreateGraph();
    public abstract void CreateOwners();




}

public class PerformanceReportBuilder : ReportBuilder
{
    public PerformanceReportBuilder() : base(ReportTypes.Performance)
    {

    }
    public override void CreateContent()
    {
        Report[ReportPart.Content] = "Performans raporu içeriği....";
    }

    public override void CreateGraph()
    {
        Report[ReportPart.Graph] = "Performans raporu gragiği....";

    }

    public override void CreateOwners()
    {
        Report[ReportPart.Owners] = "Performans raporu hazırlayanlar....";

    }

    public override void CreateTitle()
    {
        Report[ReportPart.Title] = "Performans raporu başlığı....";

    }
}

public class ReportCreator
{
    public ReportBuilder reportBuilder;
    public void Create(ReportBuilder reportBuilder)
    {
        this.reportBuilder = reportBuilder;
        reportBuilder.CreateTitle();
        reportBuilder.CreateContent();
        reportBuilder.CreateGraph();
        reportBuilder.CreateOwners();
    }

    public Report GetReport()
    {
        return reportBuilder.Report;
    }
    public void Show()
    {
        reportBuilder.Report.Demo();
    }
}