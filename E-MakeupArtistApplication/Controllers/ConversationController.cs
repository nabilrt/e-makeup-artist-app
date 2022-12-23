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
    [EnableCors("*", "*", "*")]
    public class ConversationController : ApiController
    {
        [Route("api/conversations/customer/inbox/{id}")]
        [HttpGet]
        [CustomerAuth]
        public HttpResponseMessage getCustomerArtistConvos(int id)
        {
            var data=ConversationServices.getConversations(id);

            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/conversations/artist/inbox/{id}")]
        [HttpGet]
        [ArtistAuth]
        public HttpResponseMessage getArtistCustomerConvos(int id)
        {
            var data = ConversationServices.getConversations(id);

            return Request.CreateResponse(HttpStatusCode.OK, data);

        }

    }
}
