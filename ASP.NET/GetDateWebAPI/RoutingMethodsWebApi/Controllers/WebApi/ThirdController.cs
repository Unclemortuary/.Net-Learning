using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RoutingMethodsWebApi.Controllers.WebApi
{
    public class ThirdController : ApiController
    {
        public string GetSomthing()
        {
            return "GetSomething method of Third controller triggered";
        }
    }
}
