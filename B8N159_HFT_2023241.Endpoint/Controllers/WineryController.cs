using B8N159_HFT_2023241.Logic;
using B8N159_HFT_2023241.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace B8N159_HFT_2023241.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class WineryController : ControllerBase
    {
        IWineryLogic logic;

        public WineryController(IWineryLogic logic)
        {
            this.logic = logic;
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
        }

        // PUT api/<WineryController>/5
        [HttpPut("{id}")]
        public void Update([FromBody] Winery value)
        {
            this.logic.Update(value);
        }

        // DELETE api/<WineryController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.logic.Delete(id);
        }
    }
}
