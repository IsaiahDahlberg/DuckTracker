using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DuckTracker.Controllers
{
    [RoutePrefix("api/note")]
    public class NoteController : ApiController
    {
        [Route("GetAll")]
        public IHttpActionResult GetAll()
        {

        }
    }
}
