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
    public class InboxController : ApiController
    {
        [Route("api/artist/inbox")]
        [HttpPost]
        [ArtistAuth]
        public HttpResponseMessage getArtistInbox(ArtistDTO artist)
        {
            try
            {
                var data = InboxServices.getArtistMessages(artist);

                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch(Exception ex) 
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        

        }

        [Route("api/customer/inbox")]
        [HttpPost]
        [CustomerAuth]
        public HttpResponseMessage getCustomerInbox(CustomerDTO customer)
        {
            try
            {
                var data = InboxServices.getCustomerMessages(customer);

                return Request.CreateResponse(HttpStatusCode.OK, data);

            }
            catch(Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        
        }

        [Route("api/inbox/add")]
        [HttpPost]
        [CustomerAuth]

        public HttpResponseMessage addInbox(InboxDTO inbox)
        {
            try
            {
                var data = InboxServices.addInbox(inbox);

                return Request.CreateResponse(HttpStatusCode.OK, data);

            }
            catch(Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
           
        }

        [Route("api/inbox/delete/{id}")]
        [HttpGet]
        [CustomerAuth]

        public HttpResponseMessage deleteMessage(int id)
        {
            try
            {
                var data = InboxServices.deleteInbox(id);

                return Request.CreateResponse(HttpStatusCode.OK, data);

            }catch(Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
           
        }

        
    }
}
