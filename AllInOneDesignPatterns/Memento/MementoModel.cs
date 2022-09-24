namespace Memento
{
    public class MementoModel
    {
        public Memento Memento { get; set; }
        public FormSettings FormSettings { get; set; } = new FormSettings();
    }
}
