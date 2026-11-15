using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class ServiceLocator
{
    private static readonly Dictionary<Type, IService> _services = new Dictionary<Type, IService>();
    //----------------------------------------
    //Singleton
    public static ServiceLocator instance;
    private ServiceLocator() { }

    public static ServiceLocator getInstance()
    {
        if(instance == null)
        {
            instance = new ServiceLocator();
        }

        return instance;
    }
    //----------------------------------------


    public  void RegisterService<T>(T service) where T : IService
    {
        Type serviceType = typeof(T);
        if (!_services.ContainsKey(serviceType))
        {
            _services[serviceType] = service; //Añades pares clave valor, Asi evitamos dos servicios de un mismo tipo
        }
    }

    public  T GetService<T>() where T : IService
    {
        Type serviceType = typeof(T);
        if (_services.ContainsKey(serviceType))
        {
            return (T)_services[serviceType];  //Casting a T, T es un servicio concreto e IService es generico
        }

        throw new Exception("No existe el servicio solicitado en el registro de ServiceLocator.");
    }

    public  void Clear()
    {
        _services.Clear();
    }
}

