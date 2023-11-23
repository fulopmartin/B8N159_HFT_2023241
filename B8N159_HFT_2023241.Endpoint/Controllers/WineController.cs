using B8N159_HFT_2023241.Logic;
using B8N159_HFT_2023241.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace B8N159_HFT_2023241.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class WineController : ControllerBase
    {
        IWineLogic logic;

        public WineController(IWineLogic logic)
        {
            this.logic = logic;
        }

        // GET: api/<WineController>
        [HttpGet]
        public IEnumerable<Wine> ReadAll()
        {
            return this.logic.ReadAll(); ;
        }

        // GET api/<WineController>/5
        [HttpGet("{id}")]
        public Wine Read(int id)
        {
            return this.logic.Read(id); ;
        }

        // POST api/<WineController>
        [HttpPost]
        public void Create([FromBody] Wine value)
        {
            this.logic.Create(value);
        }

        // PUT api/<WineController>/5
        [HttpPut("{id}")]
        public void Update([FromBody] Wine value)
        {
            this.logic.Update(value);
        }

        // DELETE api/<WineController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.logic.Delete(id);
        }
    }
}
