namespace Observer
{
    public partial class Form2 : Form, IObserver
    {
        private ObservableColorSubscription subscription;
        public Form2(ObservableColorSubscription subscription)
        {

            InitializeComponent();
            this.subscription = subscription;
        }

        public void ChangeColor(Color color)
        {
            BackColor = color;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            subscription.Subscribe(this);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            subscription.Unsubscribe(this);
        }
    }
}
