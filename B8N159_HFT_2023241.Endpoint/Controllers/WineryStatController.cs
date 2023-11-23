using B8N159_HFT_2023241.Logic;
using B8N159_HFT_2023241.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace B8N159_HFT_2023241.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class WineryStatController : ControllerBase
    {
        IWineryLogic logic;

        public WineryStatController(IWineryLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet]
        public double AverageWinePrice()
        {
            return this.logic.AverageWinePrice();
        }
        [HttpGet]
        public IEnumerable<WinesWtihoutAward> WinesWtihoutAwardsByWinery()
        {
            return this.logic.WinesWhitoutAwardByWinery();
        }
        [HttpGet]
        public IEnumerable<AvgByWinery> AveragePriceByWinery()
        {
            return this.logic.AveragePriceByWinery();
        }
        [HttpGet]
        public Winery WineryWithMostExpensiveWine()
        {
            return this.logic.WineryWithMostExpensiveWine();
        }
    }
}
