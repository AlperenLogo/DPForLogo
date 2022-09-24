namespace Proxy
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tcKimlikRef.KPSPublicSoapClient client = new tcKimlikRef.KPSPublicSoapClient(tcKimlikRef.KPSPublicSoapClient.EndpointConfiguration.KPSPublicSoap);

            var result = client.TCKimlikNoDogrulaAsync(1000000, "X", "Y", 1978);
            // result.Result.Body.
        }
    }
}