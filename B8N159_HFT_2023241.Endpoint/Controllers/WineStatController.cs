using B8N159_HFT_2023241.Logic;
using B8N159_HFT_2023241.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace B8N159_HFT_2023241.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class WineStatController : ControllerBase
    {
        IWineLogic logic;

        public WineStatController(IWineLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet]
        public IEnumerable<Wine> WinesWithNationalAward()
        {
            return this.logic.WinesWithNationalAward();
        }

        [HttpGet]
        public Wine WineWithMostDomesticAward()
        {
            return this.logic.WineWithMostDomesticAward();
        }
    }
}
