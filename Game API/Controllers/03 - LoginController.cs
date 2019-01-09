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
    [RoutePrefix("LoginController")]
    public class LoginController : ApiController
    {
        private UserLogic userLogic = new UserLogic();

        [HttpPost]
        [Route("login")]
        public HttpResponseMessage Login(UserModel newUser)
        {
            try
            {
                UserModel user = userLogic.Login(newUser);
                return Request.CreateResponse(HttpStatusCode.OK, user);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.StackTrace);
            }
        }

        [HttpPost]
        [Route("register")]
        public HttpResponseMessage Register(UserModel newUser)
        {
            try
            {
                UserModel user = userLogic.Register(newUser);
                return Request.CreateResponse(HttpStatusCode.OK, user);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.StackTrace);
            }
        }

        [HttpGet]
        [Route("getResultsByID")]
        public HttpResponseMessage getResultsByID(int id)
        {
            try
            {
                ResultModel[] results = userLogic.GetResultsByID(id);
                return Request.CreateResponse(HttpStatusCode.OK, results);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.StackTrace);
            }
        }
    }
}
