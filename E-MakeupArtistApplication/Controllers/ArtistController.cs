﻿using E_MakeupArtistApplicationBussinessLogicLayer.DTOs;
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

    }
}