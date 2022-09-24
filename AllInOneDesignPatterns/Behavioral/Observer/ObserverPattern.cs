namespace Observer
{
    /*
     * Problem:
     * Bir nesne üzerinde oluşan bir değişikliği; başka nesnelere nasıl yansıtırım?
     * 
     * X üzerinde değişiklik yapıldığında; daha önce sisteme abone olmuş olan Y türünde nesnelerin belli metotları çağrılır!
     */

    public interface IObserver
    {
        void ChangeColor(Color color);
    }

    public interface ISubscription
    {
        void Subscribe(IObserver observer);
        void Unsubscribe(IObserver observer);
        void Notify();
    }

    public class ObservableColorSubscription : ISubscription
    {
        private List<IObserver> _observers = new List<IObserver>();
        private Color color;

        public Color Color
        {
            get => color;
            set
            {
                color = value;
                Notify();
            }
        }

        public void Notify()
        {
            _observers.ForEach(o => o.ChangeColor(color));
        }

        public void Subscribe(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void Unsubscribe(IObserver observer)
        {
            _observers.Remove(observer);
        }
    }


}
