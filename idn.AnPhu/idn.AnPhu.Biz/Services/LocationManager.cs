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
    public class LocationManager : DataManagerBase<Location>
    {
        public LocationManager()
            : base()
        { }

        public LocationManager(IDataProvider<Location> provider)
            : base(provider)
        {
        }

        private ILocationProvider LocationProvider
        {
            get { return (ILocationProvider)Provider; }
        }
        public List<Location> GetAllActive(string culture)
        {
            return LocationProvider.GetAllActive(culture);
        }
    }
}
