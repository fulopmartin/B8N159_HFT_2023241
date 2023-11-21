using B8N159_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace B8N159_HFT_2023241.Logic
{
    public interface IWineryLogic
    {
        void Create(Winery item);
        void Delete(int id);
        Winery Read(int id);
        IEnumerable<Winery> ReadAll();
        void Update(Winery item);
        //non-cruds
        IEnumerable<WinesWtihoutAward> WinesWhitoutAwardByWinery();
        IEnumerable<AvgByWinery> AveragePriceByWinery();
        double AverageWinePrice();
        Winery WineryWithMostExpensiveWine();

    }
}
