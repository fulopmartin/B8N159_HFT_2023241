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
    public class WineryController : ControllerBase
    {
        IWineryLogic logic;
        IHubContext<SignalRHub> hub;
        public WineryController(IWineryLogic logic, IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.hub = hub;
        }

        // GET: api/<WineryController>
        [HttpGet]
        public IEnumerable<Winery> ReadAll()
        {
            return this.logic.ReadAll(); ;
        }

        // GET api/<WineryController>/5
        [HttpGet("{id}")]
        public Winery Read(int id)
        {
            return this.logic.Read(id); ;
        }

        // POST api/<WineryController>
        [HttpPost]
        public void Create([FromBody] Winery value)
        {
            this.logic.Create(value);
            this.hub.Clients.All.SendAsync("WineryCreated", value);

        }

        // PUT api/<WineryController>/5
        [HttpPut]
        public void Update([FromBody] Winery value)
        {
            this.logic.Update(value);
            this.hub.Clients.All.SendAsync("WineryUpdated", value);
        }

        // DELETE api/<WineryController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var wineryToDelete = this.logic.Read(id);
            this.logic.Delete(id);
            this.hub.Clients.All.SendAsync("WineryDeleted", wineryToDelete);
        }
    }
}
