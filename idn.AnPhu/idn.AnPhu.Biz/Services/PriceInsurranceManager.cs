using Client.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using idn.AnPhu.Biz.Models;
using System.Threading.Tasks;
using idn.AnPhu.Biz.Persistance.Interface;

namespace idn.AnPhu.Biz.Services
{
    public class PriceInsurranceManager : DataManagerBase<PriceInsurrance>
    {
        public PriceInsurranceManager()
            : base()
        { }

        public PriceInsurranceManager(IDataProvider<PriceInsurrance> provider)
            : base(provider)
        {
        }

        private IPriceInsurranceProvider PriceInsurranceProvider
        {
            get { return (IPriceInsurranceProvider)Provider; }
        }


        public List<PriceInsurrance> Search(int startIndex, int lenght, ref int totalItem, string culture)
        {
            return PriceInsurranceProvider.Search(startIndex, lenght, ref totalItem, culture);
        }
        public List<PriceInsurrance> GetAllActive(string culture)
        {
            return PriceInsurranceProvider.GetAllActive(culture);
        }
        public void Add(PriceInsurrance model, string culture)
        {
            PriceInsurranceProvider.Add(model, culture);
        }
    }
}
