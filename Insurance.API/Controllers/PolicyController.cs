using AutoMapper;
using Insurance.API.Models;
using Insurance.Domain.AggregatesModel.PolicyAggregate;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;

namespace Insurance.API.Controllers
{
    public class PolicyController : ApiController
    {
        private readonly IPolicyRepository _context;

        public PolicyController()
        {
        }

        public PolicyController(IPolicyRepository context)
        {
            this._context = context;
        }

        [HttpGet]
        public HttpResponseMessage GetAll()
        {
            var res = _context.GetAll();

            var listObj = Mapper.Map<ICollection<PolicyDTO>>(res);

            return new HttpResponseMessage()
            {
                Content = new StringContent(JsonConvert.SerializeObject(listObj))
            };
        }

        [HttpGet]
        public Policy Get(int id)
        {
            return _context.Get(id);
        }

        [HttpPost]
        [Route("api/policy/save")]
        public IHttpActionResult Save([FromBody]PolicyDTO policy)
        {
            _context.Add(Mapper.Map<Policy>(policy));
            return Ok();
        }

        [HttpPost]
        [Route("api/policy/update")]
        public IHttpActionResult Update([FromBody]PolicyDTO policy)
        {
            _context.Update(Mapper.Map<Policy>(policy));
            return Ok();
        }

        [HttpGet]
        [Route("api/policy/delete")]
        public IHttpActionResult Delete(int id)
        {
            _context.Remove(id);
            return Ok();
        }
    }
}
