using B8N159_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B8N159_HFT_2023241.Logic
{
    public interface IWineLogic
    {
        void Create(Wine item);
        void Delete(int id);
        Wine Read(int id);
        IEnumerable<Wine> ReadAll();
        void Update(Wine item);

        //non-cruds
        IEnumerable<Wine> WinesWithNationalAward();
        Wine WineWithMostDomesticAward();
    }
}
