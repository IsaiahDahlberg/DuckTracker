﻿using DuckTracker.Models.Query;
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
    [RoutePrefix("api/mama")]
    public class MamaController : ApiController
    {
        private IMamaRepository _repo = RepositoryFactory.CreateMamaRepo();

        [Route("create")]
        public IHttpActionResult Create (MamaDog mama)
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
