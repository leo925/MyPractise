﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi2.Controllers
{
    public class ReaderController : ApiController
    {
        // GET: api/Reader
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Reader/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Reader
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Reader/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Reader/5
        public void Delete(int id)
        {
        }
    }
}
