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

        [Route("get")]
        public IHttpActionResult GetAll()
        {
            return Ok(JsonConvert.SerializeObject(_repo.GetAll()));
        }

        [Route("get/{id:int}")]
        public IHttpActionResult GetById(int id)
        {
            return Ok(JsonConvert.SerializeObject(_repo.GetById(id)));
        }

        [Route("GetByMamaId/{id:int}")]
        public IHttpActionResult GetByMamaId(int id)
        {
            return Ok(JsonConvert.SerializeObject(_repo.GetByMamaId(id)));
        }

        [Route("GetByPapaId/{id:int}")]
        public IHttpActionResult GetByPapaId(int id)
        {
            return Ok(JsonConvert.SerializeObject(_repo.GetByPapaId(id)));
        }
    }
}
