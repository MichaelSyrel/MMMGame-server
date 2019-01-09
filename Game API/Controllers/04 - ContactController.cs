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
    [RoutePrefix("ContactController")]
    public class ContactController : ApiController
    {

        private ContactMessagesLogic contactLogic = new ContactMessagesLogic();


        [HttpPost]
        [Route("postMessage")]
        public HttpResponseMessage PostResult(ContactMessageModel msg)
        {
            try
            {
                msg = contactLogic.PostNewMessage(msg);
                return Request.CreateResponse(HttpStatusCode.OK, msg);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.StackTrace);
            }
        }

    }
}
