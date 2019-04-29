using AutoMapper;
using Insurance.API.Models;
using Insurance.Domain.AggregatesModel.PolicyDetailAggregate;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;

namespace Insurance.API.Controllers
{
    public class PolicyDetailController : ApiController
    {
        private readonly IPolicyDetailRepository _context;

        public PolicyDetailController()
        {
        }

        public PolicyDetailController(IPolicyDetailRepository context)
        {
            this._context = context;
        }

        [HttpGet]
        public HttpResponseMessage GetAll()
        {
            var res = _context.GetAll();

            var listObj = Mapper.Map<ICollection<PolicyDetail>, ICollection<PolicyDetailDTO>>(res);

            return new HttpResponseMessage()
            {
                Content = new StringContent(JsonConvert.SerializeObject(listObj))
            };
        }

        [HttpGet]
        public PolicyDetail Get(int id)
        {
            return _context.Get(id);
        }

        [HttpPost]
        [Route("api/policydetail/save")]
        public IHttpActionResult Save([FromBody]PolicyDetailDTO policy)
        {
            _context.Add(Mapper.Map<PolicyDetailDTO, PolicyDetail>(policy));
            return Ok();
        }

        [HttpPost]
        [Route("api/policydetail/update")]
        public IHttpActionResult Update([FromBody]PolicyDetailDTO policy)
        {
            _context.Update(Mapper.Map<PolicyDetailDTO, PolicyDetail>(policy));
            return Ok();
        }

        [HttpGet]
        [Route("api/policydetail/delete")]
        public IHttpActionResult Delete(int id)
        {
            _context.Remove(id);
            return Ok();
        }
    }
}
