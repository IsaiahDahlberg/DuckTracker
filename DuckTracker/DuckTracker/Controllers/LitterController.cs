using DuckTracker.Repositories;
using DuckTracker.Repositories.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DuckTracker.Controllers
{
    [RoutePrefix("api/litter")]
    public class LitterController : ApiController
    {
        private ILitterRepository _repo = RepositoryFactory.CreateLitterRepo();

        [Route("GetByMamaId/{id:int}")]
        public IHttpActionResult GetByMamaId(int id)
        {
            return Ok(JsonConvert.SerializeObject(_repo.GetByMamaId(id)));
        }
    }
}
