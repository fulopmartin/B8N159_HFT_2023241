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
    public class WineController : ControllerBase
    {
        IWineLogic logic;
        IHubContext<SignalRHub> hub;
        public WineController(IWineLogic logic, IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.hub = hub;
        }

        // GET: api/<WineController>
        [HttpGet]
        public IEnumerable<Wine> ReadAll()
        {
            return this.logic.ReadAll();
        }

        // GET api/<WineController>/5
        [HttpGet("{id}")]
        public Wine Read(int id)
        {
            return this.logic.Read(id);
        }

        // POST api/<WineController>
        [HttpPost]
        public void Create([FromBody] Wine value)
        {
            this.logic.Create(value);
            this.hub.Clients.All.SendAsync("WineCreated", value);
        }

        // PUT api/<WineController>/5
        [HttpPut]
        public void Update([FromBody] Wine value)
        {
            this.logic.Update(value);
            this.hub.Clients.All.SendAsync("WineUpdated", value);
        }

        // DELETE api/<WineController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var wineToDelete = this.logic.Read(id);
            this.logic.Delete(id);
            this.hub.Clients.All.SendAsync("WineDeleted", wineToDelete);
        }
    }
}
