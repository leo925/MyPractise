using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Routing;

namespace WebApi.Controllers
{
    [EnableCors("*", "*", "*")]
    public class ReadersController : ApiController
    {
        static List<ReaderModel> DummyReaders = new List<ReaderModel>();
        static ReadersController()
        {
            DummyReaders = GenerateReaders();
        }
        // GET: api/Reader
        public IEnumerable<ReaderModel> Get()
        {
            return DummyReaders;
        }

        // GET: api/Reader/5
        public ReaderModel Get(int id)
        {
            var foundReader = DummyReaders.FirstOrDefault(r => r.Id == id);
            return foundReader;
        }

        // POST: api/Reader
        public HttpResponseMessage Post([FromBody]ReaderModel value)
        {
            var c = Request.GetRouteData().Values["controller"];
            DummyReaders.Add(value);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, value);
            return response;
        }

        //[HttpPost]
        //public void AddReader([FromBody] ReaderModel value)
        //{

        //}

        // PUT: api/Reader/5
        public void Put(int id, [FromBody]string value)
        {
        }

        //// DELETE: api/Reader/5
        //public void Delete(int id)
        //{
        //}

        private static List<ReaderModel> GenerateReaders()
        {
            List<ReaderModel> readers = new List<ReaderModel>();
            for (int i = 0; i < 15; i++)
            {
                ReaderModel reader = new ReaderModel() {
                    Name = "reader" + i.ToString(),
                    IP = "10,1,10," + i.ToString() ,
                    Port=i,
                    Id=i
                };
                readers.Add(reader);
            }
            return readers;
        }
    }

    public enum MyStatus
    {
        Ok, 
        Failed
    }
}
