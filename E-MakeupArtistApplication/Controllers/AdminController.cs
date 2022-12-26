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
    public class AdminController : ApiController
    {
        [Route("api/admin/details")]
        [HttpPost]
        [AdminAuth]
        public HttpResponseMessage GetAdminDetails(UserAdminDTO userAdminDTO)
        {
            var data = UserAdminService.Get(userAdminDTO.Id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/admin/get/{id}")]
        [HttpGet]
        [AdminAuth]
        public HttpResponseMessage GetAdminDetail(int id)
        {
            var data = UserAdminService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/artists/unapproved")]
        [HttpPost]
        [AdminAuth]
        public HttpResponseMessage UnApprovedArtists()
        {
            var data = UserServices.GetUnapproved();

            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/artist/approve/{id}")]
        [HttpGet]
        [AdminAuth]
        public HttpResponseMessage ApproveArtist(int id)
        {
            var data=UserServices.approveUser(id);

            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/admin/update")]
        [HttpPost]
        [AdminAuth]
        public HttpResponseMessage UpdateAdminDetails(UserAdminDTO userAdminDTO)
        {
            var data = UserAdminService.Update(userAdminDTO);
            return Request.CreateResponse(HttpStatusCode.OK,data);
        }
    }
}
