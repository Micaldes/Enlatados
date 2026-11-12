using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public static class ServiceLocator
{
    private static readonly Dictionary<Type, IService> _services = new Dictionary<Type, IService>();

    public static void RegisterService<T>(T service) where T : IService
    {
        Type serviceType = typeof(T);
        if (!_services.ContainsKey(serviceType))
        {
            _services[serviceType] = service;
        }
    }

    public static T GetService<T>() where T : IService
    {
        Type serviceType = typeof(T);
        if (_services.ContainsKey(serviceType))
        {
            return (T)_services[serviceType];
        }

        throw new Exception("No existe el servicio solicitado en el registro de ServiceLocator.");
    }

    public static void Clear()
    {
        _services.Clear();
    }
}

