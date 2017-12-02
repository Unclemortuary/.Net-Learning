using NLayerArchitecture.DAL.Repositories;
using NLayerArchitecture.DAL.Interfaces;
using Unity;
using Unity.Injection;

namespace NLayerArchitecture.BLL.Services
{
    public class ServiceRegistrator
    {
        public static void RegisterServices(IUnityContainer container, string connection)
        {
            container.RegisterType<IUnitOfWork, UnitOfWork>(new InjectionConstructor(connection));
        }
    }
}
