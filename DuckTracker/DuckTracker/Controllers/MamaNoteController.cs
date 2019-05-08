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
    [RoutePrefix("api/note/mama")]
    public class MamaNoteController : ApiController
    {
        private IMamaNoteRepository _repo = RepositoryFactory.CreateMamaNoteRepo();

        [Route("add")]
        [HttpPost]
        public IHttpActionResult Add(JObject jPackage)
        {
            
            _repo.Create(JsonConvert.DeserializeObject<MamaDogNote>(jPackage.ToString()));
            return Ok();
        }

        [Route("GetByMamaId/{id:int}")]
        [HttpGet]
        public IHttpActionResult GetByMamaId(int id)
        {
            return Ok(JsonConvert.SerializeObject(_repo.GetByMamaDogId(id)));
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
