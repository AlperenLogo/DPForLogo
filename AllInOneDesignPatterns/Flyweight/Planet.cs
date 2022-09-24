namespace Flyweight
{
    /*
     * Problem:
     * Bellekte çok fazla elemandan dolayı, çok yer kaplayacağını düşündüğünüz bir yapıyı
     * doğru bir yaklaşımla parçalara ayırmanız gerekiyor. İşte bu durumda Tüy siklet deseninden faydalanıyorsunuz.
     */
    public class Planet
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Radius { get; set; }
        public Brush Color { get; set; }

        public Planet(Color color)
        {
            SolidBrush solidBrush = new SolidBrush(color);
            Color = solidBrush;
        }

        public void Draw(Graphics g)
        {
            g.FillEllipse(Color, X, Y, Radius, Radius);
        }

    }

    public static class PlanetFlyweight
    {
        private static Dictionary<Color, Planet> planets = new Dictionary<Color, Planet>();
        public static Planet CreatePlanet(Color color)
        {
            if (!planets.ContainsKey(color))
            {
                Planet planet = new Planet(color);
                planets.Add(color, planet);

            }
            return planets[color];
        }
    }


}
