using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public interface ISubject<T>
{
    public void AddObserver(IObserver<T> observer);
    public void RemoveObserver(IObserver<T> observer);
    public void NotifyObservers(T data);

}

