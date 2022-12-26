using E_MakeupArtistApplicationBussinessLogicLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace E_MakeupArtistApplication.Auth
{
    public class ArtistAuth : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            var token = actionContext.Request.Headers.Authorization;
            if (token == null)
            {
                actionContext.Response = actionContext.Request.CreateResponse(System.Net.HttpStatusCode.Unauthorized, "No token supplied");

            }
            else
            {
                var dbtoken = AuthServices.IsTokenValid(token.ToString());
                if (dbtoken == null)
                {
                    actionContext.Response = actionContext.Request.CreateResponse(System.Net.HttpStatusCode.Unauthorized, "Supplied Token is invalid or expired");
                }
                else
                {
                    var user = UserServices.get(dbtoken.UserId);
   
                    if (user == null || user.User_Type != "Artist")
                    {
                        actionContext.Response = actionContext.Request.CreateResponse(System.Net.HttpStatusCode.Unauthorized, "You cannot access this");
                    }
                }

            }
            base.OnAuthorization(actionContext);
        }
    }
}