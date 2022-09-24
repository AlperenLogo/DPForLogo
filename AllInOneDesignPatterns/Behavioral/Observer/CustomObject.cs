using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    public class CustomObject : IObservable<AnItem>
    {
        public IDisposable Subscribe(IObserver<AnItem> observer)
        {
            throw new NotImplementedException();
        }
    }

    public class AnItem
    {

    }

    public class CstomObserver : IObserver<AnItem>
    {
        public void OnCompleted()
        {
            throw new NotImplementedException();
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnNext(AnItem value)
        {
            throw new NotImplementedException();
        }
    }
}
