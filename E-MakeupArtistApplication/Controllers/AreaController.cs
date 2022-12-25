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
    public class AreaController : ApiController
    {
        [Route("api/areas")]
        [HttpGet]
        
        public HttpResponseMessage GetAllAreas()
        {
            var data = AreaServices.getALL();

            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/area/{id}")]
        [HttpGet]
        [AdminAuth]
        public HttpResponseMessage GetArea(int id)
        {
            var data=AreaServices.GetArea(id);

            return Request.CreateResponse(HttpStatusCode.OK,data);  
        }

        [Route("api/area/update")]
        [HttpPost]
        [AdminAuth]
        public HttpResponseMessage UpdateAreaName(AreaDTO areaDTO)
        {
            var data=AreaServices.UpdateArea(areaDTO);

            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/area/delete/{id}")]
        [HttpGet]
        [AdminAuth]
        public HttpResponseMessage DeleteArea(int id)
        {
            var data= AreaServices.DeleteArea(id);

            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
    }
}
