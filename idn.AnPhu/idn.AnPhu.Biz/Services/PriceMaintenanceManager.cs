using Client.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using idn.AnPhu.Biz.Models;
using idn.AnPhu.Biz.Persistance.Interface;

namespace idn.AnPhu.Biz.Services
{
    public class PriceMaintenanceManager : DataManagerBase<PriceMaintenance>
    {
        public PriceMaintenanceManager()
            : base()
        { }

        public PriceMaintenanceManager(IDataProvider<PriceMaintenance> provider)
            : base(provider)
        {
        }

        private IPriceMaintenanceProvider PriceMaintenanceProvider
        {
            get { return (IPriceMaintenanceProvider)Provider; }
        }


        public List<PriceMaintenance> Search(int startIndex, int lenght, ref int totalItem, string culture)
        {
            return PriceMaintenanceProvider.Search(startIndex, lenght, ref totalItem, culture);
        }
        public List<PriceMaintenance> GetAllActive(string culture)
        {
            return PriceMaintenanceProvider.GetAllActive(culture);
        }
        public void Add(PriceMaintenance model, string culture)
        {
            PriceMaintenanceProvider.Add(model, culture);
        }
    }
}
