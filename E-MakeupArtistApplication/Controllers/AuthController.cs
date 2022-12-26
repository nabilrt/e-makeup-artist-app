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
    public class AuthController : ApiController
    {
        [Route("api/login")]
        [HttpPost]
        public HttpResponseMessage Login(LoginDTO login)
        {
            if (login == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Username password not supplied");
            }
            if (ModelState.IsValid)
            {
                var token = AuthServices.Authenticate(login.Username, login.Password);
                var user = UserServices.get(token.UserId);
                if (token != null)
                {
                    if (user.Is_Approved == 1)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, token);

                    }
                    else if(user.Is_Approved== 0) {

                        return Request.CreateResponse(HttpStatusCode.OK, "Unapproved");
                    }
                    
                }

                return Request.CreateResponse(HttpStatusCode.NotFound, "Username password invalid");
            }
            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
        }
    }
}
