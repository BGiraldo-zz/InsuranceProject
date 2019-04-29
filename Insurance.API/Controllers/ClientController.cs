using AutoMapper;
using Insurance.API.Models;
using Insurance.Domain.AggregatesModel.ClientAggregate;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;

namespace Insurance.API.Controllers
{
    public class ClientController : ApiController
    {

        private readonly IClientRepository _context;

        public ClientController()
        {
        }

        public ClientController(IClientRepository context)
        {
            this._context = context;
        }

        [HttpGet]
        public HttpResponseMessage GetAll()
        {
            var res = _context.GetAll();

            var listObj = Mapper.Map<ICollection<ClientDTO>>(res);

            return new HttpResponseMessage()
            {
                Content = new StringContent(JsonConvert.SerializeObject(listObj))
            };
        }

        [HttpGet]
        public Client Get(int id)
        {
            return _context.Get(id);
        }

        [HttpPost]
        [Route("api/client/save")]
        public IHttpActionResult Save([FromBody]ClientDTO client)
        {
            _context.Add(Mapper.Map<Client>(client));
            return Ok();
        }

        [HttpPost]
        [Route("api/policy/update")]
        public IHttpActionResult Update([FromBody]ClientDTO client)
        {
            _context.Update(Mapper.Map<Client>(client));
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
