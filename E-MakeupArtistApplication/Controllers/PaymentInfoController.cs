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
    public class PaymentInfoController : ApiController
    {
        [Route("api/paymentInfo")]
        [HttpGet]
        [AdminAuth]
        public HttpResponseMessage GetPaymentInfo()
        {
            var data = PaymentInfoServices.GetPaymentInfos();

            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/paymentInfo/details")]
        [HttpPost]
        [AdminAuth]
        public HttpResponseMessage ViewPaymentInfo(PaymentInfoDTO paymentInfoDTO)
        {
            var data=PaymentInfoServices.GetPaymentInfo(paymentInfoDTO.Id);

            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/paymentInfo/update")]
        [HttpPost]
        [AdminAuth]
        public HttpResponseMessage UpdatePaymentInformation(PaymentInfoDTO paymentInfoDTO)
        {
            var data = PaymentInfoServices.UpdatePaymentInfo(paymentInfoDTO);

            return Request.CreateResponse(HttpStatusCode.OK,data);
        }
    }
}
