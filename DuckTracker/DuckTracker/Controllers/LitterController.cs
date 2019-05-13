using DuckTracker.Models.CreateModels;
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
    [RoutePrefix("api/litter")]
    public class LitterController : ApiController
    {
        private ILitterRepository _repo = RepositoryFactory.CreateLitterRepo();

        [Route("create")]
        public IHttpActionResult Create(JObject jPackage)
        {
            try
            {
                var id = _repo.Create(JsonConvert.DeserializeObject<CreateLitterModel>(jPackage.ToString()));
                return Ok(id);
            }
            catch
            {
                return NotFound();
            }
        }

        [Route("get")]
        public IHttpActionResult GetAll()
        {
            return Ok(JsonConvert.SerializeObject(_repo.GetAll()));
        }

        [Route("GetRecent")]
        public IHttpActionResult GetRecent()
        {
            return Ok(JsonConvert.SerializeObject(_repo.GetRecent()));
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

        [Route("update")]
        [HttpPost]
        public IHttpActionResult Update(JObject jPackage)
        {
            try
            {               
                return Ok(_repo.Update(JsonConvert.DeserializeObject<Litter>(jPackage.ToString())));
            }
            catch 
            {
                return NotFound();
            }        
        }

        [Route("delete/{id:int}")]
        public IHttpActionResult Delete(int id)
        {
            _repo.Delete(id);
            return Ok();
        }
    }
}
