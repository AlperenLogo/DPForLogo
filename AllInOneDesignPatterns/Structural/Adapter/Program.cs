// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

/*
 * Problem:
 * 
 * Uygulamanız belirli bir kaynaktan bir veri girdisi istiyor. Ancak bu veriyi sağlayacak kaynaklar birbirlerinden tamamen farklı. Bu kaynakların çıktısını, istediğiniz girdiye nasıl dönüştürürsünüz?
 * 
 * Senaryo:
 * İki adet basınçlı tanktan iki farklı sensörden basınç değerlerini okumaktasınız. Gelen veriyi ihtiyacınız olana nasıl dönüştürürsünüz?
 */

PressureAdapter pressureAdapter = new PressureAdapter();
pressureAdapter.ReadFrom(new SiemensSensor());
pressureAdapter.ReadFrom(new FestoSensor());



public interface IPressureValueReader
{
    byte[] ReadData();
}

public class SiemensSensor : IPressureValueReader
{
    public byte[] ReadData()
    {
        Console.WriteLine("Siemens'den okunuyor");
        return new byte[0];
    }
}

public class FestoSensor : IPressureValueReader
{
    public byte[] ReadData()
    {
        Console.WriteLine("Festo'dan okunuyor");

        return new byte[0];
    }
}

public class PressureAdapter
{
    public int ReadFrom(IPressureValueReader pressureValueReader)
    {
        var data = pressureValueReader.ReadData();
        return 1;
    }
}