// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
//Problem:
/*
 * Bir nesnenin, uygulama boyunca sadece 1 örneğe sahip olması gerekiyor. Bunu nasıl sağlarım.
 */
var helper = SqlDbHelper.Create();
helper.StateValue = 8;
Console.WriteLine(helper.StateValue);

var anotherHelper = SqlDbHelper.Create();
Console.WriteLine(anotherHelper.StateValue);

public class SqlDbHelper : IDbHelper
{
	private static SqlDbHelper instance;
	public static SqlDbHelper Create()
	{
		if (instance == null)
		{
			instance = new SqlDbHelper();
		}
		return instance;
	}

	public int StateValue { get; set; }
	private SqlDbHelper()
	{

	}
}


public interface IDbHelper
{
	int StateValue { get; set; }
}

//public static class StaticDbHelper : IDbHelper
//{
//	public int StateValue { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
//}