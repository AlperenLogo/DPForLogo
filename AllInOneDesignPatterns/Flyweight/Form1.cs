namespace Flyweight
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonDraw_Click(object sender, EventArgs e)
        {
            createPlanets(panel1.CreateGraphics(), numericUpDown1.Value);
        }

        private void createPlanets(Graphics graphics, decimal value)
        {
            var colors = new List<Color>() { Color.Red, Color.Blue, Color.Yellow };
            Random random = new Random();
            for (int i = 0; i < value; i++)
            {
                Planet planet = PlanetFlyweight.CreatePlanet(colors[random.Next(colors.Count)]);
                planet.X = random.Next(panel1.Width);
                planet.Y = random.Next(panel1.Height);
                planet.Radius = random.Next(2, 100);
                planet.Draw(graphics);

            }
        }
    }
}