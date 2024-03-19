using B8N159_HFT_2023241.Endpoint.Services;
using B8N159_HFT_2023241.Logic;
using B8N159_HFT_2023241.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;


namespace B8N159_HFT_2023241.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AwardController : ControllerBase
    {
        IAwardLogic logic;
        IHubContext<SignalRHub> hub;

        public AwardController(IAwardLogic logic, IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.hub = hub;
        }

        // GET: api/<AwardController>
        [HttpGet]
        public IEnumerable<Award> ReadAll()
        {
            return this.logic.ReadAll();
        }

        // GET api/<AwardController>/5
        [HttpGet("{id}")]
        public Award Read(int id)
        {
            return this.logic.Read(id);
        }

        // POST api/<AwardController>
        [HttpPost]
        public void Create([FromBody] Award value)
        {
            this.logic.Create(value);
            this.hub.Clients.All.SendAsync("AwardCreated", value);
        }

        // PUT api/<AwardController>/5
        [HttpPut]
        public void Update([FromBody] Award value)
        {
            this.logic.Update(value);
            this.hub.Clients.All.SendAsync("AwardUpdated", value);
        }

        // DELETE api/<AwardController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var awardToDelete = this.logic.Read(id);
            this.logic.Delete(id);
            this.hub.Clients.All.SendAsync("AwardDeleted", awardToDelete);
        }
    }
}
