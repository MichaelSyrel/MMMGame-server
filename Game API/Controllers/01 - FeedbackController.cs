using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace MMMGame.Controllers
{
    [EnableCors("*", "*", "*")]
    [RoutePrefix("FeedbackController")]
    public class FeedbackController : ApiController
    {
        private FeedbackLogic feedbackLogic = new FeedbackLogic();

        [HttpGet]
        [Route("getFeedbacks")]
        public HttpResponseMessage GetFeedbacks()
        {
            try
            {
                var result = new HttpResponseMessage(HttpStatusCode.OK);
                List<FeedbackModel>  feedbacks = feedbackLogic.GetFeedbacks();
                return Request.CreateResponse(HttpStatusCode.OK, feedbacks);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.StackTrace);
            }
        }

        [HttpPost]
        [Route("postFeedback")]
        public HttpResponseMessage PostFeedback(FeedbackModel feedback)
        {
            try
            {
                 feedback = feedbackLogic.PostFeedback(feedback);
                return Request.CreateResponse(HttpStatusCode.OK, feedback);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
