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
    public class FeedbackController : ApiController
    {
        [Route("api/feedbacks")]
        [HttpGet]
        public HttpResponseMessage getAllFeedbacks()
        {
            var data = FeedbackServices.getALL();

            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/feedback/add")]
        [HttpPost]

        public HttpResponseMessage addFeedback(FeedbackDTO feedbackDTO)
        {
            var data = FeedbackServices.addFeedback(feedbackDTO);

            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/feedback/{id}")]
        [HttpGet]

        public HttpResponseMessage getfeedback(int id)
        {
            var data = FeedbackServices.get(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/feedback/update")]
        [HttpPost]
        public HttpResponseMessage updateFeedback(FeedbackDTO feedbackDTO)
        {
            var data = FeedbackServices.updateFeedback(feedbackDTO);

            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/feedback/delete/{id}")]
        [HttpGet]
        public HttpResponseMessage deleteFeedback(int id)
        {
            var data = FeedbackServices.deleteFeedback(id);

            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
    }
}
