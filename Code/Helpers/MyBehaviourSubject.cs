using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Project.Helpers
{
    public class MyBehaviourSubject<T> :
            INotifyPropertyChanged,
            IObservable<T>
    {
        T _value;
        public T Value
        {
            get => _value;
            set
            {
                _value = value;
                OnNext(_value);
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged = null;

        List<IObserver<T>> _observers = new List<IObserver<T>>();

        public MyBehaviourSubject(PropertyChangedEventHandler propertyChangedHandler, T initValue = default!)
            => (PropertyChanged, _value) = (propertyChangedHandler, initValue);

        private void OnPropertyChanged(string argName)
        {
            var handler = PropertyChanged;
            if (handler is not null)
                handler(this, new PropertyChangedEventArgs(argName));
        }


        // Send OnNext message to observers without updating .Value
        public void OnNext(T value)
        {
            _observers ??= new List<IObserver<T>>();
            foreach (var observer in _observers)
                observer.OnNext(Value);
            OnPropertyChanged(nameof(Value));
        }

        public IDisposable Subscribe(IObserver<T> observer)
        {
            _observers ??= new List<IObserver<T>>();

            _observers.Add(observer);
            return new Unsubscriber(this, observer);
        }
        public IDisposable Subscribe(Action<T> next, Action<Exception> error = null, Action complete = null)
        {
            var newObserver = new PrimitiveObserver<T>(next, error, complete);
            return Subscribe(newObserver);
        }


        private class Unsubscriber : IDisposable
        {
            private MyBehaviourSubject<T> _behaviourSubject;
            private IObserver<T> _observer;

            public Unsubscriber(MyBehaviourSubject<T> behaviourSubject, IObserver<T> observer)
            {
                _behaviourSubject = behaviourSubject;
                _observer = observer;
            }

            public void Dispose()
            {
                if (_observer is not null && _behaviourSubject._observers.Contains(_observer))
                    _behaviourSubject._observers.Remove(_observer);
            }
        }
    }
}
