using DuckTracker.Models.Tables;
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
    [RoutePrefix("api/papa")]
    public class PapaController : ApiController
    {
        private IPapaRepository _repo = RepositoryFactory.CreatePapaRepo();

        [Route("create")]
        public IHttpActionResult Create(PapaDog papa)
        {
            return null;
        }

        [Route("GetAll")]
        public IHttpActionResult GetAll()
        {
            var jsonObject = JsonConvert.SerializeObject(_repo.GetAll());
            return Ok(jsonObject);
        }

        [Route("get/{id:int}")]
        public IHttpActionResult GetById(int id)
        {
            return Ok(JsonConvert.SerializeObject(_repo.GetById(id)));
        }
    }
}
