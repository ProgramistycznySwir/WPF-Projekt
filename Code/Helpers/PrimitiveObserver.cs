using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Project.Helpers
{
    public class PrimitiveObserver<T> : IObserver<T>
    {
        readonly Action<T> next;
        readonly Action<Exception> error;
        readonly Action complete;

        public PrimitiveObserver(Action<T> next, Action<Exception> error = null, Action complete = null)
        {
            this.next = next;
            this.error = error;
            this.complete = complete;
        }

        public void OnNext(T value)
            => next(value);
        public void OnError(Exception error)
        {
            if(this.error is not null)
                this.error(error);
        }
        public void OnCompleted()
        {
            if (this.complete is not null)
                this.complete();
        }
    }
}
