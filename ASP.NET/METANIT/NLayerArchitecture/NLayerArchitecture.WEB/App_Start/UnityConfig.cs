using System.Web.Mvc;
using NLayerArchitecture.BLL.Services;
using NLayerArchitecture.BLL.Interfaces;
using Unity;
using Unity.Mvc5;
using System;

namespace NLayerArchitecture.WEB
{
    public static class UnityConfig
    {
        private static UnityContainer container = new UnityContainer();

        public static void RegisterComponents(string connection)
        {
            ServiceRegistrator.RegisterServices(container, connection);
            container.RegisterType<IOrderService, OrderService>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}