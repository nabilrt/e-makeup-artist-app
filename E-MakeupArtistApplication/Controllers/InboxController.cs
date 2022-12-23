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
            var data=InboxServices.getArtistMessages(artist);

            return Request.CreateResponse(HttpStatusCode.OK, data);

        }

        [Route("api/customer/inbox")]
        [HttpPost]
        [CustomerAuth]
        public HttpResponseMessage getCustomerInbox(CustomerDTO customer)
        {
            var data=InboxServices.getCustomerMessages(customer);

            return Request.CreateResponse(HttpStatusCode.OK,data);
        }

        [Route("api/inbox/add")]
        [HttpPost]
        [CustomerAuth]

        public HttpResponseMessage addInbox(InboxDTO inbox)
        {
            var data = InboxServices.addInbox(inbox);

            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/inbox/delete/{id}")]
        [HttpGet]
        [CustomerAuth]

        public HttpResponseMessage deleteMessage(int id)
        {
            var data=InboxServices.deleteInbox(id);

            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        
    }
}
