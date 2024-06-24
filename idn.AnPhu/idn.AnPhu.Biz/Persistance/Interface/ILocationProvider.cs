using Client.Core.Data;
using idn.AnPhu.Biz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idn.AnPhu.Biz.Persistance.Interface
{
    public interface ILocationProvider : IDataProvider<Location>
    {
        //void Add(LocationDiscount model, string culture);
        //List<LocationDiscount> Search(int startIndex, int lenght, ref int totalItem, string culture);
        List<Location> GetAllActive(string culture);
    }
}
