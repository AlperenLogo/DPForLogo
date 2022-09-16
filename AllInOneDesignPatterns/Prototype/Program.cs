// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
//Problem: 
/*
 * Bir sınıftan nesne üretmek oldukça uzun sürüyorsa ve çok instance'a ihtiyacınız varsa bu maaliyeti nasıl düşüreceksiniz?
 * 
 * 
 */
//string[] items = { "A", "B", "C" };
//var copy = (string[])items.Clone();
//copy[1] = "D";

//Console.WriteLine();

var lt1 = new LongTimeProcess();
Console.WriteLine(lt1.Message);
var lt2 = (LongTimeProcess)lt1.Clone();
lt2.Message = "Bu 2. instance";
Console.WriteLine(lt2.Message);
var lt3 = (LongTimeProcess)lt1.Clone();
lt3.Message = "Bu 3. intance";
Console.WriteLine(lt3.Message);




public class LongTimeProcess : ICloneable
{
	public LongTimeProcess()
	{
		Thread.Sleep(10000);
		Message = "Oluşturuldu";
	}

	public string Message { get; set; }

	public Random Random { get; set; }

	public object Clone()
	{
		return this.MemberwiseClone();
	}
	public object Clone(bool isDeep)
	{
		return isDeep ? deepClone() : Clone();
	}

	private object deepClone()
	{
		//serialize this 
		//desaerialize this
		return MemberwiseClone();
	}
}

public class Address
{
	public string City { get; set; }
}
public class Person
{
	public Address Address { get; set; }
}


