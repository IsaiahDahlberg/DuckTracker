using DuckTracker.Models.CreateModels;
using DuckTracker.Models.Query;
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
    [RoutePrefix("api/mama")]
    public class MamaController : ApiController
    {
        private IMamaRepository _repo = RepositoryFactory.CreateMamaRepo();

        [Route("create")]
        public IHttpActionResult Create (JObject jPackage)
        {
            try
            {
                var id = _repo.Create(JsonConvert.DeserializeObject<CreateMamaDogModel>(jPackage.ToString()));
                return Ok(id);
            }
            catch
            {
                return NotFound();
            }         
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

        [Route("update")]
        [HttpPost]
        public IHttpActionResult Update(JObject jPackage)
        {
            _repo.Update(JsonConvert.DeserializeObject<MamaDog>(jPackage.ToString()));
            return Ok();
        }

        [Route("delete/{id:int}")]
        public IHttpActionResult Delete(int id)
        {
            _repo.Delete(id);
            return Ok();
        }
    }
}
