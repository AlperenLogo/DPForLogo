using System.Collections.ObjectModel;

namespace Observer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBoxTest_TextChanged(object sender, EventArgs e)
        {
            label1.Text = textBoxTest.Text;
        }

        ObservableColorSubscription colorSubscription = new ObservableColorSubscription();

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(colorSubscription);
            form2.Show();

            ObservableCollection<string> words = new ObservableCollection<string>();
            words.CollectionChanged += Words_CollectionChanged;
        }

        private void Words_CollectionChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case System.Collections.Specialized.NotifyCollectionChangedAction.Add:

                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Replace:
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Move:
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Reset:
                    break;
                default:
                    break;
            }
        }

        private void buttonChangeColor_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                colorSubscription.Color = colorDialog.Color;
            }
        }
    }
}