using E_MakeupArtistApplication.Auth;
using E_MakeupArtistApplicationBussinessLogicLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace E_MakeupArtistApplication.Controllers
{
    [EnableCors("*","*","*")]
    public class OrderDetailController : ApiController
    {
        [Route("api/orderDetails/{id}")]
        [HttpGet]
        [CustomerAuth]
        public HttpResponseMessage GetOrderDetailsByOrder(int id)
        {
            var data=OrderDetailServices.GetOrdersById(id);

            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
    }
}
