using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi_new.Controllers
{
    public abstract class BaseApiController : ApiController
    {
        public HttpResponseMessage Found(object obj)
        {
            return ControllerContext.Request.CreateResponse(HttpStatusCode.OK, obj);
        }

        public HttpResponseMessage Found()
        {
            return ControllerContext.Request.CreateResponse(HttpStatusCode.OK);
        }

        public HttpResponseMessage DoesNotExist()
        {
            return ControllerContext.Request.CreateResponse(HttpStatusCode.NotFound);
        }

        public HttpResponseMessage EmptyResult()
        {
            return ControllerContext.Request.CreateResponse(HttpStatusCode.OK, "No match found");
        }
    }
}