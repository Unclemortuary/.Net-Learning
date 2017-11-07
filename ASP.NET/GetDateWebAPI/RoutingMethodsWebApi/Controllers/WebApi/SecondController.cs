using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RoutingMethodsWebApi.Controllers.WebApi
{
    public class SecondController : ApiController
    {
        [HttpGet]
        public string BlaBla()
        {
            return "BlaBla method of Second controller triggered";
        }
    }
}
