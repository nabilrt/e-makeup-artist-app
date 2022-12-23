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
    [EnableCors("*","*","*")]
    public class ArtistController : ApiController
    {
        [Route("api/artists")]
        [HttpGet]
        [ArtistAuth]
        public HttpResponseMessage getAllArtists()
        {
            var data = UserArtistServices.getALL();

            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/artist/add")]
        [HttpPost]

        public HttpResponseMessage addUser(UserArtistDTO userArtistDTO)
        {
            var data = UserArtistServices.Add(userArtistDTO);

            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/artist/{id}")]
        [HttpGet]

        public HttpResponseMessage getUser(int id)
        {
            var data = UserArtistServices.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/artist/update")]
        [HttpPost]
        public HttpResponseMessage updateUser(UserArtistDTO userArtistDTO)
        {
            var data = UserArtistServices.Update(userArtistDTO);

            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/artist/delete/{id}")]
        [HttpGet]
        public HttpResponseMessage deleteUser(int id)
        {
            var data = UserArtistServices.delete(id);

            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/artist/message/send")]
        [HttpPost]
        [ArtistAuth]
        public HttpResponseMessage sendMessage(ConversationDTO conversationDTO)
        {
            var data=ConversationServices.SendMessage(conversationDTO);

            return Request.CreateResponse(HttpStatusCode.OK,data);
        }

        [Route("api/artist/conversation/{id}")]
        [HttpGet]
        [ArtistAuth]
        public HttpResponseMessage getConversation(int id)
        {
            var data=ConversationServices.GetConversation(id);

            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/artist/message/reply")]
        [HttpPost]
        [ArtistAuth]
        public HttpResponseMessage replyMessage(ConversationDTO conversationDTO)
        {
            var data=ConversationServices.ReplyMessage(conversationDTO);

            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

    }
}
