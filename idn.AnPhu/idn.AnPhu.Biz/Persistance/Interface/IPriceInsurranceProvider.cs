using Client.Core.Data;
using idn.AnPhu.Biz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idn.AnPhu.Biz.Persistance.Interface
{
    public interface IPriceInsurranceProvider : IDataProvider<PriceInsurrance>
    {

        void Add(PriceInsurrance model, string culture);
        List<PriceInsurrance> Search(int startIndex, int lenght, ref int totalItem, string culture);
        List<PriceInsurrance> GetAllActive(string culture);
    }
}
