using DuckTracker.Models.Query;
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
    public class MamaController : ApiController
    {
        private IMamaRepository _repo = RepositoryFactory.CreateMamaRepo();

        [Route("api/mama/create")]
        public IHttpActionResult Create (MamaDog mama)
        {
            return null;
        }

        [Route("api/mama/GetAll")]
        public IHttpActionResult GetAll()
        {
            var jsonObject = JsonConvert.SerializeObject(_repo.GetAll());
            return Ok(jsonObject);
        }
    }
}
