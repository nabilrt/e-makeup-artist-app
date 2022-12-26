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
    public class PackageController : ApiController
    {
        [Route("api/packages")]
        [HttpGet]
        [CustomerAuth]
        public HttpResponseMessage GetAllPackages()
        {
            var data = PackageServices.getALL();

            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/artists/packages")]
        [HttpPost]
       
        public HttpResponseMessage GetArtistPackages(ArtistDTO artistDTO)
        {
            var data = PackageServices.GetPackagesByArtist(artistDTO.Id);

            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/package/add")]
        [HttpPost]
        [ArtistAuth]
        public HttpResponseMessage AddPackage(PackageDTO packageDTO)
        {
            var data = PackageServices.addPackage(packageDTO);

            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/package/details")]
        [HttpPost]
        [ArtistAuth]
        public HttpResponseMessage GetPackage(PackageDTO packageDTO)
        {
            var data=PackageServices.get(packageDTO.Id);

            return Request.CreateResponse(HttpStatusCode.OK, data); 

        }

        [Route("api/package/update")]
        [HttpPost]
        [ArtistAuth]
        public HttpResponseMessage UpdatePackage(PackageDTO packageDTO)
        {
            var data = PackageServices.updatePackage(packageDTO);

            return Request.CreateResponse(HttpStatusCode.OK,data);
        }

        [Route("api/package/delete/{id}")]
        [HttpGet]
        [ArtistAuth]
        public HttpResponseMessage DeletePackage(int id)
        {
            var data=PackageServices.deletePackage(id);

            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
    }
}
