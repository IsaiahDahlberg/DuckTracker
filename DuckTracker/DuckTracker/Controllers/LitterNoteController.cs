using DuckTracker.Models.Tables;
using DuckTracker.Repositories;
using DuckTracker.Repositories.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DuckTracker.Controllers
{
    [RoutePrefix("api/note/litter")]
    public class LitterNoteController : ApiController
    {
        private ILitterNoteRepository _repo = RepositoryFactory.CreateLitterNoteRepo();

        [Route("Create")]
        [HttpPost]
        public IHttpActionResult Create(JObject jPackage)
        {
            _repo.Create(JsonConvert.DeserializeObject<LitterNote>(jPackage.ToString()));
            return Ok();
        }

        [Route("get/{id:int}")]
        public IHttpActionResult Get(int id)
        {
            return Ok(JsonConvert.SerializeObject(_repo.GetById(id)));
        }
        [Route("GetByLitterId/{id:int}")]
        [HttpGet]
        public IHttpActionResult GetByLitterId(int id)
        {
            return Ok(JsonConvert.SerializeObject(_repo.GetByLitterId(id)));
        }

        [Route("Update")]
        public IHttpActionResult Update(JObject jPackage)
        {
            _repo.Update(JsonConvert.DeserializeObject<LitterNote>(jPackage.ToString()));
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
