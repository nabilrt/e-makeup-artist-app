using E_MakeupArtistApplication.Auth;
using E_MakeupArtistApplicationBussinessLogicLayer.DTOs;
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
    [EnableCors("*", "*", "*")]
    public class OrderController : ApiController
    {
        [Route("api/orders")]
        [HttpGet]
        [AdminAuth]
        public HttpResponseMessage GetAllOrders()
        {
            var data = OrderServices.GetOrder();

            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/artist/orders")]
        [HttpPost]
        [ArtistAuth]
        public HttpResponseMessage GetArtistOrders(ArtistDTO artistDTO)
        {
            var data = OrderServices.GetOrderByArtist(artistDTO.Id);

            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/customer/orders")]
        [HttpPost]
        [CustomerAuth]
        public HttpResponseMessage GetCustomerOrders(CustomerDTO customerDTO)
        {
            var data=OrderServices.GetOrderByCustomer(customerDTO.Id);

            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/order/add")]
        [HttpPost]
        [CustomerAuth]
        public HttpResponseMessage AddOrder(OrderDTO orderDTO)
        {
            var data = OrderServices.AddOrder(orderDTO);

            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/order/details/{id}")]
        [HttpGet]
        [ArtistAuth]
        public HttpResponseMessage GetOrderDetails(int id)
        {
            var data = OrderServices.GetOrder(id);

            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/order/update")]
        [HttpPost]
        [ArtistAuth]
        public HttpResponseMessage UpdateOrder(OrderDTO orderDTO)
        {
            var data= OrderServices.UpdateOrder(orderDTO);

            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/order/delete/{id}")]
        [HttpGet]
        [ArtistAuth]
        public HttpResponseMessage DeleteOrder(int id)
        {
            var data=OrderServices.deleteOrder(id);

            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
    }
}
