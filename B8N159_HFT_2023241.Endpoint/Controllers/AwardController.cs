using B8N159_HFT_2023241.Logic;
using B8N159_HFT_2023241.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace B8N159_HFT_2023241.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AwardController : ControllerBase
    {
        IAwardLogic logic;

        public AwardController(IAwardLogic logic)
        {
            this.logic = logic;
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
        }

        // PUT api/<AwardController>/5
        [HttpPut("{id}")]
        public void Update([FromBody] Award value)
        {
            this.logic.Update(value);
        }

        // DELETE api/<AwardController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.logic.Delete(id);
        }
    }
}
