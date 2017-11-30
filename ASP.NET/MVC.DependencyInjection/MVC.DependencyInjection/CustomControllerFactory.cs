using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC.DependencyInjection.Controllers;
using System.Web.SessionState;

namespace MVC.DependencyInjection
{
    public class CustomControllerFactory : IControllerFactory
    {
        public IController CreateController(System.Web.Routing.RequestContext requestContext, string controllerName)
        {
            ILogger logger = new DefaultLogger();
            var controller = new HomeController(logger);
            return controller;
        }

        public System.Web.SessionState.SessionStateBehavior GetControllerSessionBehavior(
           System.Web.Routing.RequestContext requestContext, string controllerName)
        {
            return SessionStateBehavior.Default;
        }

        public void ReleaseController(IController controller)
        {
            IDisposable disposable = controller as IDisposable;
            if (disposable != null)
                disposable.Dispose();
        }
    }
}