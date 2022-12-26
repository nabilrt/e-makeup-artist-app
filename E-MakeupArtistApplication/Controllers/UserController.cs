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
    public class UserController : ApiController
    {
        [Route("api/user/find")]
        [HttpPost]

        public HttpResponseMessage GetUser(UserDTO userDTO)
        {
            var data = UserServices.get(userDTO.Id);

            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/token/expire")]
        [HttpPost]

        public HttpResponseMessage ExpireToken(TokenDTO token)
        {
            var data = AuthServices.ExpireTokenByUser(token);

            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

       // [Route]
    }
}
