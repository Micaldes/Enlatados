using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enlatados.Core.Code.ObjectPool
{
    public interface IPool<T>
    {
        public List<T>coleccion { get; set; }

        public T getNextAvailable();

        public void returnObject(T dato);
    }
}
