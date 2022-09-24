// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

/*
 * Problem:
 * 
 * Bir şirkette rapor oluşturucu yazıyoruz. Modelimiz şöyle:
 * 
 *      Rapor
 *      /  \
 *     /    \
 *   Satış  Performans 
 *    / \        /  \
 *  PDF  HTML   PDF HTML
 *  
 *  Buradaki sorun gelecekte farklı bir rapor formatı ihtiyacı olduğunda tüm inheritance kaosunun (JSON için Satış'dan miras almak) yaşanmasıdır.
 *  
 *  
 *    Rapor {Rapor Format (get;set;)}                          RaporFormat
 *        Satış ve Performans                                   PDF, HTML
 *  
 */

PerformanceReport performanceReport = new PerformanceReport(new PDF());
performanceReport.Format = new HTML();
performanceReport.Format = new Json();

public class Format
{

}

public class HTML : Format
{

}
public class Json : Format
{

}

public class PDF : Format
{

}


public class Report
{
    public Report(Format format)
    {
        Format = format;
    }
    public Format Format { get; set; }
}

public class SalesReport : Report
{
    public SalesReport(Format format) : base(format)
    {
    }
}

public class PerformanceReport : Report
{
    public PerformanceReport(Format format) : base(format)
    {
    }
}