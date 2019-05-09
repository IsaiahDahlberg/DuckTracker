using DuckTracker.Models.Tables;
using DuckTracker.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DuckTracker.Repositories;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace DuckTracker.Controllers
{
    [RoutePrefix("api/note/papa")]
    public class PapaNoteController : ApiController
    {
        private IPapaNoteRepository _repo = RepositoryFactory.CreatePapaNoteRepo();

        [Route("Create")]
        [HttpPost]
        public IHttpActionResult Create(JObject jPackage)
        {
            _repo.Create(JsonConvert.DeserializeObject<PapaDogNote>(jPackage.ToString()));
            return Ok();
        }

        [Route("get/{id:int}")]
        public IHttpActionResult Get(int id)
        {
            return Ok(JsonConvert.SerializeObject(_repo.GetById(id)));
        }
        [Route("GetByPapaId/{id:int}")]
        [HttpGet]
        public IHttpActionResult GetByPapaId(int id)
        {
            return Ok(JsonConvert.SerializeObject(_repo.GetByPapaDogId(id)));
        }

        [Route("Update")]
        public IHttpActionResult Update(JObject jPackage)
        {
            _repo.Update(JsonConvert.DeserializeObject<PapaDogNote>(jPackage.ToString()));
            return Ok();
        }

        [Route("delete/{id:int}")]
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            _repo.Delete(id);
            return Ok();
        }
    }
}
