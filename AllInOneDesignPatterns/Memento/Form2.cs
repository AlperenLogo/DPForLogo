namespace Memento
{
    public partial class Form2 : Form
    {
        private readonly MementoModel mementoModel;

        private Memoriable<FormSettings> memoriable = new Memoriable<FormSettings>();
        public Form2(MementoModel mementoModel)
        {
            InitializeComponent();
            this.mementoModel = mementoModel;

            if (mementoModel.Memento != null)
            {
                mementoModel.FormSettings.Restore(mementoModel.Memento);
                this.Width = mementoModel.FormSettings.Width;
                this.Height = mementoModel.FormSettings.Height;
                this.Location = mementoModel.FormSettings.Position;

                //memoriable.Restore(mementoModel.Memento);
            }
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            mementoModel.FormSettings.Width = this.Width;
            mementoModel.FormSettings.Height = this.Height;
            mementoModel.FormSettings.Position = new Point(this.Location.X, this.Location.Y);

            mementoModel.Memento = mementoModel.FormSettings.Save();
        }
    }
}
