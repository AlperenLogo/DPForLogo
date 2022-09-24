namespace Proxy
{
	public interface IMath
	{
		int Add(int x, int y);
		int Subtract(int x, int y);
	}

	public class RealMath : IMath
	{
		public int Add(int x, int y)
		{
			return x + y;
		}

		public int Subtract(int x, int y)
		{
			return x - y;
		}
	}

	public class ProxyMath : IMath
	{
		private RealMath realMath;
		public ProxyMath()
		{
			realMath = new RealMath();
		}
		public int Add(int x, int y)
		{
			//Güvenlik denetimi...
			//Loglama...
			//Özel bir operasyon
			//Exception management
			return realMath.Add(x, y);
		}

		public int Subtract(int x, int y)
		{
			return realMath.Subtract(x, y);
		}
	}
}
