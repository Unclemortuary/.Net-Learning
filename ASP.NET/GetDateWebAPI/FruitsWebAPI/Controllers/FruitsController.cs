using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Services;

namespace FruitsWebAPI.Controllers
{
    public class FruitsController : ApiController
    {
        static string[] _fruits =
        {
            "Orange",
            "Apple",
            "Pineapple",
            "Plum",
        };

        //GET api/name
        [WebMethod]
        public IEnumerable<string> Get()
        {
            return _fruits;
        }


        //GET api/values/5
        #region Такой запрос возвращает ошибку сервера, если элемента с нашим id не существует
        //public string Get(int id)
        //{
        //    return _fruits[id];
        //}
        #endregion




        public HttpResponseMessage Get(int id)
        {
            if (id < _fruits.Length)
            {
                return Request.CreateResponse(HttpStatusCode.OK, _fruits[id]);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Item not found");//Status code 404
            }
        }
    }
}
