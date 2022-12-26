using E_MakeupArtistApplication.Auth;
using E_MakeupArtistApplicationBussinessLogicLayer.DTOs;
using E_MakeupArtistApplicationBussinessLogicLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace E_MakeupArtistApplication.Controllers
{
    [EnableCors("*", "*", "*")]
    public class CustomerController : ApiController
    {
        [Route("api/customers")]
        [HttpGet]
       // [AdminAuth]

        public HttpResponseMessage getAllCustomers()
        {
            var data = UserCustomerServices.getALL();

            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/customer/get/{id}")]
        [HttpGet]
        public HttpResponseMessage getCustomerById(int id)
        {
            var data = UserCustomerServices.GetUserCustomer(id);

            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/customer/details")]
        [HttpPost]
        [CustomerAuth]
        public HttpResponseMessage getCustomer(CustomerDTO customerDTO)
        {
            var data = UserCustomerServices.GetUserCustomer(customerDTO.Id);

            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/customer/add")]
        [HttpPost]
        public HttpResponseMessage AddUserCustomer(UserCustomerDTO userCustomerDTO)
        {
            var data = UserCustomerServices.AddUserCustomer(userCustomerDTO);

            return Request.CreateResponse(HttpStatusCode.OK,data);
        }

        [Route("api/customer/update")]
        [HttpPost]
        [CustomerAuth]
        public HttpResponseMessage UpdateUserCustomer(UserCustomerDTO userCustomerDTO)
        {
            var data=UserCustomerServices.UpdateUserCustomer(userCustomerDTO);

            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/customer/delete/{id}")]
        [HttpGet]
        public HttpResponseMessage DeleteUserCustomer(int id)
        {
            var data=UserCustomerServices.DeleteUserCustomer(id);

            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/customer/message/send")]
        [HttpPost]
        [CustomerAuth]
        public HttpResponseMessage sendMessage(ConversationDTO conversationDTO)
        {
            var data = ConversationServices.SendMessage(conversationDTO);

            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/customer/conversation/{id}")]
        [HttpGet]
        [CustomerAuth]
        public HttpResponseMessage getConversation(int id)
        {
            var data = ConversationServices.GetConversation(id);

            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/customer/message/reply")]
        [HttpPost]
        [CustomerAuth]
        public HttpResponseMessage replyMessage(ConversationDTO conversationDTO)
        {
            var data = ConversationServices.ReplyMessage(conversationDTO);

            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
    }
}
