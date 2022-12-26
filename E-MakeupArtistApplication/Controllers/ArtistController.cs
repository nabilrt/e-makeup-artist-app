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
       
        public HttpResponseMessage getAllArtists()
        {
            try
            {
                var data = UserArtistServices.getALL();

                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [Route("api/artist/add")]
        [HttpPost]

        public HttpResponseMessage addUser(UserArtistDTO userArtistDTO)
        {
            try
            {
                var data = UserArtistServices.Add(userArtistDTO);

                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
           
        }

        [Route("api/artist/get/{id}")]
        [HttpGet]
     

        public HttpResponseMessage getUser(int id)
        {
            try
            {
                var data = UserArtistServices.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);

            }catch(Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
          
        }

        [Route("api/artist/update")]
        [HttpPost]
        [ArtistAuth]
        public HttpResponseMessage updateUser(UserArtistDTO userArtistDTO)
        {
            try
            {
                var data = UserArtistServices.Update(userArtistDTO);

                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }

        }

        [Route("api/artist/delete/{id}")]
        [HttpGet]
        public HttpResponseMessage deleteUser(int id)
        {
            try
            {
                var data = UserArtistServices.delete(id);

                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }

        }

        [Route("api/artist/message/send")]
        [HttpPost]
        [ArtistAuth]
        public HttpResponseMessage sendMessage(ConversationDTO conversationDTO)
        {
            try
            {
                var data = ConversationServices.SendMessage(conversationDTO);

                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }

        }

        [Route("api/artist/conversation/{id}")]
        [HttpGet]
        [ArtistAuth]
        public HttpResponseMessage getConversation(int id)
        {
            try
            {
                var data = ConversationServices.GetConversation(id);

                return Request.CreateResponse(HttpStatusCode.OK, data);

            }catch(Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
         
        }

        [Route("api/artist/message/reply")]
        [HttpPost]
        [ArtistAuth]
        public HttpResponseMessage replyMessage(ConversationDTO conversationDTO)
        {
            try
            {
                var data = ConversationServices.ReplyMessage(conversationDTO);

                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }

        }



    }
}
