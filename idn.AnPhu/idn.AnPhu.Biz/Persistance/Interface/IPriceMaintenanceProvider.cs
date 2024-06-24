using Client.Core.Data;
using idn.AnPhu.Biz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idn.AnPhu.Biz.Persistance.Interface
{
    public interface IPriceMaintenanceProvider : IDataProvider<PriceMaintenance>
    {

        void Add(PriceMaintenance model, string culture);
        List<PriceMaintenance> Search(int startIndex, int lenght, ref int totalItem, string culture);
        List<PriceMaintenance> GetAllActive(string culture);
    }
}
