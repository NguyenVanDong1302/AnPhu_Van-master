using Client.Core.Data;
using idn.AnPhu.Biz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idn.AnPhu.Biz.Persistance.Interface
{
    public interface IBankDiscountProvider : IDataProvider<BankDiscount>
    {
        void Add(BankDiscount model, string culture);
        List<BankDiscount> Search(int startIndex, int lenght, ref int totalItem, string culture);
        List<BankDiscount> GetAllActive(string culture);
    }
}
