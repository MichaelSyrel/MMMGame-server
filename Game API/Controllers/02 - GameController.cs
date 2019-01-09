using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Hosting;
using System.Web.Http;
using System.Web.Http.Cors;

namespace MMMGame.Controllers
{

    [EnableCors("*", "*", "*")]
    [RoutePrefix("GameController")]
    public class GameController : ApiController
    {
        private GameLogic gameLogic = new GameLogic();



        [HttpGet]
        [Route("getRoundData")]
        public HttpResponseMessage GetGameRoundData(int difficulty)
        {
            try
            {
                ImageModel[][] gameBoard = gameLogic.GetGameRoundData(difficulty);
                return Request.CreateResponse(HttpStatusCode.OK, gameBoard);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.StackTrace);
            }
        }

        [HttpGet]
        [Route("getResults")]
        public HttpResponseMessage GetResults()
        {
            try
            {
                ResultModel[] results = gameLogic.GetResults();
                return Request.CreateResponse(HttpStatusCode.OK, results);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.StackTrace);
            }
        }

        [HttpPost]
        [Route("postResult")]
        public HttpResponseMessage PostResult(ResultModel result)
        {
            try
            {
                result = gameLogic.PostResult(result);
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.StackTrace);
            }
        }
    }
}
